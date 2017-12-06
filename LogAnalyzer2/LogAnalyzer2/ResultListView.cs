using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogAnalyzer2
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }

    public class ResultListView
    {
        private InputParam _param;
        private System.Windows.Forms.ListView _listViewResult;
//        private ListViewEx _listViewResult;

        private static List<List<string>> TargetcolumnNames = new List<List<string>>();
//        private static string[][] TargetColumnNames;

        public ResultListView(InputParam param, System.Windows.Forms.ListView listView)
//        public ResultListView(InputParam param, ListViewEx listView)
        {
            _param = param;
            _listViewResult = listView;
        }

        public void ShowUseLogByBersion(InputParam param)
        {
            _listViewResult.Items.Clear();
            _listViewResult.Columns.Clear();

            TargetcolumnNames.Clear();
            List<string> columnNames = new List<string>();

            SetUseLogByVersion(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            _listViewResult.BeginUpdate();

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;
                ListViewItem item = new ListViewItem(num.ToString());

                item.SubItems.Add(result._version);

                List<string> LstStr = new List<string>();
                LstStr.Add(num.ToString());
                LstStr.Add(result._version);

                uint sum = 0;
                foreach (string colName in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colName) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colName];
                        item.SubItems.Add(nNum.ToString());
                        sum += nNum;

                        LstStr.Add(nNum.ToString());
                    }
                    else
                    {
                        item.SubItems.Add("0");

                        LstStr.Add("0");
                    }
                }

                item.SubItems.Add(sum.ToString());
                _listViewResult.Items.Add(item);
                num++;

//                TargetColumnNames[num - 1][ 3] = sum.ToString();
                LstStr.Add(sum.ToString());

                TargetcolumnNames.Add(LstStr);
            }

            _listViewResult.EndUpdate();
        }

        public void SortUseLogByBersion(int nColumn, bool bASC)
        {
            try
            {

                if (bASC)
                {
                    // 昇順
                    TargetcolumnNames.Sort((a, b) => int.Parse(a[nColumn]) - int.Parse(b[nColumn]));
                }
                else
                {
                    // 降順
                    TargetcolumnNames.Sort((a, b) => int.Parse(b[nColumn]) - int.Parse(a[nColumn]));
                }
            }
            catch
            {

                if (bASC)
                {
                    // 昇順
                    TargetcolumnNames.Sort((a, b) => String.Compare(a[nColumn].ToString(), b[nColumn].ToString()));
                }
                else
                {
                    // 降順
                    TargetcolumnNames.Sort((a, b) => String.Compare(b[nColumn].ToString(), a[nColumn].ToString()));
                }
            }


            _listViewResult.Items.Clear();
//            _listViewResult.Columns.Clear();
            _listViewResult.BeginUpdate();

            foreach (List<string> words in TargetcolumnNames)
            {
                // Listの中にあるListの内容を表示
                ListViewItem item = new ListViewItem(words[0].ToString());

                for( int i=1;i<words.Count;i++)
                {
                    item.SubItems.Add(words[i].ToString());
                }
                
                _listViewResult.Items.Add(item);
            }
            _listViewResult.EndUpdate();

        }

        public void ShowUseLogByCompany(InputParam param)
        {
            _listViewResult.Items.Clear();
            _listViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();
            SetUseLogByCompany(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            _listViewResult.BeginUpdate();

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;
                ListViewItem item = new ListViewItem(num.ToString());

                item.SubItems.Add(result._company);
                item.SubItems.Add(result._id);
                item.SubItems.Add(result._version);

                // Number of days used
                List<TB_Log_T> LogList = DatabasePool.Instance.TB_Log_List.FindAll(x => x.StrID == result._id);

                List<String> DateList = new List<string>();
                foreach (TB_Log_T LogT in LogList)
                {
                    try
                    {
                        DateList.Add(LogT.DSDate.Substring(0, 10));
                    }
                    catch
                    {
                    }
                }

                //                var DateList =  LogList.Select(p => p.DEDate).Distinct();     // 重複削除
                string s = DateList.Distinct().Count().ToString();
                item.SubItems.Add(s);

                if (int.Parse(s) > 3)
                {
                    int ii = 0;
                }

                List<string> LstStr = new List<string>();
                LstStr.Add(num.ToString());
                LstStr.Add(result._company);
                LstStr.Add(result._id);
                LstStr.Add(result._version);
                LstStr.Add(s);

                uint sum = 0;
                foreach (string colName in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colName) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colName];
                        item.SubItems.Add(nNum.ToString());
                        sum += nNum;

                        LstStr.Add(nNum.ToString());
                    }
                    else
                    {
                        item.SubItems.Add("0");
                        LstStr.Add("0");
                    }
                }

                item.SubItems.Add(sum.ToString());
                _listViewResult.Items.Add(item);
                num++;

                LstStr.Add(sum.ToString());
                TargetcolumnNames.Add(LstStr);
            }

            _listViewResult.EndUpdate();
        }

        public void ShowFunctionLogByVersion(InputParam param)
        {
            _listViewResult.Items.Clear();
            _listViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();
            SetFunctionLogByVersion(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            _listViewResult.BeginUpdate();

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;
                ListViewItem item = new ListViewItem(num.ToString());

                item.SubItems.Add(result._function);
                item.SubItems.Add(result._version);

                List<string> LstStr = new List<string>();
                LstStr.Add(num.ToString());
                LstStr.Add(result._function);
                LstStr.Add(result._version);

                uint sum = 0;
                foreach (string colName in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colName) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colName];
                        item.SubItems.Add(nNum.ToString());
                        sum += nNum;

                        LstStr.Add(nNum.ToString());
                    }
                    else
                    {
                        item.SubItems.Add("0");
                        LstStr.Add("0");
                    }
                }

                item.SubItems.Add(sum.ToString());
                _listViewResult.Items.Add(item);
                num++;

                LstStr.Add(sum.ToString());
                TargetcolumnNames.Add(LstStr);
            }

            _listViewResult.EndUpdate();
        }

        public void ShowFunctionLogByCompany(InputParam param)
        {
            _listViewResult.Items.Clear();
            _listViewResult.Columns.Clear();
            TargetcolumnNames.Clear();

            List<string> columnNames = new List<string>();
            SetFunctionLogByCompany(ref columnNames);

            Dictionary<string, ResultTable> resultDic = new Dictionary<string, ResultTable>();
            DBConnection.Instance.GetData(param, ref resultDic);

            uint num = 1;
            _listViewResult.BeginUpdate();

            foreach (KeyValuePair<string, ResultTable> pair in resultDic)
            {
                ResultTable result = pair.Value;
                ListViewItem item = new ListViewItem(num.ToString());

                item.SubItems.Add(result._company);
                item.SubItems.Add(result._id);
                item.SubItems.Add(result._function);
                item.SubItems.Add(result._version);

                // Number of days used
                List<TB_Log_T> LogList = DatabasePool.Instance.TB_Log_List.FindAll(x => x.StrID ==result._id);

                List<String> DateList = new List<string>();
                foreach (TB_Log_T LogT in LogList)
                {
                    DateList.Add(LogT.DSDate.Substring(0, 10));
                }

//                var DateList =  LogList.Select(p => p.DEDate).Distinct();     // 重複削除
                string s = DateList.Distinct().Count().ToString();
                item.SubItems.Add(s);

                List<string> LstStr = new List<string>();
                LstStr.Add(num.ToString());
                LstStr.Add(result._company);
                LstStr.Add(result._id);
                LstStr.Add(result._function);
                LstStr.Add(result._version);
                LstStr.Add(s);

                uint sum = 0;
                foreach (string colName in columnNames)
                {
                    if (result._periodicalSumNumDic.ContainsKey(colName) == true)
                    {
                        uint nNum = result._periodicalSumNumDic[colName];
                        item.SubItems.Add(nNum.ToString());
                        sum += nNum;

                        LstStr.Add(nNum.ToString());
                    }
                    else
                    {
                        item.SubItems.Add("0");
                        LstStr.Add("0");
                    }
                }

                item.SubItems.Add(sum.ToString());
                _listViewResult.Items.Add(item);
                num++;

                LstStr.Add(sum.ToString());
                TargetcolumnNames.Add(LstStr);
            }

            _listViewResult.EndUpdate();
        }

        private void SetUseLogByVersion(ref List<string> columnNames)
        {
            //Add column header
            this._listViewResult.Columns.Add("No.", 50);
            this._listViewResult.Columns.Add("Version", 150);

            AddColumnsOnDate(ref columnNames);
        }

        private void SetUseLogByCompany(ref List<string> columnNames)
        {
            //Add column header
            this._listViewResult.Columns.Add("No.", 50);
            this._listViewResult.Columns.Add("Company", 300);
            this._listViewResult.Columns.Add("ID", 300);
            this._listViewResult.Columns.Add("Version", 150);
            this._listViewResult.Columns.Add("Number of days used", 50);

            AddColumnsOnDate(ref columnNames);
        }

        private void SetFunctionLogByVersion(ref List<string> columnNames)
        {
            //Add column header
            this._listViewResult.Columns.Add("No.", 50);
            this._listViewResult.Columns.Add("Function", 150);
            this._listViewResult.Columns.Add("Version", 150);

            AddColumnsOnDate(ref columnNames);
        }

        private void SetFunctionLogByCompany(ref List<string> columnNames)
        {
            //Add column header
            this._listViewResult.Columns.Add("No.", 50);
            this._listViewResult.Columns.Add("Company", 300);
            this._listViewResult.Columns.Add("ID", 300);
            this._listViewResult.Columns.Add("Function", 150);
            this._listViewResult.Columns.Add("Version", 150);
            this._listViewResult.Columns.Add("Number of days used", 100);

            AddColumnsOnDate(ref columnNames);
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
                if (diffYear > 1)
                    maxMonth = 12;

                for (int i = fromMonth; i <= maxMonth; i++)
                {
                    string colName = string.Empty;
                    if (i < 10)
                        colName = string.Format("{0}-0{1}", fromYear, i);
                    else
                        colName = string.Format("{0}-{1}", fromYear, i);
                    this._listViewResult.Columns.Add(colName, 100);
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
                    this._listViewResult.Columns.Add(colName, 100);
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
                    this._listViewResult.Columns.Add(colName, 100);
                    columnNames.Add(colName);
                }
            }

            this._listViewResult.Columns.Add("Sum.", 100);
        }
    }
}
