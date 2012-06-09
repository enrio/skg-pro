using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
   public class UserDataLayer
    {
        DataLayer.KetNoiCSDL Ketnoi = new KetNoiCSDL();
        public DataTable LayToanBoUSer()
        {
            String SQL = "SELECT * FROM dbo.NguoiDung";
            //Ketnoi.Clear();
            Ketnoi.Load(SQL);
            return Ketnoi;

        }
    }
}
