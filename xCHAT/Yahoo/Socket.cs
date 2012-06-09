using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Yahoo
{    
   public class TCPSocket
    {
        private const int BUFFER_SIZE = 32767;
        private byte[] buffer;

        private Socket _Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private string host;
        private int port;
        private int sockID = 0;

        #region "Events and Delegates"
       
        public delegate void onConnectEventHandler(int ID);
        public event onConnectEventHandler onConnect;


        public delegate void onDataArrivalEventHandler(int socId, string Data, string utf8, int BytesTotal);
        public event onDataArrivalEventHandler onDataArrival;

        #endregion

        #region "public methods"

        public void Close()
        {
            try
            {
               // 
                _Sock.Shutdown(SocketShutdown.Both);
                _Sock.Disconnect(true);
                _Sock.Close();

                //Fix: tạo socket mới;
                _Sock = null;
                _Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        public void connect(string strHost, int numPort)
        {
            host = strHost;
            port = numPort;
            try
            {
                IPHostEntry ipHE = Dns.GetHostEntry(host);
                IPEndPoint ipEP = new IPEndPoint(ipHE.AddressList[0], port);
                _Sock.BeginConnect(ipEP, new AsyncCallback(sockConnected), _Sock);
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }
        public void sendDataLogin(string data)
        {
            try
            {
                _Sock.BeginSend(Encoding.Default.GetBytes(data),
                    0, Encoding.Default.GetBytes(data).Length, 0,
                    sockSendEnd, _Sock);               
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }
        public void sendDataMess(string data)
        {
            try
            {
               
                _Sock.BeginSend(Encoding.Default.GetBytes(data),
                    0, Encoding.Default.GetBytes(data).Length, 0,
                    sockSendEnd, _Sock);
                //byte[] d = Encoding.UTF8.GetBytes(data);
                //string thu = Encoding.UTF8.GetString(d);
                //byte[] thu3 = Encoding.Default.GetBytes(data);
                //string thu2 = Encoding.Default.GetString(Encoding.Default.GetBytes(thu));

            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        #endregion

        #region "private methods"

        private void sockConnected(IAsyncResult ar)
        {
            buffer = new byte[BUFFER_SIZE];
            _Sock = (Socket)ar.AsyncState;
            if (!isConnected) return;
            try
            {
                _Sock.BeginReceive(buffer, 0, BUFFER_SIZE, 0, sockDataArrival, _Sock);
            }
            catch (Exception ex) { Console.WriteLine("SockConnect:\n " + ex.ToString()); }
            if (onConnect != null) onConnect(sockID);
        }

        private void sockDataArrival(IAsyncResult ar)
        {
            //buffer = new byte[BUFFER_SIZE];
            try
            {
                int read = 0;
                Socket _Sock = (Socket)ar.AsyncState;

                //Fix: kiểm tra dữ liệu và kết thúc
                if (_Sock.Connected)
                    read = _Sock.EndReceive(ar);

                if (read > 0)
                {
                    _Sock.BeginReceive(buffer, 0, BUFFER_SIZE,
                       0, new AsyncCallback(sockDataArrival), _Sock);
                    byte[] data = buffer;
                    string thu = Encoding.UTF8.GetString(data);
                    string dat = Encoding.GetEncoding(1252).GetString(data);

                    if (onDataArrival != null)
                    {                        
                        onDataArrival(socketId, dat, thu, data.Length);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("sockDatArrival" + ex.ToString());
            }
        }

        private void sockSendEnd(IAsyncResult ar)
        {
            _Sock = (Socket)ar.AsyncState;
            try
            {
                int bytesSent = _Sock.EndSend(ar);
            }
            catch (Exception e)
            { Console.WriteLine("sndEnd " + e.ToString()); }
        }

        #endregion

        #region "Propertys"
        public bool isConnected { get { return _Sock.Connected; } }
        public int socketId { get { return sockID; } set { sockID = value; } }
        #endregion
    }
}
