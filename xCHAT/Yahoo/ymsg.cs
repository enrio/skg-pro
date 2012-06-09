using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;

namespace Yahoo
{
   public class ymsg
    {
        private const string AE = "À€";
        private string Sessionid = new String((char)0x0, 4);

        private string Assemble(int Length)
        {
            //new string((char)0x0,2)la dung de in 2 ky tu nhu vay
            return "YMSG" + (char)0x0 + (char)0x10 + new string((char)0x0, 2) + (char)(Length / 256) + (char)(Length % 256) + (char)0x0;
        }

        public string GetChallenge(string Username)
        {
            string Packet = null;
            //Cong vao packet "1" va AE, cong vao packet Username va AE
            Packet = this.addElement("1", Username);
            //Day la packet gui di de lay chuoi Challenge
            string stringTmp = Assemble(Username.Length + 5) + ((char)(0x57)).ToString() + new string((char)0x0, 8) + Packet;
            return stringTmp;
        }

        public string Login(string Username, string Seed, string Y, string T, string Crumb, bool Invisible)
        {
            string Packet = null;
            Packet = this.addElement("1", Username)
                   + this.addElement("0", Username)
                   + this.addElement("277", Y)
                   + this.addElement("278", T)
                   + this.addElement("307", MAC64(MD5(Crumb + Seed)))
                   + this.addElement("244", "4194239")
                   + this.addElement("2", Username)
                   + this.addElement("2", "1")
                   + this.addElement("98", "us")
                   + this.addElement("135", "9.0.0.1389");

            string stringTmp = Assemble(Packet.Length) + "T" +
                (Invisible ? new String((char)0x0, 3) + ((char)(0xc)).ToString() + new String((char)0x0, 4) :
                "Z" + "U" + ((char)(0xAA)).ToString() + "U" +
                new String((char)0x0, 4)) + Packet;
            return stringTmp;
        }
        #region "Tùy biến cho packet"
        //Cong mot chuoi s voi AE("À€")
        public string addString(string s)
        {
            return s + AE;
        }
        //Cong key voi EA va value voi AE voi muc dic tao khoang cach ra thoi
        public string addElement(string key, string value)
        {
            return addString(key) + addString(value);
        }
        #endregion
        #region "Mã hóa MD5 và BASE64"
        //Ma hoa 
        private string MD5(string inputStr)
        {
            string stringTmp = null;
            //Lay ma bam cua inputStr
            byte[] scB = ((HashAlgorithm)(CryptoConfig.CreateFromName("MD5")))
                .ComputeHash(UnicodeEncoding.Default.GetBytes(inputStr));
            string h1 = BitConverter.ToString(scB).Replace("-", null);
            try
            {
                for (int i = 1; i <= h1.Length; i += 2)
                {
                    byte[] newByte = new byte[] { (byte)int.Parse(h1.Substring(i - 1, 2), NumberStyles.HexNumber) };
                    stringTmp += Encoding.GetEncoding(1252).GetString(newByte);
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Exception MD5 :" + ex.Message); }
            return stringTmp;
        }

        private string MAC64(string inputStr)
        {
            return Convert.ToBase64String(Encoding.Default.
                GetBytes(inputStr)).Replace("+", ".")
                .Replace("/", "_").Replace("=", "-");
        }
        public string GuiMess(string uid, string target, string Mess)
        {
            //$status = chr(0x5A).chr(0x55).chr(0xAA).chr(0x56).chr(0x0).chr(0x0).chr(0x0).chr(0x0);
            string Status = new String((char)(0x0),8);
            String Packet = "";
            Packet = this.addElement("1", uid)+
                     this.addElement("0", uid) +
                     this.addElement("5", target) +
                     
                     this.addElement("14", Mess);
            return Assemble(Packet.Length)+((char)(0x06)).ToString()+Status+Packet;
        }
        #endregion
    }
}
