using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRE
{
    using BLL;
    using Catalog;
    using System.Data;
    using System.Windows.Forms;

    /// <summary>
    /// Kiểm tra quyền của người dùng, nhóm người dùng
    /// </summary>
    public class RightHelpers
    {
        public static bool Contains(string Right_Name)
        {
            try
            {
                var tmp = BaseBLL._pol_RightBLL.Select(Right_Name);
                if (tmp != null) return true;
                return false;

            }
            catch { return false; }
        }

        public static bool CheckUserRightAction(Form frmRight)
        {
            if (frmRight == null) return false;

            bool hasRight = false;
            FrmBase formUpdateWithToolbar = null;

            Type basetype_of_frmRight = frmRight.GetType().BaseType;

            if (basetype_of_frmRight == typeof(FrmBase))
                formUpdateWithToolbar = (FrmBase)frmRight;

            // Nếu không co item quyền (chức năng) trong Pol_Right thì thêm vào
            try
            {
                if (!RightHelpers.Contains(frmRight.Name))
                {
                    BaseBLL._pol_RightBLL.Insert(frmRight.Name, frmRight.Name, frmRight.Text);
                }
            }
            catch (Exception ex)
            {
                //TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(
                //     System.Windows.Forms.MessageBoxIcon.Warning,
                //    ex.Message, ex.ToString());
            }

            return hasRight;
        }
    }
}