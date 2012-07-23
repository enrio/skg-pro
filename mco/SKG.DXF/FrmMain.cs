﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 22:07
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.DXF
{
    using BLL;
    using Home.Sytem;
    using Help.Infor;
    using SKG.Extend;
    using SKG.Hasher;
    using DevExpress.XtraEditors;

    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();

            //SkinHelper.InitSkinGallery(rgbMain, true);

            Global.Session = new Session();
            BeforeLogon();

            // Thông tin server, đồng hồ
            var cnn = (new Pol_ActionBLL()).Connection();
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]", cnn.DataSource, cnn.Database);
            bsiUser.Caption = null;
            bsiTimer.Caption = null;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var a = Global.Service.GetPlugins();
            ribbon.LoadMenu(a, this);

            // Check license
            var key = (new Registri()).Read("License");
            var ok = License.IsLincense(key);
            if (ok == LicState.None)
            {
                Extend.ShowRight<FrmLicense>(this);
                return;
            }
            //else bbiRegistry.Enabled = false;

            if (!Sample.CheckDb())
            {
                Extend.ShowRight<FrmSetting>(this);
                return;
            }
            //else bbiSetting.Visibility = BarItemVisibility.Never;

            Login();
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (Global.Session.Current != null)
            {
                bsiTimer.Caption = Global.Session.Current.ToStringVN();
                Global.Session.Current = Global.Session.Current.AddSeconds(1);
            }
        }

        /// <summary>
        /// Sau khi đăng nhập, hiện menu, thay đổi nút đăng nhập -> đăng xuất
        /// </summary>
        private void AfterLogon()
        {
            Extend.VisibleMenuParentForm(this);

            //bbiLogin.LargeGlyph = Properties.Resources.logout;
            //bbiLogin.Caption = Properties.Settings.Default.Logout;
            bsiUser.Caption = Global.Session.User.Name;

            // Hiện form mặc định
            var d = Global.Session.Default;
            foreach (var r in d)
            {
                if (r.Code == null) continue;
                var a = typeof(SKG.DXF.Home.Grant.Level2).Namespace;
                var t = Type.GetType(String.Format("{0}.{1}", a, r.Code));
                if (t == null)
                {
                    a = typeof(SKG.DXF.Home.Catalog.Level2).Namespace;
                    t = Type.GetType(String.Format("{0}.{1}", a, r.Code));
                }
                if (t == null) t = Type.GetType(r.Code);
                if (t == null) continue;

                var frm = Activator.CreateInstance(t) as FrmInput;
                if (frm != null) frm.ShowRight(this);
            }

            // Tài khoản là admin hoặc thuộc nhóm Quản trị mới có quyền phân quyền
#if DEBUG
            //rpgPermission.Visible = true;
            //bbiSetting.Visibility = BarItemVisibility.Always;
#else
            var b = Global.Session.GetUserRole("QT");
            var c = Global.Session.User.Acc.ToUpper();

            if (b != null || c == "ADMIN")
            {
                //rpgPermission.Visible = true;
                //bbiSetting.Visibility = BarItemVisibility.Always;
            }
            else
            {
                //rpgPermission.Visible = false;
                //bbiSetting.Visibility = BarItemVisibility.Never;
            }
#endif
        }

        /// <summary>
        /// Trước khi đăng nhập, ẩn menu, thay đổi nút đăng xuất -> đăng nhập
        /// </summary>
        private void BeforeLogon()
        {
            Extend.VisibleMenuParentForm(this, false);

            //bbiLogin.LargeGlyph = Properties.Resources.login;
            //bbiLogin.Caption = Properties.Settings.Default.Login;

            bsiUser.Caption = null;
            //rpgPermission.Visible = false;
        }

        /// <summary>
        /// Thực hiện đăng nhập hệ thống
        /// </summary>
        private void Login()
        {
            try
            {
                Extend.CloseAllChildrenForm(this);

                var x = typeof(FrmLogin);
                var frm = (FrmLogin)Extend.GetMdiChilden(this, x.FullName);
                if (frm == null) frm = new FrmLogin() { MdiParent = this };

                frm.BeforeLogon += BeforeLogon;
                frm.AfterLogon += AfterLogon;

                frm.Show();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, Text); }
        }
    }
}