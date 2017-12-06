using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LogAnalyzer2
{
    class DetailAnalysis
    {
        public bool SetDetailAnalysis(string sID, string sComp)
        {
            DetailAnalysisForm dlg = new DetailAnalysisForm();
            
            System.Windows.Forms.TextBox DetailText = dlg.GetTextBox();
//            System.Windows.Forms.ListView DetailView = dlg.GetView();
            System.Windows.Forms.DataGridView DetailView = dlg.GetGridView();

            string sMail = "";
            if (DatabasePool.Instance.V_Members_Dic.ContainsKey(sID) == true)
            {
                sMail = DatabasePool.Instance.V_Members_Dic[sID].Email;
            }

            List<TB_Log_T> LogList = DatabasePool.Instance.TB_Log_List.FindAll(x => x.StrID == sID);

            DetailText.Text = sComp;
            int i = 0;


//            DetailView.DataBind();

            DataTable TableBuf = new DataTable();
 
            TableBuf.Columns.Add("No");
            TableBuf.Columns.Add("PID");
            TableBuf.Columns.Add("ConnDate");

            TableBuf.Columns.Add("End Date");
            TableBuf.Columns.Add("CMD");
            TableBuf.Columns.Add("Muss Ent");
            TableBuf.Columns.Add("Muss Post");
            TableBuf.Columns.Add("Muss Email");
            TableBuf.Columns.Add("ID");
            TableBuf.Columns.Add("IP");
            TableBuf.Columns.Add("MAC");
            TableBuf.Columns.Add("Lang");
            TableBuf.Columns.Add("PG");
            TableBuf.Columns.Add("Ver.");
            TableBuf.Columns.Add("Option");
            TableBuf.Columns.Add("National");
            TableBuf.Columns.Add("PKID");
            TableBuf.Columns.Add("Log Code");
            TableBuf.Columns.Add("Description");

            string sOpt = "";
            i = 0;
            foreach (TB_Log_T LogTmp in LogList)
            {
                DataRow RowBuf = TableBuf.NewRow();
                sOpt = "";

                RowBuf["No"] = LogTmp.Idx;
                RowBuf["PID"] =LogTmp.StrPID;
                RowBuf["ConnDate"] =LogTmp.DSDate;

                RowBuf["End Date"] =LogTmp.DEDate;
                RowBuf["CMD"] =LogTmp.StrCMD;
                RowBuf["Muss Ent"] ="";   // Muss Ent
                RowBuf["Muss Post"] ="";   // Muss Post
                RowBuf["Muss Email"] =sMail;    // Muss Email
                RowBuf["ID"] =LogTmp.StrID;
                RowBuf["IP"] =LogTmp.StrIP;
                RowBuf["MAC"] =LogTmp.StrMac;
                RowBuf["Lang"] =LogTmp.StrLangCode;
                RowBuf["PG"] =LogTmp.StrProgCode;
                RowBuf["Ver."] =LogTmp.StrVersion;

                if (int.Parse(LogTmp.NUseOpt) > 0)
                    sOpt += "[" + LogTmp.NUseOpt + "]";
                if (int.Parse(LogTmp.NUseOpt2) > 0)
                    sOpt += "[" + LogTmp.NUseOpt2 + "]";
                if (int.Parse(LogTmp.NUseOpt3) > 0)
                    sOpt += "[" + LogTmp.NUseOpt3 + "]";
                if (int.Parse(LogTmp.NUseOpt4) > 0)
                    sOpt += "[" + LogTmp.NUseOpt4 + "]";
                RowBuf["Option"] = sOpt;

                RowBuf["National"] =LogTmp.NNationalOpt;
                RowBuf["PKID"] =LogTmp.StrProtectKey;
                RowBuf["Log Code"] =LogTmp.StrLogCode;
                RowBuf["Description"] =LogTmp.StrLogString;

                TableBuf.Rows.Add(RowBuf);
                
                i++;
            }

            DetailView.DataSource = TableBuf;

            dlg.ShowDialog();// == System.Windows.Forms.DialogResult.OK)

            return true;
        }    

    }
}
