using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRE
{
    using BLL;
    using UTL;
    using Catalog;
    using Main;
    using System.Data;
    using System.Windows.Forms;

    /// <summary>
    /// Kiểm tra quyền của người dùng, nhóm người dùng
    /// </summary>
    public class RightHelpers
    {
        static DataSet dsPol_Action_User = new DataSet();

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

        public static Actions GetActions_ByUserName_RightSystemName(string right_system_name)
        {
            try
            {
                var objActions = new Actions();

                dsPol_Action_User = new DataSet();
                //dsPol_Action_User.ReadXml(xmlPol_Action_User);

                if (dsPol_Action_User != null && dsPol_Action_User.Tables[0].Rows.Count > 0)
                {
                    DataRow[] sdrPol_Action_User = dsPol_Action_User.Tables[0].Select(string.Format("Right_System_Name = '{0}'", right_system_name));
                    for (int j = 0; j < sdrPol_Action_User.Length; j++)
                    {
                        if (!objActions.Contains("" + sdrPol_Action_User[j]["Action_Name"]))
                            objActions.Add("" + sdrPol_Action_User[j]["Action_Name"]);
                    }
                }

                dsPol_Action_User = null;
                return objActions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
                return null;
            }
        }

        public static bool CheckUserRightAction(Form frmRight)
        {
            if (frmRight == null) return false;

            bool hasRight = false;
            FrmBase frmBase = null;

            Type frmRightType = frmRight.GetType().BaseType;

            if (frmRightType == typeof(FrmBase))
                frmBase = (FrmBase)frmRight;

            try
            {
                // Nếu không co item quyền (chức năng) trong Pol_Right thì thêm vào
                if (!RightHelpers.Contains(frmRight.Name))
                    BaseBLL._pol_RightBLL.Insert(frmRight.Name, frmRight.Name, frmRight.Text);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }

            if (frmRight != null
                && frmRightType != typeof(FrmMain)
                && frmRightType != typeof(FrmLogin)
                && frmRight.GetType().GetInterface("UTL.IAction") != null)
                try
                {
                    string acc = BasePRE._sss.User.Acc.ToUpper();
                    if (acc == "ADMIN" && frmRight.Name == typeof(FrmPol_UserRole).Name)
                    {
                        hasRight = true;

                        if (frmBase != null && (frmBase.FormState == FrmBase.State.Edit
                            || frmBase.FormState == FrmBase.State.Add))
                            return hasRight;

                        ((IFormUserActions)frmRight).EnableAdd = true;
                        ((IFormUserActions)frmRight).EnableDelete = true;
                        ((IFormUserActions)frmRight).EnableEdit = true;
                        ((IFormUserActions)frmRight).EnablePrintPreview = true;
                        ((IFormUserActions)frmRight).EnableQuery = true;
                        ((IFormUserActions)frmRight).EnableTest = true;
                        ((IFormUserActions)frmRight).EnableVerify = true;
                    }
                    else
                    {
                        Type _BaseType = frmRight.GetType().BaseType.GetInterface("UTL.IFormUserActions");
                        Type _Interface = frmRight.GetType().GetInterface("UTL.IFormUserActions");
                        if (_BaseType == typeof(IFormUserActions) || _Interface == typeof(IFormUserActions))
                        {
                            // Tìm danh sách thao tác trên form hiện tại (ActiveMdiChild.Name) của user hiện tại (User_Name)
                            UTL.Actions arrActions = RightHelpers.GetActions_ByUserName_RightSystemName(frmRight.Name);

                            // Đóng form nếu người dùng không có quyền thao tác nào
                            if (arrActions.Count == 0)
                            {
                                frmRight.Enabled = false;
                                MessageBox.Show("SYS_ILLEGAL_RIGHT", frmRight.Text);
                                ((IFormUserActions)frmRight).Denied = true;
                                hasRight = false;
                            }
                            else
                            {
                                hasRight = true;
                                if (frmBase != null && (frmBase.FormState == FrmBase.State.Edit
                                    || frmBase.FormState == FrmBase.State.Add))
                                    return hasRight;
                                else
                                {
                                    ((IFormUserActions)frmRight).EnableAdd = false;
                                    ((IFormUserActions)frmRight).EnableDelete = false;
                                    ((IFormUserActions)frmRight).EnableEdit = false;
                                    ((IFormUserActions)frmRight).EnablePrintPreview = false;
                                    ((IFormUserActions)frmRight).EnableQuery = false;
                                    ((IFormUserActions)frmRight).EnableTest = false;
                                    ((IFormUserActions)frmRight).EnableVerify = false;
                                }

                                // frmRight.Visible = true;
                                ((IFormUserActions)frmRight).UserActions = arrActions;
                                for (int i = 0; i < arrActions.Count; i++)
                                {
                                    switch (arrActions[i])
                                    {
                                        case "EnableAdd":
                                            ((IFormUserActions)frmRight).EnableAdd = true;
                                            break;
                                        case "EnableDelete":
                                            ((IFormUserActions)frmRight).EnableDelete = true;
                                            break;
                                        case "EnableEdit":
                                            ((IFormUserActions)frmRight).EnableEdit = true;
                                            break;
                                        case "EnablePrintPreview":
                                            ((IFormUserActions)frmRight).EnablePrintPreview = true;
                                            break;
                                        case "EnableQuery":
                                            ((IFormUserActions)frmRight).EnableQuery = true;
                                            break;
                                        case "EnableTest":
                                            ((IFormUserActions)frmRight).EnableTest = true;
                                            break;
                                        case "EnableVerify":
                                            ((IFormUserActions)frmRight).EnableVerify = true;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    hasRight = false;
                }

            GC.Collect();
            return hasRight;
        }
    }
}