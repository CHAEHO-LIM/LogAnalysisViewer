using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using System.Collections;

namespace LogAnalyzer2
{

    public partial class MainForm : Form
    {
        int nProduct = 0;
        int nCountry = 0;
        string sDateTo = "";
        string sDateFrom = "";

        private  string strSearchLang;
        private  string strSearchProg;

        bool buttonUpdateStatus = false;

        //bool MouseMoveFlg = false;

        public MainForm()
        {
            InitializeComponent();
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
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            InputParam param = GetInputParam();

            param.strSearchLang = strSearchLang;
            param.strSearchProg = strSearchProg;
            if (buttonUpdateStatus)
            {
                DBConnection DB_Conn = new DBConnection();
                DB_Conn.SaveDatabase_LangProg(param);
            }

            TimeSpan tSpan = DateTime.Now - dateTimePickerTo.Value;

            String s = "";
            if (tSpan.Seconds < 0)
            {
                s = "Please specify the date until today.\n";
            }

            DateTime tNow = DateTime.Now;

            tSpan = dateTimePickerFrom.Value - tNow.AddMonths(-3);
            if (tSpan.Days < 0)
            {
                s = s + "Please specify the date up to 3 months ago.\n";
            }

            tSpan = dateTimePickerTo.Value - dateTimePickerFrom.Value;
            if (tSpan.Seconds < 0)
            {
                s = s + "The start and end periods are reversed.";
            }

            if (s.Length > 0)
            {
                MessageBox.Show(s);
                return;
            }

            buttonUpdateSet();

            buttonUpdate.Enabled = false;
            buttonUpdateStatus = false;

            if (DBConnection.Instance.Execute(param) == false)
            {
                MessageBox.Show("Database is not connected. Try to again.");
            }
            else
            {
                MessageBox.Show("Database Connection is Success!");
                buttonUpdate.Enabled = true;
                buttonUpdateStatus = true;

                strSearchLang = param.strSearchLang;
                strSearchProg = param.strSearchProg;
            }

            this.progressBar1.Value = 0;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            InputParam param = GetInputParam();

            dataGridViewResult.Columns.Clear();
            ResultGridView gridVeiw = new ResultGridView(param, this.dataGridViewResult);

            this.dataGridViewResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dataGridViewResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            Constants.bDetailFlg = false;
            if (this.radioButtonUseLog.Checked == true)
            {
                if (this.radioButtonByVersion.Checked == true)
                {
                    gridVeiw.ShowUseLogByBersion(param);
                    Constants.nViewType = 1;
                }
                else if (this.radioButtonByCompany.Checked == true)
                {
                    gridVeiw.ShowUseLogByCompany(param);
                    Constants.bDetailFlg = true;
                    Constants.nViewType = 2;
                }
            }
            else if (this.radioButtonFunctionLog.Checked == true)
            {
                if (this.radioButtonByVersion.Checked == true)
                {
                    gridVeiw.ShowFunctionLogByVersion(param);
                    Constants.nViewType = 3;
                }
                else if (this.radioButtonByCompany.Checked == true)
                {
                    gridVeiw.ShowFunctionLogByCompany(param);
                    Constants.bDetailFlg = true;
                    Constants.nViewType = 4;
                }
            }

            // 自動でサイズを設定するのは、行や列を追加したり、セルに値を設定した後にする。
            this.dataGridViewResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;


        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( Constants.bFirstConnect )
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
                int Prd = comboBoxProduct.SelectedIndex * 10;
                int Comp = comboBoxCountry.SelectedIndex;
                string sTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd").Substring(0, 10);
                string sFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd").Substring(0, 10);

                if (nProduct == Prd && nCountry == Comp && sDateTo == sTo && sDateFrom == sFrom)
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


        private void buttonSave_Click(object sender, EventArgs e)
        {

            // Excel 使用には、プロジェクト－参照の追加－COM－「Microsoft Excel 15.0 Object Library」を選択 

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files|*.xls*|All files|*.*";
            saveFileDialog1.Title = "Save an Excel File";

            string ExcelFileName = "";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExcelFileName = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }

            Excel.Application ExcelApp = null;
            Excel.Workbook ExcelWorkBook = null;
            Excel.Worksheet ExcelWorkSheet = null;

            try
            {
                //Excelシートのインスタンスを作る
                ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelWorkBook = ExcelApp.Workbooks.Add();
                ExcelWorkSheet = ExcelWorkBook.Sheets[1];
                ExcelWorkSheet.Select(Type.Missing);

                ExcelApp.Visible = false;

                // エクセルファイルにデータをセットする
                for (int i = 0; i < dataGridViewResult.Columns.Count; i++)
                {
                    // Excelのcell指定
                    ExcelWorkSheet.Cells[1, i + 1] = dataGridViewResult.Columns[i].Name.ToString();
                }

                for (int i = 0; i < dataGridViewResult.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewResult.Columns.Count; j++)
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 1] = dataGridViewResult.Rows[i].Cells[j].Value;
                    }
                }

                //excelファイルの保存
                ExcelApp.DisplayAlerts = false;
                ExcelWorkBook.SaveAs(@ExcelFileName);
                ExcelWorkBook.Close(false);
                ExcelApp.Quit();
                MessageBox.Show("Saved Successful!");
            }
            finally
            {
                //Excelのオブジェクトを開放し忘れているとプロセスが落ちないため注意
                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(ExcelWorkBook);
                Marshal.ReleaseComObject(ExcelApp);
                ExcelWorkSheet = null;
                ExcelWorkBook = null;
                ExcelApp = null;

                GC.Collect();
            }

        }

        private void RegistrySet()
        {
            // レジストリに記録
            DateTime dtToday = DateTime.Today;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MIDAS\LogAnalyzer");
            if (key != null)
            {
                key.SetValue("GetDate", dtToday.ToString("yyyy-MM-dd"));
            }
        }

        private void dataGridViewResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            if (Constants.bDetailFlg)
            {
                foreach (DataGridViewCell dataGV in dataGridViewResult.SelectedCells)
                {
                    string sID = "";
                    sID = dataGridViewResult.Rows[dataGV.RowIndex].Cells[2].Value.ToString();

                    string sComp = "";
                    sComp = dataGridViewResult.Rows[dataGV.RowIndex].Cells[1].Value.ToString();

                    DetailAnalysis DetAnalysis = new DetailAnalysis();
                    DetAnalysis.SetDetailAnalysis(sID, sComp);
                }
            }

        }
/*
        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
//            MessageBox.Show("TEST");
        }

        private void dataGridViewResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
*/
    }
    static class Constants
    {
//        static public bool FLG_UPDATE = true;   // ローカル開発用
//        static public bool FLG_UPDATE = false;   // ローカル開発用
        //        public const bool FLG_UPDATE = false;

        static public bool bDetailFlg = false;
        static public bool bFirstConnect = false;
        static public string sSort = "";
        static public short nViewType = 0;
        static public bool bSortAscending = false;

        static public bool[] ReadFlg = Enumerable.Repeat<bool>(false,5).ToArray();
        static public string ReadCollectString = "";
    }
}



