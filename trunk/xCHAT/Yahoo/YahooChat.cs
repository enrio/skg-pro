using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;

namespace Yahoo
{
    public delegate void Thu(String thu);
    public delegate void noidung(string nd);
    public partial class YahooChat : Form
    {
        public YahooChat()
        {
            InitializeComponent();

            Worker1 = new BackgroundWorker();
            Worker1.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(Worker1_RunWorkerCompleted);
          
        }

       
        delegate void SetTexCallback(String thu);

        Thread ThreadGuiDinhKi = null;

        BackgroundWorker Worker1;
        IList<frmChat> ListChat = new List<frmChat>();
        IList<String> Nhom = new List<String>();
        TCPSocket _socket;
        ymsg _ymsg;
        String DSban = "";
        public Thu thu1;
        string nguoigui = "";
        string noidung = "";
        string sosanh = "";
        string DSLienHe = "";
        MessNhan MessNhan = new MessNhan();

        void Worker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           TaoDSfrmChat();
        }
        void TaoDSfrmChat()
        {
           // IList<ArrayList> thu = Catchuoi(DSLienHe);
            //foreach (ArrayList s in thu)
           // {
               // treeView1.Nodes.Add(s[0].ToString());
           // }
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                   // treeView1.Nodes[i].Nodes.Add(thu[i][j].ToString());
                    frmChat tamp = new frmChat();
                    tamp.Text =treeView1.Nodes[i].Nodes[j].Text.ToString();
                   // tamp.MdiParent = this;
                    tamp.thu = new Mess(gui);
                    ListChat.Add(tamp);

                }
            }
        }
        
         private void btDangNhap_Click(object sender, EventArgs e)
        {
            _socket = new TCPSocket();
            _ymsg = new ymsg();
         
             DangNhap();
             //txtPass.Hide();
             //txtYID.Hide();
             //btDangNhap.Hide();
             //label1.Hide();
             //label2.Hide();
             //button2.Location = new Point(panel1.Width/2, panel1.Height / 2);
             //button1.Enabled = true;
             //thu1 = new Thu(DuaDSVao);
             
        }
         public void DangNhap()
         {
            

             _socket.connect("scs.msg.yahoo.com", 5050);
             // _socket.sendData(_ymsg.GetChallenge(txtYID.Text));
             _socket.onConnect += new TCPSocket.onConnectEventHandler(_socket_onConnect);
             _socket.onDataArrival += new TCPSocket.onDataArrivalEventHandler(_socket_onDataArrival);
             
         }
        
         public void _socket_onDataArrival(int socId, string Data, string utf8, int BytesTotal)
        {
            
            switch ((int)Data[11])
            {
                case 85:
                    MessageBox.Show("Dang Nhap Thanh cong");
                    ThreadGuiDinhKi = new Thread(new ThreadStart(TuGianChetDi));
                    ThreadGuiDinhKi.Start();
                    break;
                case 87:
                  
                    WebClient webC = new WebClient();
                    string remoteURI;
                    string chall = getValue(Data, "À€94À€", (char)0xC0);
                    remoteURI = "https://login.yahoo.com/config/pwtoken_get?src=ymsgr&ts=&login=" + txtYID.Text + "&passwd=" + txtPass.Text + "&chal=" + chall;
                    string Response;
                    byte[] buff;
                    buff = webC.DownloadData(remoteURI);
                    Response = Encoding.ASCII.GetString(buff);
                    
                    Console.WriteLine("Đang kiểm tra Token...");
                    //Kiem tra token
                    if (Response.Contains("ymsgr="))
                    {
                        remoteURI = "https://login.yahoo.com/config/pwtoken_login?src=ymsgr&ts=&token=" + getValue(Response, "ymsgr=", (char)0xa);
                        buff = webC.DownloadData(remoteURI);
                        Response = Encoding.ASCII.GetString(buff);
                       
                        _socket.sendDataLogin((string)_ymsg.Login(txtYID.Text, chall,
                            getValue(Response, "Y=", (char)0xd),
                            getValue(Response, "T=", (char)0xd),
                            getValue(Response, "crumb=", (char)0xd), false));
                    }
                    else
                    {
                        if (Response.Equals("1235"))
                            Console.WriteLine("Đăng nhập lỗi, sai tài khoản");
                        else if (Response.Equals("1212"))
                            Console.WriteLine("Đăng nhập lỗi, sai mật khẩu");
                        else if (Response.Equals("1213"))
                            Console.WriteLine("Tài khoản đã bị khóa do đăng nhập nhiều lần");
                        else if (Response.Equals("1236"))
                            Console.WriteLine("Tài khoản đã bị khóa");
                        else if (Response.Equals("100"))
                            Console.WriteLine("Không xác định được tài khoản hoặc mật khẩu");
                        else
                            Console.WriteLine("Không rõ lỗi");
                    }
                    break;
                default:
                    DSban = Data.Substring(20, (Data.Length - 20));

                    if (Data.Contains("302À€318À€300À€318À€65À€"))
                    {    
                        DSLienHe = DSban;
                        //Worker1.RunWorkerAsync();
                        DuaDSLen(DSban);
                        Thread Th = new Thread(new ThreadStart(thuWorker1));
                        Th.Start();
                       // Worker1.RunWorkerAsync();
                        
                    }
                    //else if (DSban.Contains("TYPING"))
                    //{
                    //    Console.WriteLine(DSban);
                    //    Data = "";
                    //}
                    //else if (DSban.Contains("PEERTOPEER"))
                    //{
                    //    Console.WriteLine(DSban);
                    //    Data = "";
                    //}
                    else if ((DSban.Contains("À€14À€") && DSban.Contains("À€15À€")) || (DSban.Contains("À€14À€") && DSban.Contains("À€429À€")))
                    {
                        MessageBox.Show(DSban);
                        string ng = getValue(DSban, "4À€", (char)0xC0);
                        string nd = getValue(utf8, "��14��", (char)0xFFFD);
                        string ss = getValue(DSban, "À€429À€", (char)0xC0);
                        if (nd != "")
                        {
                            if (sosanh != ss)
                            {
                                sosanh = ss;
                                nguoigui = ng;
                                noidung = nd;
                                //Font thu= new Font("Arial", 10);

                                MessNhan.NguoiGui = nguoigui;
                                MessNhan.NoiDung = noidung;

                                DuaMessNhanLen(noidung);

                                MessageBox.Show("Người gửi: " + nguoigui + " ND: " + noidung);

                            }
                        }

                    }
                   
                    Console.WriteLine(Data.Substring(20, (Data.Length - 20)),"Thong bao");
                   
                    Data = "";
                    break;
            }
            
        }
        public string getValue(string src, string strBegin, char strEnd)
        {
            string[] strStart = Regex.Split(src, strBegin);
            string[] strResult = Regex.Split(strStart[1], strEnd.ToString());
            return strResult[0];
        }       
        public void _socket_onConnect(int ID)
        {

            _socket.sendDataLogin(_ymsg.GetChallenge(txtYID.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }
        public void HienThiDS()
        {
            IList<ArrayList> thu = Catchuoi(DSLienHe);
            foreach (ArrayList s in thu)
            {              
               treeView1.Nodes.Add(s[0].ToString()); 
            }
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                for (int j = 1; j < thu[i].Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(thu[i][j].ToString());
                    //frmChat tamp = new frmChat();
                    //tamp.Text = thu[i][j].ToString();                  
                    //ListChat.Add(tamp);
                    
                }
            }
           
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            //button1.Enabled = true;
            txtYID.Show();
            txtPass.Show();
            //txtPass.Text = "";
            //label2.Show();
            //label1.Show();
            btDangNhap.Show();
            //button2.Location = new Point(btDangNhap.Location.X, btDangNhap.Location.Y+35);
            //listBox1.Items.Clear();
           //_socket.onConnect = null;
            //_socket.onDataArrival = null;
            _socket.Close();
           // _socket = null;
           // _ymsg = null;

        }
       
        public void gui(string Mess, String Ten)
        {
            //byte[] data = Encoding.UTF8.GetBytes(Mess);
            //string kq = Encoding.UTF8.GetString(data);
            ///this.MdiChildren["Ten"].
             _socket.sendDataMess(_ymsg.GuiMess(txtYID.Text, Ten, Mess));
             foreach (frmChat tamp in ListChat)
             {
                 if (tamp.Text == Ten)
                 {
                     tamp.richTextBox1.Text += txtYID.Text+": "+ Mess+"\n";
                     break;
                 }
             }
        }
        void GuiTuDinhKy(string Mess, String Ten)
        {
            _socket.sendDataMess(_ymsg.GuiMess(txtYID.Text, Ten, Mess));
        }
        public frmChat TimNguoiThichHop()
        {
            frmChat kq = null;
            foreach (frmChat tamp in ListChat)
            {
                if (tamp.Text == MessNhan.NguoiGui)
                {
                    kq = tamp;
                    break;
                }
            }
            return kq;
        }




        public IList<ArrayList> Catchuoi(String DS)
        {        
            IList<ArrayList> t = new List<ArrayList>();
            IList<ArrayList> ListKQ = new List<ArrayList>();
            String[] Tamp = Regex.Split(DS, "À€319À€301À€318À€303À€318À€");
            DS = Tamp[0];
            while (DS.IndexOf("À€318À€300À€318À€65À€") > 0)
            {
               // DS = DS.Replace("À€317À€2", ";");
                DS = DS.Replace("À€317À€2À€301À€319À€303", ";");
                DS = DS.Replace("À€317À€2À€301À€319À€300À€319À€7À€", ";");
                DS = DS.Replace("À€302À€319À€300À€319À€7À€", ",");
                DS = DS.Replace("À€319À€301À€318À€300À€318À€65À€", ";");
                DS = DS.Replace("302À€318À€300À€318À€65À€", ";");
                DS = DS.Replace("À€301À€319À€300À€319À€7À€", ";");
                DS = DS.Replace("À€319À€300À€319À€7À€", ";");
                DS = DS.Replace("À€301À€319À€303", ";");
                DS = DS.Replace("À€223À€1", ";");

                //À€317À€2À€301À€319À€303À€319À€301À€318À€300À€318À€65À€
                DS = DS.Replace("À€319À€301À€318À€303À€318À€YMSG", ";");
                DS = DS.Replace("À€319À€301À€318À€303À€318À€", ";");
            }
            IList<String> thu = new List<String>();

            String[] kq = DS.Split(new char[] { ',', ';' });
            for (int i = 0; i < kq.Length - 1; i++)
            {

                if (((i + 1) < kq.Length) && (kq[i] == ""))
                {
                    ArrayList tamp = new ArrayList();
                    for (int j = i + 1; j < kq.Length; j++)
                    {
                        if (kq[j] == "")
                        {
                            t.Add(tamp);
                            break;
                        }
                        tamp.Add(kq[j]);
                    }
                }
            }
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i].Count == 0)
                    continue;
                ListKQ.Add(t[i]);
            }
            return ListKQ;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
           bool kt = true;
           if(!(KiemTraNode(treeView1.SelectedNode)))
           {
              
               foreach(frmChat tamp in ListChat)
               {  
                   if (tamp.Text == treeView1.SelectedNode.Text)
                   {
                       kt = false;
                       tamp.Activate();
                       tamp.MdiParent = this;
                       tamp.WindowState = FormWindowState.Maximized;
                                             
                       tamp.Show();
                       break;
                   }
               }           
           }
           if (kt)
           {
               frmChat tam = new frmChat();
               tam.Text = treeView1.SelectedNode.Text;
               tam.Activate();
               tam.MdiParent = this;
               tam.WindowState = FormWindowState.Maximized;
               tam.thu = new Mess(gui);
               tam.Show();
               ListChat.Add(tam);
           }
            
        }
        public bool KiemTraNode(TreeNode nod)
        {
            bool kq = false;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (nod.Text == treeView1.Nodes[i].Text)
                {
                    kq = true;
                    break;
                }
            }
            return kq;

        }
        public bool KiemTrafrmChat(String Text)
        {
            bool kq = true;
            foreach (frmChat tamp in ListChat)
            {
                if (tamp.Text == Text)
                {
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        void DuaDSLen(String Text)
        {
            AddDS(Text);
        }
        void AddDS(String Text)
        {
            if (this.treeView1.InvokeRequired)
            {
                SetTexCallback d = new SetTexCallback(AddDS);
                this.Invoke(d, new object[] { Text });
            }
            else
            {
                HienThiDS();
            }
        }
        void DuaMessNhanLen(String Text)
        {
            ThemMessNhan(Text);
        }
        void ThemMessNhan(String Text)
        {
            frmChat kq = TimNguoiThichHop();
            if (kq.InvokeRequired || this.InvokeRequired)
            {
                SetTexCallback d = new SetTexCallback(ThemMessNhan);
                this.Invoke(d, new object[] { Text });
            }
            else
            {
                kq.Activate();
                kq.MdiParent = this;
                kq.WindowState = FormWindowState.Maximized;
                kq.richTextBox1.Text += MessNhan.NguoiGui + ": " + MessNhan.NoiDung + "\n";
                kq.richTextBox1.ScrollToCaret();
                kq.Show();
            }
            
        }
        

        private void YahooChat_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        void thuWorker1()
        {
            Worker1.RunWorkerAsync();
        }


        void TuGianChetDi()
        {
            while (true)
            {
                GuiTuDinhKy("May chet di", "minhtruyet88");
                Thread.Sleep(1000);
            }
        }
        
    }
}
