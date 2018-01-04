using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LogAnalyzer2
{
    public class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }
    public class ResultGridView
    {
        private InputParam _param;
        private System.Windows.Forms.DataGridView _gridViewResult;

        private static List<List<string>> TargetcolumnNames = new List<List<string>>();

        public ResultGridView(InputParam param, System.Windows.Forms.DataGridView gridView)
        {
            _param = param;
            _gridViewResult = gridView;
        }

        public void ShowUseLogByBersion(InputParam param)
        {
            _gridViewResult.Columns.Clear();

            TargetcolumnNames.Clear();
            List<string> columnNames = new List<string>();

            AddColumnsOnDate(ref columnNames);
//            SetUseLogByVersion(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;

            string[] ColName = Enumerable.Repeat<string>("", 3).ToArray();

            ColName[0] = "No.";
            ColName[1] = "Version";
            ColName[2] = "Sum.";

            DataTable TableBuf = new DataTable();
            for (int i = 0; i < ColName.Count()-1; i++)
                TableBuf.Columns.Add(ColName[i]);
            foreach (string colName in columnNames)
                TableBuf.Columns.Add(colName);
            TableBuf.Columns.Add(ColName[2]);

            for (int i = 0; i < TableBuf.Columns.Count; i++)
                TableBuf.Columns[i].DataType = System.Type.GetType("System.Int32");

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;

                DataRow RowBuf = TableBuf.NewRow();

                RowBuf[ColName[0]] = num.ToString("d");
                RowBuf[ColName[1]] = result._version;

                uint sum = 0;
                foreach (string colNam in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colNam) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colNam];
                        RowBuf[colNam] = nNum.ToString();
                        sum += nNum;

                    }
                    else
                    {
                        RowBuf[colNam] = "0";
                    }
                }

                RowBuf[ColName[2]] = sum.ToString();
                TableBuf.Rows.Add(RowBuf);
                num++;
            }

            _gridViewResult.DataSource = TableBuf;
        }

        public void ShowUseLogByCompany(InputParam param)
        {
            _gridViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();
            AddColumnsOnDate(ref columnNames);
//            SetUseLogByCompany(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            string[] ColName = Enumerable.Repeat<string>("",6).ToArray();

            ColName[0] = "No.";
            ColName[1] = "Company";
            ColName[2] = "ID";
            ColName[3] = "Version";
            ColName[4] = "Number of days used";
            ColName[5] = "Sum.";

            DataTable TableBuf = new DataTable();
            for( int i =0;i < ColName.Count()-1; i++)
                TableBuf.Columns.Add(ColName[i]);
            foreach (string colName in columnNames)
                TableBuf.Columns.Add(colName);
            TableBuf.Columns.Add(ColName[5]);

            TableBuf.Columns[0].DataType = System.Type.GetType("System.Int32");
            for( int i=3; i<TableBuf.Columns.Count;i++)
                TableBuf.Columns[i].DataType = System.Type.GetType("System.Int32");

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;

                DataRow RowBuf = TableBuf.NewRow();

                RowBuf[ColName[0]] = num.ToString("d");
                RowBuf[ColName[1]] = result._company;
                RowBuf[ColName[2]] = result._id;
                RowBuf[ColName[3]] = result._version;

                // Number of days used
                RowBuf[ColName[4]] = GetNumberOfDaysUsed(result._id).ToString();

                uint sum = 0;
                foreach (string colNam in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colNam) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colNam];
                        RowBuf[colNam] = nNum.ToString();
                        sum += nNum;
                    }
                    else
                    {
                        RowBuf[colNam] = "0";
                    }
                }

                RowBuf[ColName[5]] = sum.ToString();
                TableBuf.Rows.Add(RowBuf);
                num++;
            }

            _gridViewResult.DataSource= TableBuf;
        }

        public void ShowFunctionLogByVersion(InputParam param)
        {
            _gridViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();
            AddColumnsOnDate(ref columnNames);
//            SetFunctionLogByVersion(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;

            string[] ColName = Enumerable.Repeat<string>("", 4).ToArray();

            ColName[0] = "No.";
            ColName[1] = "Function";
            ColName[2] = "Version";
            ColName[3] = "Sum.";

            DataTable TableBuf = new DataTable();
            for (int i = 0; i < ColName.Count() - 1; i++)
                TableBuf.Columns.Add(ColName[i]);
            foreach (string colName in columnNames)
                TableBuf.Columns.Add(colName);
            TableBuf.Columns.Add(ColName[3]);

            TableBuf.Columns[0].DataType = System.Type.GetType("System.Int32");
            for (int i = 2; i < TableBuf.Columns.Count; i++)
                TableBuf.Columns[i].DataType = System.Type.GetType("System.Int32");


            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;

                DataRow RowBuf = TableBuf.NewRow();

                RowBuf[ColName[0]] = num.ToString("d");
                RowBuf[ColName[1]] = result._function;
                RowBuf[ColName[2]] = result._version;

                uint sum = 0;
                foreach (string colNam in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colNam) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colNam];
                        RowBuf[colNam] = nNum.ToString();
                        sum += nNum;
                    }
                    else
                    {
                        RowBuf[colNam] = "0";
                    }
                }

                RowBuf[ColName[3]] = sum.ToString();
                TableBuf.Rows.Add(RowBuf);
                num++;
            }

            _gridViewResult.DataSource=TableBuf;
        }

        public void ShowFunctionLogByCompany(InputParam param)
        {
            _gridViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();

            AddColumnsOnDate(ref columnNames);
//            SetFunctionLogByCompany(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            string[] ColName = Enumerable.Repeat<string>("",7).ToArray();

            ColName[0] = "No.";
            ColName[1] = "Company";
            ColName[2] = "ID";
            ColName[3] = "Function";
            ColName[4] = "Version";
            ColName[5] = "Number of days used";
            ColName[6] = "Sum.";

            DataTable TableBuf = new DataTable();
            for (int i = 0; i < ColName.Count() - 1; i++)
                TableBuf.Columns.Add(ColName[i]);
            foreach (string colNam in columnNames)
                TableBuf.Columns.Add(colNam);
            TableBuf.Columns.Add(ColName[6]);

            TableBuf.Columns[0].DataType = System.Type.GetType("System.Int32");
            for (int i = 4; i < TableBuf.Columns.Count; i++)
                TableBuf.Columns[i].DataType = System.Type.GetType("System.Int32");

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;

                DataRow RowBuf = TableBuf.NewRow();

                RowBuf[ColName[0]] = num.ToString("d");
                RowBuf[ColName[1]] = result._company;
                RowBuf[ColName[2]] = result._id;
                RowBuf[ColName[3]] = result._function;
                RowBuf[ColName[4]] = result._version;

                // Number of days used
                RowBuf[ColName[5]] = GetNumberOfDaysUsed(result._id).ToString();

                uint sum = 0;
                foreach (string colNam in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colNam) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colNam];
                        RowBuf[colNam] =nNum.ToString();
                        sum += nNum;
                    }
                    else
                    {
                        RowBuf[colNam] = "0";
                    }
                }

                RowBuf[ColName[6]] =sum.ToString();
                TableBuf.Rows.Add(RowBuf);
                num++;
            }

            _gridViewResult.DataSource = TableBuf;
        }

        private void AddColumnsOnDate(ref List<string> columnNames)
        {
            string strDateTimePickerFrom = _param.strDateTimePickerFrom;
            string strDateTimePickerTo = _param.strDateTimePickerTo;

            string[] separator = new string[] { "-" };

            string[] strSplitFrom = strDateTimePickerFrom.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] strSplitTo = strDateTimePickerTo.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int fromYear = int.Parse(strSplitFrom[0]);
            int fromMonth = int.Parse(strSplitFrom[1]);

            int toYear = int.Parse(strSplitTo[0]);
            int toMonth = int.Parse(strSplitTo[1]);

            int diffYear = toYear - fromYear;

            //시작날 년도 ~ 최대 시작년도 12월까지
            if (diffYear >= 0)
            {
                int maxMonth = toMonth;
                if (diffYear >= 1)
                    maxMonth = 12;

                for (int i = fromMonth; i <= maxMonth; i++)
                {
                    string colName = string.Empty;
                    if (i < 10)
                        colName = string.Format("{0}-0{1}", fromYear, i);
                    else
                        colName = string.Format("{0}-{1}", fromYear, i);
                    columnNames.Add(colName);
                }
            }
            //시작년 다음 년도부터 12월까지
            if (diffYear > 1)
            {
                int year = fromYear + 1;
                for (int i = 1; i <= 12; i++)
                {
                    string colName = string.Empty;
                    if (i < 10)
                        colName = string.Format("{0}-0{1}", year, i);
                    else
                        colName = string.Format("{0}-{1}", year, i);
                    columnNames.Add(colName);
                }
            }
            //끝나는 날짜의 해당 년 1월 부터 끝 날짜 지정 월까지
            if (diffYear > 0)
            {
                for (int i = 1; i <= toMonth; i++)
                {
                    string colName = string.Empty;
                    if (i < 10)
                        colName = string.Format("{0}-0{1}", toYear, i);
                    else
                        colName = string.Format("{0}-{1}", toYear, i);
                    columnNames.Add(colName);
                }
            }
        }

        private int GetNumberOfDaysUsed(string strID)
        {

            string[] separator = new string[] { "," };
            string[] strArray = strID.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int iRet = 0;
            for (int i = 0; i < strArray.Length; i++)
            {

                List<TB_Log_T> LogList = DatabasePool.Instance.TB_Log_List.FindAll(x => x.StrID == strArray[i]);

                List<String> DateList = new List<string>();
                foreach (TB_Log_T LogT in LogList)
                {
                    DateList.Add(LogT.DSDate.Substring(0, 10));
                }

                iRet = iRet + DateList.Distinct().Count();

            }

            return iRet;
        }
    }


}
