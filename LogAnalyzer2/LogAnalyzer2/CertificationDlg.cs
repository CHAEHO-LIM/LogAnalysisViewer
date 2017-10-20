using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogAnalyzer2
{
    public partial class CertificationDlg : Form
    {
        private string _id;
        private string _pw;
        private string _ip;

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
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public CertificationDlg()
        {
            InitializeComponent();
        }

        private void CertificationDlg_Load(object sender, EventArgs e)
        {
            _id = string.Empty;
            _pw = string.Empty;
            _ip = string.Empty;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this._id = this.textBoxID.Text;
            this._pw = this.textBoxPassword.Text;
            this._ip = this.textBoxServerIP.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


    }
}
