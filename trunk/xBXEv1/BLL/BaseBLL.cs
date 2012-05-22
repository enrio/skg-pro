using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// Base static class Bussiness Logic Layer
    /// </summary>
    public static class BaseBLL
    {
        public static Pol_RightBLL _pol_RightBLL = new Pol_RightBLL();
        public static Pol_RoleBLL _pol_RoleBLL = new Pol_RoleBLL();
        public static Pol_UserBLL _pol_UserBLL = new Pol_UserBLL();
        public static Tra_GroupBLL _tra_GroupBLL = new Tra_GroupBLL();

        public static void CreateDataPol_Right()
        {
        }

        public static void CreateDataPol_Role()
        {
        }

        public static void CreateDataPol_User()
        {
        }

        public static void CreateDataTra_Group()
        {
        }
    }
}