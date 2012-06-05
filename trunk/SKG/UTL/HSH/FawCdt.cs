using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace UTL.HSH
{
    public class FawCdt
    {
        public const string STR_RUN = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public bool ShowError { set; get; }
        public string SubKey { set; get; }
        public RegistryKey CurrKey { set; get; }

        public FawCdt(bool isLocal = true)
        {
            ShowError = false;
            SubKey = @"SOFTWARE\" + Application.ProductName.ToUpper();
            CurrKey = isLocal ? Registry.LocalMachine : Registry.CurrentUser;
        }

        private RegistryKey OpenSubKey(string name)
        {
            return CurrKey.OpenSubKey(name,
                       RegistryKeyPermissionCheck.ReadWriteSubTree,
                       RegistryRights.FullControl);
        }

        public bool Autorun()
        {
            string key = Application.ProductName.ToUpper();
            try
            {
                var rk = Registry.CurrentUser.OpenSubKey(STR_RUN,
                                     RegistryKeyPermissionCheck.ReadWriteSubTree,
                                     RegistryRights.FullControl);

                rk.SetValue(key, String.Format(@"{0}\{1}.exe", Application.StartupPath, key));
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Writing registry {0}", key));
                return false;
            }
        }

        public string Read(string KeyName)
        {
            RegistryKey sk1 = OpenSubKey(SubKey);

            if (sk1 == null) return null;
            else
            {
                try
                {
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e, String.Format("Reading registry {0}", KeyName.ToUpper()));
                    return null;
                }
            }
        }

        public bool Write(string KeyName, object Value)
        {
            try
            {
                RegistryKey sk1 = OpenSubKey(SubKey) ?? CurrKey.CreateSubKey(SubKey);
                sk1.SetValue(KeyName.ToUpper(), Value);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Writing registry {0}", KeyName.ToUpper()));
                return false;
            }
        }

        public bool DeleteKey(string KeyName)
        {
            try
            {
                RegistryKey sk1 = CurrKey.CreateSubKey(SubKey);
                if (sk1 == null) return true;
                else sk1.DeleteValue(KeyName);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Deleting SubKey {0}", SubKey));
                return false;
            }
        }

        public bool DeleteSubKeyTree()
        {
            try
            {
                RegistryKey sk1 = OpenSubKey(SubKey);
                if (sk1 != null) CurrKey.DeleteSubKeyTree(SubKey);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Deleting SubKey {0}", SubKey));
                return false;
            }
        }

        public int SubKeyCount()
        {
            try
            {
                RegistryKey sk1 = CurrKey.OpenSubKey(SubKey);

                if (sk1 != null) return sk1.SubKeyCount;
                else return 0;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Retrieving subkey of {0}", SubKey));
                return 0;
            }
        }

        public int ValueCount()
        {
            try
            {
                RegistryKey sk1 = CurrKey.OpenSubKey(SubKey);

                if (sk1 != null) return sk1.ValueCount;
                else return 0;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Retrieving subkey of {0}", SubKey));
                return 0;
            }
        }

        private void ShowErrorMessage(Exception e, string title)
        {
            if (ShowError == true)
                MessageBox.Show(e.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}