using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRE
{
    using BLL;
    using Catalog;
    using Main;
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

            /*if (frmRight != null                    && basetype_of_frmRight != typeof(FrmMain)                    && basetype_of_frmRight != typeof(FrmLogin)                && frmRight.GetType().GetInterface("UTL.IAction") != null)
                {
                try
                {

                    //string Id_User = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId();
                    //if (Id_User == "") return false;
                    //string User_Name = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser();
                   
                    //neu user la admin hoac la member cua role sys_admin thi set full access
                    if (User_Name.ToUpper() == "ADMIN" && frmRight.Name == "Formpol_RoleUser_Mngr")
                    {
                        hasRight = true;

                        if (formUpdateWithToolbar != null
                            && (formUpdateWithToolbar.FormState == GoobizFrame.Windows.Forms.FormState.Edit
                            || formUpdateWithToolbar.FormState == GoobizFrame.Windows.Forms.FormState.Add))
                        {
                            return hasRight;
                        }

                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableAdd = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableDelete = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableEdit = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnablePrintPreview = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableQuery = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableTest = true;
                        ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableVerify = true;
                    }
                    else
                    {
                        Type _BaseType = frmRight.GetType().BaseType.GetInterface("GoobizFrame.Windows.Forms.IFormUserActions");
                        Type _Interface = frmRight.GetType().GetInterface("GoobizFrame.Windows.Forms.IFormUserActions");
                        if (_BaseType == typeof(GoobizFrame.Windows.Forms.IFormUserActions)
                                || _Interface == typeof(GoobizFrame.Windows.Forms.IFormUserActions))
                        {
                            //Tìm danh sách thao tác trên form hiện tại (ActiveMdiChild.Name) của user hiện tại (User_Name)
                            GoobizFrame.Windows.PlugIn.Authorization.Actions arrActions = RightHelpers.GetActions_ByUserName_RightSystemName(frmRight.Name);

                            //Đóng form neu nguoi dung khong co quyen thao tac nào
                            if (arrActions.Count == 0)
                            {
                                frmRight.Enabled = false;
                                GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ILLEGAL_RIGHT", new string[] { frmRight.Text });
                                ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).Denied = true;
                                hasRight = false;
                            }
                            else
                            {
                                hasRight = true;
                                if (formUpdateWithToolbar != null
                                    && (formUpdateWithToolbar.FormState == GoobizFrame.Windows.Forms.FormState.Edit
                                    || formUpdateWithToolbar.FormState == GoobizFrame.Windows.Forms.FormState.Add))
                                {
                                    return hasRight;
                                }
                                else
                                {
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableAdd = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableDelete = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableEdit = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnablePrintPreview = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableQuery = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableTest = false;
                                    ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableVerify = false;
                                }

                                //frmRight.Visible = true;
                                ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).UserActions = arrActions;

                                for (int i = 0; i < arrActions.Count; i++)
                                {
                                    switch (arrActions[i])
                                    {
                                        case "EnableAdd":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableAdd = true;
                                            break;
                                        case "EnableDelete":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableDelete = true;
                                            break;
                                        case "EnableEdit":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableEdit = true;
                                            break;
                                        case "EnablePrintPreview":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnablePrintPreview = true;
                                            break;
                                        case "EnableQuery":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableQuery = true;
                                            break;
                                        case "EnableTest":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableTest = true;
                                            break;
                                        case "EnableVerify":
                                            ((GoobizFrame.Windows.Forms.IFormUserActions)frmRight).EnableVerify = true;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(
                    //                    System.Windows.Forms.MessageBoxIcon.Warning,
                    //                    ex.Message, ex.ToString());
                    hasRight = false;
                }*/

            System.GC.Collect();
            return hasRight;
        }
    }
}