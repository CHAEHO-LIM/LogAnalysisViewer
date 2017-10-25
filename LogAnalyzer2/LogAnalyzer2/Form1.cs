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

    public partial class MainForm : Form
    {
        int nProduct = 0;
        int nCountry = 0;
        string sDateTo = "";
        string sDateFrom = "";
        bool buttonUpdateStatus = false;

        public MainForm()
        {
            InitializeComponent();
        
            if (Constants.FLG_LOCAL)
            {
                MessageBox.Show("ローカル環境で実行します。\r\nサーバーには接続しません。",
                    "注意！",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CertificationManager.Instance.GetCertificationInfo() == false)
            {
                this.Close();
                return;
            }

            this.dateTimePickerFrom.Value = DateTime.Now.AddDays(-1);
            this.dateTimePickerTo.Value = DateTime.Now;
            this.comboBoxCountry.SelectedIndex = 0;
            this.comboBoxProduct.SelectedIndex = 0;

            this.listViewResult.View = View.Details;
            this.listViewResult.GridLines = true;
            this.listViewResult.FullRowSelect = true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonUpdateSet();

            buttonUpdate.Enabled = false;
            buttonUpdateStatus = false;

            InputParam param = GetInputParam();

            if (DBConnection.Instance.Execute(param) == false)
            {
                MessageBox.Show("Database is not connected. Try to again.");
            }
            else
            {
                MessageBox.Show("Database Connection is Success!");
                buttonUpdate.Enabled = true;
                buttonUpdateStatus = true;
            }

            this.progressBar1.Value = 0;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            InputParam param = GetInputParam();

            ResultListView listVeiw = new ResultListView(param, this.listViewResult);

            if (this.radioButtonUseLog.Checked == true)
            {
                if (this.radioButtonByVersion.Checked == true)
                {
                    listVeiw.ShowUseLogByBersion(param);
                }
                else if (this.radioButtonByCompany.Checked == true)
                {
                    listVeiw.ShowUseLogByCompany(param);
                }
            }
            else if (this.radioButtonFunctionLog.Checked == true)
            {
                if (this.radioButtonByVersion.Checked == true)
                {
                    listVeiw.ShowFunctionLogByVersion(param);
                }
                else if (this.radioButtonByCompany.Checked == true)
                {
                    listVeiw.ShowFunctionLogByCompany(param);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
//            if (DBConnection.Instance.IsDbConnected() == true && MessageBox.Show("Do you want to save the database?", "caption", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            if (Constants.FLG_LOCAL == false && DBConnection.Instance.IsDbConnected() == true && MessageBox.Show("Do you want to save the database?", "caption", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                DBConnection.Instance.SaveDatabase();
                this.progressBar1.Value = 0;
            }
        }

        private InputParam GetInputParam()
        {
            //test
            InputParam param = new InputParam();
            param.strDateTimePickerFrom = this.dateTimePickerFrom.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            param.strDateTimePickerTo = this.dateTimePickerTo.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            param.strProductName = this.comboBoxProduct.SelectedItem.ToString();
            param.strCountry = this.comboBoxCountry.SelectedItem.ToString();
            param.progressBar = this.progressBar1;
            param.logType = this.radioButtonUseLog.Checked == true ? InputParam.eLogType.kLogUseType : InputParam.eLogType.kLogFunctionType;
            param.resultType = this.radioButtonByVersion.Checked == true ? InputParam.eResultType.kByVersionType : InputParam.eResultType.kByCompanyType;
            param.strFilterCompany = this.textBoxCompanyName.Text;
            param.strFilterUserID = this.textBoxUserID.Text;

            return param;
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonUpdateCheck();
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonUpdateCheck();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            buttonUpdateCheck();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            buttonUpdateCheck();
        }

        private void buttonUpdateCheck()
        {
            if (buttonUpdateStatus)
            {
                int Prd=comboBoxProduct.SelectedIndex*10;
                int Comp = comboBoxCountry.SelectedIndex;
                string sTo=dateTimePickerTo.Value.ToString("yyyy-MM-dd").Substring(0, 10);
                string sFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd").Substring(0, 10);

                if( nProduct==Prd &&  nCountry==Comp && sDateTo==sTo && sDateFrom==sFrom)
                    buttonUpdate.Enabled = true;
                else
                    buttonUpdate.Enabled = false;
            }
        }

        private void buttonUpdateSet()
        {
            nProduct = comboBoxProduct.SelectedIndex * 10;
            nCountry = comboBoxCountry.SelectedIndex;
            sDateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            sDateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd").Substring(0, 10);
        }
    }

    static class Constants
    {
        public const bool FLG_LOCAL = false;
        //        public const bool FLG_LOCAL = false;
    }
}


