using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer2
{
    public class CertificationManager
    {
        private string _id;
        private string _pw;
        private string _serverIP;

        private static CertificationManager _instance;
        public static CertificationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CertificationManager();
                return _instance;
            }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Pw
        {
            get { return _pw; }
            set { _pw = value; }
        }
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        public CertificationManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            this._id = string.Empty;
            this._pw = string.Empty;
            this._serverIP = string.Empty;
        }

        public bool GetCertificationInfo()
        {
            if (GetFromRegistry() == true)
                return true;

            CertificationDlg dlg = new CertificationDlg();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._id = dlg.Id;
                this._pw = dlg.Pw;
                this._serverIP = dlg.Ip;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MIDAS\LogAnalyzer");
                if (key != null)
                {
                    key.SetValue("ID", this._id);
                    key.SetValue("PW", this._pw);
                    key.SetValue("IP", this._serverIP);
                }
            }

            dlg.Dispose();
            dlg.Close();

            return (_id != string.Empty && _pw != string.Empty && _serverIP != string.Empty);
        }

        private bool GetFromRegistry()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MIDAS\LogAnalyzer");
            if (key == null)
                return false;

            string[] valuesNames = key.GetValueNames();
            if (valuesNames.Contains("ID"))
                this._id = key.GetValue("ID").ToString();
            if (valuesNames.Contains("PW"))
                this._pw = key.GetValue("PW").ToString();
            if (valuesNames.Contains("IP"))
                this._serverIP = key.GetValue("IP").ToString();

            return (_id != string.Empty && _pw != string.Empty && _serverIP != string.Empty);
        }
    }
}
