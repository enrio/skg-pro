using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Hasher
{
    using Microsoft.Win32;
    using System.Windows.Forms;
    using System.Security.AccessControl;

    /// <summary>
    /// Registry processing
    /// </summary>
    public class Registri
    {
        public const string STR_RUN = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public bool ShowError { set; get; }
        public string Subkey { set; get; }
        public RegistryKey CurrKey { set; get; }

        private readonly string _productName = Application.ProductName.ToUpper();
        private readonly string _startupPath = Application.StartupPath;

        /// <summary>
        /// Set local
        /// </summary>
        /// <param name="isLocal">Local</param>
        public Registri(bool isLocal = true)
        {
            ShowError = false;
            Subkey = @"SOFTWARE\" + _productName;
            CurrKey = isLocal ? Registry.LocalMachine : Registry.CurrentUser;
        }

        /// <summary>
        /// Open subkey
        /// </summary>
        /// <param name="keyName">Key name</param>
        /// <returns></returns>
        private RegistryKey OpenSubKey(string keyName)
        {
            return CurrKey.OpenSubKey(keyName,
                       RegistryKeyPermissionCheck.ReadWriteSubTree,
                       RegistryRights.FullControl);
        }

        /// <summary>
        /// Set autorun
        /// </summary>
        /// <returns></returns>
        public bool Autorun()
        {
            try
            {
                var rk = Registry.CurrentUser.OpenSubKey(STR_RUN,
                                     RegistryKeyPermissionCheck.ReadWriteSubTree,
                                     RegistryRights.FullControl);

                rk.SetValue(_productName, String.Format(@"{0}\{1}.exe", _startupPath, _productName));
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Writing registry {0}", _productName));
                return false;
            }
        }

        /// <summary>
        /// Read key name
        /// </summary>
        /// <param name="keyName">Key name</param>
        /// <returns></returns>
        public string Read(string keyName)
        {
            using (RegistryKey sk1 = OpenSubKey(Subkey))
            {
                if (sk1 == null)
                    return null;
                else
                {
                    try
                    {
                        return (string)sk1.GetValue(keyName.ToUpper());
                    }
                    catch (Exception e)
                    {
                        ShowErrorMessage(e, String.Format("Reading registry {0}", keyName.ToUpper()));
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Write key name
        /// </summary>
        /// <param name="keyName">Key name</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool Write(string keyName, object value)
        {
            try
            {
                RegistryKey sk1 = OpenSubKey(Subkey) ?? CurrKey.CreateSubKey(Subkey);
                sk1.SetValue(keyName.ToUpper(), value);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Writing registry {0}", keyName.ToUpper()));
                return false;
            }
        }

        /// <summary>
        /// Delete key
        /// </summary>
        /// <param name="keyName">Key name</param>
        /// <returns></returns>
        public bool DeleteKey(string keyName)
        {
            try
            {
                using (RegistryKey sk1 = CurrKey.CreateSubKey(Subkey))
                {
                    if (sk1 == null)
                        return true;
                    else
                        sk1.DeleteValue(keyName);
                }
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Deleting SubKey {0}", Subkey));
                return false;
            }
        }

        /// <summary>
        /// Delete subkey tree
        /// </summary>
        /// <returns></returns>
        public bool DeleteSubKeyTree()
        {
            try
            {
                using (RegistryKey sk1 = OpenSubKey(Subkey))
                {
                    if (sk1 != null)
                        CurrKey.DeleteSubKeyTree(Subkey);
                }
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Deleting SubKey {0}", Subkey));
                return false;
            }
        }

        /// <summary>
        /// Subkey count
        /// </summary>
        /// <returns></returns>
        public int SubKeyCount()
        {
            try
            {
                using (RegistryKey sk1 = CurrKey.OpenSubKey(Subkey))
                {
                    if (sk1 != null)
                        return sk1.SubKeyCount;
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Retrieving subkey of {0}", Subkey));
                return 0;
            }
        }

        /// <summary>
        /// Value count
        /// </summary>
        /// <returns></returns>
        public int ValueCount()
        {
            try
            {
                using (RegistryKey sk1 = CurrKey.OpenSubKey(Subkey))
                {
                    if (sk1 != null)
                        return sk1.ValueCount;
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, String.Format("Retrieving subkey of {0}", Subkey));
                return 0;
            }
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="title">Title</param>
        private void ShowErrorMessage(Exception e, string title)
        {
            if (ShowError == true)
                MessageBox.Show(e.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}