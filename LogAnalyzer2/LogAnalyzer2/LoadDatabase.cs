using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using System.Data;

namespace LogAnalyzer2
{
    public class LoadDatabase
    {
        private InputParam _inputParam;

        public LoadDatabase(InputParam param)
        {
            _inputParam = param;
        }

        public bool Execute()
        {
            this._inputParam.progressBar.Style = ProgressBarStyle.Continuous;
            this._inputParam.progressBar.Minimum = 0;
            this._inputParam.progressBar.Maximum = 20;
            this._inputParam.progressBar.Step = 1;
            this._inputParam.progressBar.PerformStep();

            string NowReadCollectString = "";

            NowReadCollectString += this._inputParam.strProductName + ",";
            NowReadCollectString += this._inputParam.strCountry + ",";
            NowReadCollectString += this._inputParam.strDateTimePickerTo + ",";
            NowReadCollectString += this._inputParam.strDateTimePickerFrom + ",";

            if (Constants.ReadCollectString != NowReadCollectString)
            {
                for (int i = 0; i < 5; i++)
                    Constants.ReadFlg[i] = false;
                Constants.ReadCollectString = NowReadCollectString;
            }

            if (Constants.ReadFlg[0] == false)
            {
                if (GetDatabaseV_Node_Table() == false)
                {
                    return false;
                }
                else
                {
                    Constants.ReadFlg[0] = true;
                }
            }
            if (this._inputParam.progressBar.Value < 4)
            {
                this._inputParam.progressBar.Value = 4;
            }
            
            if (Constants.ReadFlg[1] == false)
            {
                if (GetDatabaseV_Members_Table() == false)
                {
                    return false;
                }
                else
                {
                    Constants.ReadFlg[1] = true;
                }
            }
            if (this._inputParam.progressBar.Value < 8)
            {
                this._inputParam.progressBar.Value = 8;
            }

            if (Constants.ReadFlg[3] == false)
            {
                if (GetDatabaseTB_Log() == false)
                {
                    return false;
                }
                else
                {
                    Constants.ReadFlg[3] = true;
                }
            }
            if (this._inputParam.progressBar.Value < 12)
            {
                this._inputParam.progressBar.Value = 12;
            }

            if (Constants.ReadFlg[4] == false)
            {
                if (GetDatabaseMidasUpdate_nIP() == false)
                {
                    return false;
                }
                else
                {
                    Constants.ReadFlg[4] = true;
                }
            }
            if (this._inputParam.progressBar.Value < 20)
            {
                this._inputParam.progressBar.Value = 20;
            }

            return true;
        }

        private bool GetDatabaseTB_Log()
        {
            DatabasePool.Instance.TB_Log_List.Clear();
            string strProgCode = GetStrProgCode();

            if (!Constants.FLG_UPDATE)
            {
                string strFilePath = Application.StartupPath + "\\V_TB_LOG_List.xml";
                double dFromTimestamp = 0;

                if (File.Exists(strFilePath) == true)
                {
                    if (LoadV_TB_LOG_Table_XML(strFilePath, ref dFromTimestamp) == false)
                        return false;
                }

            }
            else
            {
                string dayFrom = _inputParam.strDateTimePickerFrom;
                string dayTo = _inputParam.strDateTimePickerTo;
                string strLangCode = GetStrLangCode();

                string quary = string.Format("SELECT * FROM TB_Log WHERE strLangCode='{0}' AND strProgCode='{1}' AND dSDate>='{2}' AND dSDate<='{3}' ORDER BY dSDate ASC;", strLangCode, strProgCode, dayFrom, dayTo);

                try
                {
                    string strConn = string.Format("server = {0}; User ID = {1}; Password = {2}; database = midasit.co.kr.mms2",
                        CertificationManager.Instance.ServerIP, CertificationManager.Instance.Id, CertificationManager.Instance.Pw);

                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
//Stopwatchオブジェクトを作成する
// System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
 //ストップウォッチを開始する
// sw.Start();

                        conn.Open();
                        this._inputParam.progressBar.PerformStep();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = quary;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        this._inputParam.progressBar.PerformStep();

// sw.Stop();
 //結果を表示する
// MessageBox.Show(sw.Elapsed.ToString());
 //Console.Write(sw.Elapsed);  

//Stopwatchオブジェクトを作成する
//System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
//ストップウォッチを開始する
//sw2.Start();
                        int aaa = 0;
                        while (rdr.Read())
                        {
//                            if( !(strProgCode == "MDW" && rdr["strVersion"].ToString() != "210"))
                            {
                                TB_Log_T data = new TB_Log_T();

                                data.Idx = rdr["idx"].ToString();
                                data.DSDate = rdr["dSDate"].ToString();
                                data.DSDate = data.DSDate.Replace("/", "-");
                                data.DEDate = rdr["dEDate"].ToString();
                                data.DEDate = data.DEDate.Replace("/", "-");
                                data.StrLogCode = rdr["strLogCode"].ToString();
                                data.StrLogString = rdr["strLogString"].ToString();
                                data.IdxRealConn = rdr["idxRealConn"].ToString();
                                data.StrCMD = rdr["strCMD"].ToString();
                                data.StrID = rdr["strID"].ToString();
                                if (data.StrID.ToString() == "tabuchi" || data.StrID.ToString() == "tabuchi.miyashita")
                                    aaa = 0;

                                data.StrPWD = rdr["strPWD"].ToString();
                                data.StrIP = rdr["strIP"].ToString();
                                data.StrMac = rdr["strMac"].ToString();
                                data.StrPID = rdr["strPID"].ToString();
                                data.StrLangCode = rdr["strLangCode"].ToString();
                                data.StrProgCode = rdr["strProgCode"].ToString();
                                data.StrVersion = rdr["strVersion"].ToString();
                                data.NUseOpt = rdr["nUseOpt"].ToString();
                                data.NUseOpt2 = rdr["nUseOpt2"].ToString();
                                data.NUseOpt3 = rdr["nUseOpt3"].ToString();
                                data.NUseOpt4 = rdr["nUseOpt4"].ToString();
                                data.NNationalOpt = rdr["nNationalOpt"].ToString();
                                data.StrProtectKey = rdr["strProtectKey"].ToString();


                                DatabasePool.Instance.TB_Log_List.Add(data);
                            }
                        }
                        rdr.Close();

                        this._inputParam.progressBar.PerformStep();

///////////////////////////////////                        //ストップウォッチを止める
//                        sw2.Stop();
                        //結果を表示する
//                        string s = string.Format("Connect={0},DB Copy={1}", sw.Elapsed.ToString(), sw2.Elapsed.ToString());
//                        MessageBox.Show(s,"TB_Log");
//                        Console.Write(sw.Elapsed);                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

/*
                // ローカル開発用に機能ログ保存
                string strFilePath = Application.StartupPath + "\\V_TB_LOG_List.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(List<TB_Log_T>));
                FileStream fs = new FileStream(strFilePath, FileMode.Create);
                serializer.Serialize(fs, DatabasePool.Instance.TB_Log_List);
                fs.Close();
*/
            }

            return (DatabasePool.Instance.TB_Log_List.Count > 0);
        }

        private bool LoadV_TB_LOG_Table_XML(string strFilePath, ref double dFromTimestamp)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<TB_Log_T>));
                StreamReader reader = new StreamReader(strFilePath);
                DatabasePool.Instance.TB_Log_List = (List<TB_Log_T>)deSerializer.Deserialize(reader);
                this._inputParam.progressBar.PerformStep();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return (DatabasePool.Instance.TB_Log_List.Count > 0);
        }

        private bool GetDatabaseMidasUpdate_nIP()
        {
            DatabasePool.Instance.MidasUpdate_nIP_List.Clear();

            if (!Constants.FLG_UPDATE)
            {
                string strFilePath = Application.StartupPath + "\\V_MidasUpdate_List.xml";
                double dFromTimestamp = 0;

                if (File.Exists(strFilePath) == true)
                {
                    if (LoadV_MidasUpdate_Table_XML(strFilePath, ref dFromTimestamp) == false)
                        return false;
                }

            }
            else
            {

                string dayFrom = _inputParam.strDateTimePickerFrom;
                string dayTo = _inputParam.strDateTimePickerTo;
                int nProductNum = GetProductNum();
                int nLangageNum = GetLangageNum();

                if (nProductNum == 0 || nLangageNum == 0)
                    return false;

                string quary = string.Format("SELECT * FROM MidasUpdate_nIP WHERE nProduct='{0}' AND nLang='{1}' AND regdate>='{2}' AND regdate<='{3}' ORDER BY regdate ASC;", nProductNum, nLangageNum, dayFrom, dayTo);

                try
                {
                    string strConn = string.Format("server = {0}; User ID = {1}; Password = {2}; database = intra",
                        CertificationManager.Instance.ServerIP, CertificationManager.Instance.Id, CertificationManager.Instance.Pw);
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {

                        //Stopwatchオブジェクトを作成する
//                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        //ストップウォッチを開始する
//                        sw.Start();
                        
                        conn.Open();
                        this._inputParam.progressBar.PerformStep();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = quary;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        this._inputParam.progressBar.PerformStep();

 ///////////////////////////////////                        //ストップウォッチを止める
 //                       sw.Stop();


//Stopwatchオブジェクトを作成する
//            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
//ストップウォッチを開始する
//            sw2.Start();


                        while (rdr.Read())
                        {
                            /*
                            Object[] values = new Object[rdr.FieldCount];
                            rdr.GetValues(values);

                            MidasUpdate_nIP_T data = new MidasUpdate_nIP_T(values);
*/
                            MidasUpdate_nIP_T data = new MidasUpdate_nIP_T();

                            data.Regdate = rdr["regdate"].ToString();
                            data.Regdate = data.Regdate.Replace("/", "-");
                            data.Index_id = rdr["index_id"].ToString();
                            data.ClientV = rdr["ClientV"].ToString();
                            data.ClientIP = rdr["clientIP"].ToString();
                            data.ServerIP = rdr["serverIP"].ToString();
                            data.NProduct = rdr["nProduct"].ToString();
                            data.NBuildNum = rdr["nBuildNum"].ToString();
                            data.NLang = rdr["nLang"].ToString();
                            data.NVer1 = rdr["nVer1"].ToString();
                            data.NVer2 = rdr["nVer2"].ToString();
                            data.NVer3 = rdr["nVer3"].ToString();
                            data.NLic1 = rdr["nLic1"].ToString();
                            data.NLic2 = rdr["nLic2"].ToString();
                            data.NLic3 = rdr["nLic3"].ToString();
                            data.NCRKC = rdr["nCRKC"].ToString();
                            data.StrLKNum = rdr["strLKNum"].ToString();
                            data.Chk_client = rdr["chk_client"].ToString();
                            data.StrName = rdr["strName"].ToString();
                            data.StrCountry = rdr["strCountry"].ToString();
                            data.TxtWhois = rdr["txtWhois"].ToString();
                            data.StrMussID = rdr["strMussID"].ToString();
                            data.ExtLod = rdr["ExtLod"].ToString();
                            data.PLFInfo = rdr["PLFInfo"].ToString();
                            data.ULog = rdr["ULog"].ToString();

                            DatabasePool.Instance.MidasUpdate_nIP_List.Add(data);
                        }
                        rdr.Close();

                        this._inputParam.progressBar.PerformStep();
///////////////////////////////////                        //ストップウォッチを止める
/*
                        sw2.Stop();
       //結果を表示する
       string s = string.Format("Connect={0},DB Copy={1}", sw.Elapsed.ToString(), sw2.Elapsed.ToString());
//       MessageBox.Show(s, "MidasUpdate_nIP");
//       Console.Write(sw.Elapsed);    
*/                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            return (DatabasePool.Instance.MidasUpdate_nIP_List.Count >= 0);
        }

        private bool LoadV_MidasUpdate_Table_XML(string strFilePath, ref double dFromTimestamp)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<MidasUpdate_nIP_T>));
                StreamReader reader = new StreamReader(strFilePath);
                DatabasePool.Instance.MidasUpdate_nIP_List = (List<MidasUpdate_nIP_T>)deSerializer.Deserialize(reader);
                this._inputParam.progressBar.PerformStep();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return (DatabasePool.Instance.MidasUpdate_nIP_List.Count > 0);
        }

        private bool GetDatabaseV_Node_Table()
        {
            DatabasePool.Instance.V_Node_Dic.Clear();

            string strFilePath = Application.StartupPath + "\\V_Node_List.xml";
            double dFromTimestamp = 0;

            if (File.Exists(strFilePath) == true)
            {
                if (LoadV_Node_Table_XML(strFilePath, ref dFromTimestamp) == false)
                    return false;
            }
            else
            {
                DateTime fromDT = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dFromTimestamp = ConvertToUnixTimestamp(fromDT);
                
            }

            DateTime dt =ConvertFromUnixTimestamp(dFromTimestamp);
            DateTime dtToday = DateTime.Today;
            if (Constants.FLG_UPDATE && dt.ToString("yyyy-MM-dd") != dtToday.ToString("yyyy-MM-dd"))
            {
                Constants.bFirstConnect = true;

                List<V_Node_T> nodeList = new List<V_Node_T>();
                double dNowTimestamp = ConvertToUnixTimestamp(DateTime.Now);

                string quary = string.Format("SELECT * FROM V_Node WHERE regist_timestamp > '{0}' AND regist_timestamp <= '{1}' ORDER BY regist_timestamp ASC", dFromTimestamp, dNowTimestamp);

                try
                {
                    string strConn = string.Format("server = {0}; User ID = {1}; Password = {2}; database = midasit.co.kr.mms2",
                        CertificationManager.Instance.ServerIP, CertificationManager.Instance.Id, CertificationManager.Instance.Pw);
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        this._inputParam.progressBar.PerformStep();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = quary;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        this._inputParam.progressBar.PerformStep();

                        while (rdr.Read())
                        {
                            V_Node_T data = new V_Node_T();

                            data.Enterprise_code = rdr["enterprise_code"].ToString();
                            data.Enterprise_name = rdr["enterprise_name"].ToString();
                            data.Department_code = rdr["department_code"].ToString();
                            data.Department_name = rdr["department_name"].ToString();
                            data.Node_sn = rdr["node_sn"].ToString();
                            data.Id = rdr["id"].ToString();
                            data.Node_name = rdr["node_name"].ToString();
                            data.Mac = rdr["mac"].ToString();
                            data.Ip = rdr["ip"].ToString();
                            data.Regist_timestamp = rdr["regist_timestamp"].ToString();
                            data.Use_yn = rdr["use_yn"].ToString();

                            nodeList.Add(data);
                        }
                        rdr.Close();

                        this._inputParam.progressBar.PerformStep();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
  
                foreach (V_Node_T nList in nodeList)
                {
                    if (DatabasePool.Instance.V_Node_Dic.ContainsKey(nList.Id) == false)
                    {
                        //                        nodeList = nodeList.DistinctBy(x => x.Id);
                        DatabasePool.Instance.V_Node_Dic.Add(nList.Id, nList);

                    }
                    else
                    {
                        //                        if(DateTime.Parse(DatabasePool.Instance.V_Node_Dic[nList.Id].Regist_timestamp)<DateTime.Parse(nList.Regist_timestamp))
                        if(nList.Regist_timestamp.ToString().CompareTo(DatabasePool.Instance.V_Node_Dic[nList.Id].Regist_timestamp.ToString())>0)
                        DatabasePool.Instance.V_Node_Dic[nList.Id] = nList;
                    }
                }

            }

            return (DatabasePool.Instance.V_Node_Dic.Count > 0);
        }

        private bool LoadV_Node_Table_XML(string strFilePath, ref double dFromTimestamp)
        {

            List<V_Node_T> nodeList = new List<V_Node_T>();
            DatabasePool.Instance.V_Node_Dic.Clear();

            try
            {

                XmlSerializer deSerializer = new XmlSerializer(typeof(List<V_Node_T>));
                StreamReader reader = new StreamReader(strFilePath);
                nodeList = (List<V_Node_T>)deSerializer.Deserialize(reader);
                this._inputParam.progressBar.PerformStep();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            if (nodeList.Count > 0)
            {
                string strTime = nodeList[nodeList.Count - 1].Regist_timestamp;

                double dVal = 0;
                if (double.TryParse(strTime, out dVal) == true)
                    dFromTimestamp = dVal;

                foreach (V_Node_T nList in nodeList)
                {
                    if (DatabasePool.Instance.V_Node_Dic.ContainsKey(nList.Id) == false)
                    {
                        DatabasePool.Instance.V_Node_Dic.Add(nList.Id, nList);

                    }
                    else
                    {
                        nList.Id=nList.Id;
                    }
                }
 
            }

            return (DatabasePool.Instance.V_Node_Dic.Count > 0);
        }

        private bool GetDatabaseV_Members_Table()
        {
            DatabasePool.Instance.V_Members_Dic.Clear();

            string strFilePath = Application.StartupPath + "\\V_Members_List.xml";
            string strRegist_datetime = string.Empty;

            string strDatatimeDbPattern = "yyyy-MM-dd hh:mm:ss tt";
            CultureInfo culture = new CultureInfo("en-US");

            if (File.Exists(strFilePath) == true)
            {
                if (LoadV_Members_Table_XML(strFilePath, ref strRegist_datetime) == false)
                    return false;
            }
            else
            {
                DateTime origin = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                strRegist_datetime = origin.ToString(strDatatimeDbPattern, culture);
            }

            DateTime dtToday = DateTime.Today;//.ToString(),"yyyy-MM-dd hh:mm:ss tt",null);
            if (Constants.FLG_UPDATE && dtToday.ToString("yyyy-MM-dd") != DateTime.Parse(strRegist_datetime).ToString("yyyy-MM-dd") )
            {
                Constants.bFirstConnect = true;

                if (GetDatabaseV_Members_AddedTable(strRegist_datetime) == false)
                    return false;

                if (GetDatabaseV_Members_ModifiedTable(strRegist_datetime) == false)
                    return false;
            }
            return true;
        }

        private bool LoadV_Members_Table_XML(string strFilePath, ref string strRegist_datetime)
        {
            List<V_Members_T> memberList = null;
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<V_Members_T>));
                StreamReader reader = new StreamReader(strFilePath);
                memberList = (List<V_Members_T>)deSerializer.Deserialize(reader);
                this._inputParam.progressBar.PerformStep();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            if (memberList.Count < 1)
                return false;

            string lastTime = string.Empty;
            foreach (V_Members_T member in memberList)
            {
                if (DatabasePool.Instance.V_Members_Dic.ContainsKey(member.Id) == false)
                {
                    DatabasePool.Instance.V_Members_Dic.Add(member.Id, member);
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "IDは複数存在出来ません。");
                }

                lastTime = member.Regist_datetime;
            }

            strRegist_datetime = lastTime;

            return (DatabasePool.Instance.V_Members_Dic.Count > 0);
        }

        private bool GetDatabaseV_Members_AddedTable(string strRegist_datetime)
        {
            string strDatatimeDbPattern = "yyyy-MM-dd hh:mm:ss tt";
            CultureInfo culture = new CultureInfo("en-US");

            List<V_Members_T> memberList = new List<V_Members_T>();
            string strNow = DateTime.Now.ToString(strDatatimeDbPattern, culture);

            //regist_datetimeの詩分秒まで計算しなきゃならないが後でいます。
            string quary = string.Format("SELECT * FROM V_Members WHERE regist_datetime >= '{0}' AND regist_datetime < '{1}' ORDER BY regist_datetime ASC", strRegist_datetime, strNow);

            try
            {
                string strConn = string.Format("server = {0}; User ID = {1}; Password = {2}; database = kor.midasuser.com",
                    CertificationManager.Instance.ServerIP, CertificationManager.Instance.Id, CertificationManager.Instance.Pw);
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    this._inputParam.progressBar.PerformStep();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = quary;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    this._inputParam.progressBar.PerformStep();

                    while (rdr.Read())
                    {
                        V_Members_T data = new V_Members_T();

                        data.Id = rdr["id"].ToString();
                        data.First_name = rdr["first_name"].ToString();
                        data.Last_name = rdr["last_name"].ToString();
                        data.Eng_first_name = rdr["eng_first_name"].ToString();
                        data.Eng_last_name = rdr["eng_last_name"].ToString();
                        data.Email = rdr["email"].ToString();
                        data.Mobile = rdr["mobile"].ToString();
                        data.Fax = rdr["fax"].ToString();
                        data.Telephone = rdr["telephone"].ToString();
                        data.Enterprise_name = rdr["enterprise_name"].ToString();
                        data.Department_name = rdr["department_name"].ToString();
                        data.Duty = rdr["duty"].ToString();
                        data.Address = rdr["address"].ToString();
                        data.Area_code = rdr["area_code"].ToString();

                        string pattern = "yyyy-MM-dd tt h:m:s";
                        string pattern2 = "yyyy/MM/dd H:m:s";

                        DateTime parsedDate;
                        string strTimme = rdr["regist_datetime"].ToString();
                        if (DateTime.TryParseExact(strTimme, pattern, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                            data.Regist_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                        else
                        {
                            if (strTimme != string.Empty)
                            {
                                if (DateTime.TryParseExact(strTimme, pattern2, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                                    data.Regist_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                                else
                                {
                                    Debug.Assert(false, "Parsing出来ない文字があります。");
                                }
                            }
                        }

                        strTimme = rdr["update_datetime"].ToString();
                        if (DateTime.TryParseExact(strTimme, pattern, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                            data.Update_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                        else
                        {
                            if (strTimme != string.Empty)
                            {
                                if (DateTime.TryParseExact(strTimme, pattern2, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                                    data.Update_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                                else
                                {
                                    Debug.Assert(false, "Parsing出来ない文字があります。");
                                }
                            }
                        }

                        memberList.Add(data);
                    }
                    rdr.Close();

                    this._inputParam.progressBar.PerformStep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            foreach (V_Members_T member in memberList)
            {
                if (DatabasePool.Instance.V_Members_Dic.ContainsKey(member.Id) == false)
                {
                    DatabasePool.Instance.V_Members_Dic.Add(member.Id, member);
                }
                else
                {
                    //System.Diagnostics.Debug.Assert(false, "IDは複数存在出来ません。");
                }
            }

            return (DatabasePool.Instance.V_Members_Dic.Count > 0);
        }

        private bool GetDatabaseV_Members_ModifiedTable(string strRegist_datetime)
        {
            string strDatatimeDbPattern = "yyyy-MM-dd hh:mm:ss tt";
            CultureInfo culture = new CultureInfo("en-US");

            List<V_Members_T> memberList = new List<V_Members_T>();
            string strNow = DateTime.Now.ToString(strDatatimeDbPattern, culture);

            //regist_datetimeの詩分秒まで計算しなきゃならないが後でいます。
            string quary = string.Format("SELECT * FROM V_Members WHERE update_datetime > '{0}' AND update_datetime < '{1}' ORDER BY regist_datetime ASC", strRegist_datetime, strNow);

            try
            {
                string strConn = string.Format("server = {0}; User ID = {1}; Password = {2}; database = kor.midasuser.com",
                    CertificationManager.Instance.ServerIP, CertificationManager.Instance.Id, CertificationManager.Instance.Pw);
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    this._inputParam.progressBar.PerformStep();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = quary;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    this._inputParam.progressBar.PerformStep();

                    while (rdr.Read())
                    {
                        V_Members_T data = new V_Members_T();

                        data.Id = rdr["id"].ToString();
                        data.First_name = rdr["first_name"].ToString();
                        data.Last_name = rdr["last_name"].ToString();
                        data.Eng_first_name = rdr["eng_first_name"].ToString();
                        data.Eng_last_name = rdr["eng_last_name"].ToString();
                        data.Email = rdr["email"].ToString();
                        data.Mobile = rdr["mobile"].ToString();
                        data.Fax = rdr["fax"].ToString();
                        data.Telephone = rdr["telephone"].ToString();
                        data.Enterprise_name = rdr["enterprise_name"].ToString();
                        data.Department_name = rdr["department_name"].ToString();
                        data.Duty = rdr["duty"].ToString();
                        data.Address = rdr["address"].ToString();
                        data.Area_code = rdr["area_code"].ToString();


                        string pattern = "yyyy-MM-dd tt h:m:s";
                        string pattern2 = "yyyy/MM/dd H:m:s";

                        DateTime parsedDate;
                        string strTimme = rdr["regist_datetime"].ToString();

                        if (DateTime.TryParseExact(strTimme, pattern, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                            data.Regist_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                        else
                        {
                            if (strTimme != string.Empty)
                            {
                                if (DateTime.TryParseExact(strTimme, pattern2, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                                    data.Regist_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                                else
                                {
                                    Debug.Assert(false, "Parsing出来ない文字があります。");
                                }
                            }
                        }

                        strTimme = rdr["update_datetime"].ToString();
                        if (DateTime.TryParseExact(strTimme, pattern, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                            data.Update_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                        else
                        {
                            if (strTimme != string.Empty)
                            {
                                if (DateTime.TryParseExact(strTimme, pattern2, null, System.Globalization.DateTimeStyles.None, out parsedDate) == true)
                                    data.Update_datetime = parsedDate.ToString(strDatatimeDbPattern, culture);
                                else
                                {
                                    Debug.Assert(false, "Parsing出来ない文字があります。");
                                }
                            }
                        }

                        memberList.Add(data);
                    }
                    rdr.Close();

                    this._inputParam.progressBar.PerformStep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            foreach (V_Members_T member in memberList)
            {
                if (DatabasePool.Instance.V_Members_Dic.ContainsKey(member.Id) == true)
                {
                    if( member.Regist_datetime.ToString().CompareTo(DatabasePool.Instance.V_Members_Dic[member.Id].Regist_datetime.ToString()) > 0 )
                        DatabasePool.Instance.V_Members_Dic[member.Id] = member;
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "IDは複数存在出来ません。");
                }
            }

            return true;
        }

        private bool LoadV_ModuleID_Log_Table_XML(string strFilePath, ref List<ModuleID_Log_T> moduleid_List)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<ModuleID_Log_T>));
                StreamReader reader = new StreamReader(strFilePath);
                moduleid_List = (List<ModuleID_Log_T>)deSerializer.Deserialize(reader);
                this._inputParam.progressBar.PerformStep();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return (moduleid_List.Count > 0);
        }
//* 20171024 */

        private int GetProductNum()
        {

            string s = _inputParam.strProductName;

            switch (s)
            {
                case "CADRobo(Drawing)":
                    return 102;
                    break;
                case "CADRobo(eGen)":
                    return -1;
                    break;
                case "midas Drawing":
                    return 77;
                    break;
                case "midas eGen":
                    return -1;
                    break;
                case "midas iGen":
                    return -1;
                    break;
            }

            return 0;
        }

        private int GetLangageNum()
        {
            if (_inputParam.strCountry == "JP")
                return 4;
            //             else if (this.comboBoxProduct.SelectedItem.ToString() == "KR")
            //                 return 4;

            return 0;
        }

        private string GetStrProgCode()
        {

            string s = _inputParam.strProductName;

            switch (s)
            {
                case "CADRobo(Drawing)":
                    return "MDW";
                    break;
                case "CADRobo(eGen)":
                    return "EGN";
                    break;
                case "midas Drawing":
                    return "MDR";
                    break;
                case "midas eGen":
                    return "EGR";
                    break;
                case "midas iGen":
                    return "IGN";
                    break;
            }

            return string.Empty;
        }

        private string GetStrLangCode()
        {
            if (_inputParam.strCountry == "JP")
                return "JP";

            return string.Empty;
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

    }
}
