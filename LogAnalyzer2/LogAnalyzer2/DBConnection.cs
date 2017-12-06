﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization; 

namespace LogAnalyzer2
{
    public class InputParam
    {
        public enum eLogType
        {
            kLogUseType =0,
            kLogFunctionType,
        }

        public enum eResultType
        {
            kByVersionType = 0,
            kByCompanyType,
        }

        public string strDateTimePickerFrom;
        public string strDateTimePickerTo;
        public string strProductName;
        public string strCountry;
        public string strFilterCompany;
        public string strFilterUserID;
        public eLogType logType;
        public eResultType resultType;
        public System.Windows.Forms.ProgressBar progressBar;

        public InputParam()
        {
            Initialize();
        }

        void Initialize()
        {
            strDateTimePickerFrom = string.Empty;
            strDateTimePickerTo = string.Empty;
            strProductName = string.Empty;
            strCountry = string.Empty;
            strFilterCompany = string.Empty;
            strFilterUserID = string.Empty;
            logType = eLogType.kLogUseType;
            resultType = eResultType.kByVersionType;
            progressBar = null;
        }
    }

    public class ResultTable
    {
        public string _company;
        public string _id;
        public string _version;
        public string _function;
        public Dictionary<string, uint> _periodicalSumNumDic;

        public ResultTable()
        {
            Initialize();
        }

        void Initialize()
        {
            _company = string.Empty;
            _id = string.Empty;
            _version = string.Empty;
            _function = string.Empty;
            _periodicalSumNumDic = new Dictionary<string, uint>();
        }
    }

    public class DBConnection
    {
        private static DBConnection _instance;
        private bool _isDbConnected;
        uint _nAssertCount1;
        uint _nAssertCount2;
        uint _nAssertCount3;
        uint _nAssertCount4;
        private InputParam _inputParam;

        public static DBConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }
        }

        public DBConnection()
        {
            Initialize();
        }

        public void Initialize()
        {
            _isDbConnected = false;
            _nAssertCount1 = 0;
            _nAssertCount2 = 0;
            _nAssertCount3 = 0;
            _nAssertCount4 = 0;
            _inputParam = null;
        }

        public bool Execute(InputParam param)
        {
            Initialize();
            _inputParam = param;
            LoadDatabase loadDB = new LoadDatabase(param);
            _isDbConnected = loadDB.Execute();
           return _isDbConnected;
        }

        public bool IsDbConnected()
        {
            return _isDbConnected;
        }
        
        public void GetData(InputParam param, ref Dictionary<string, ResultTable> resultDic)
        {
            if (param.logType == InputParam.eLogType.kLogFunctionType)
            {
                //totalDic Key : Function/Version
                foreach (MidasUpdate_nIP_T data in DatabasePool.Instance.MidasUpdate_nIP_List)
                {
                    //Key : Function Name , Value : Number of used count
                    Dictionary<string, uint> funcNumDic = new Dictionary<string,uint>();
                    List<string>ErrorData1 = new List<string>();

                    ConvertToFunctionTitleFromULog(data.ULog, ref funcNumDic, ref ErrorData1);
                    if (funcNumDic.Count < 1)
                        continue;

                    string strID = string.Empty;
                    string strCompany = string.Empty;

                    List<string> ErrorData2 = new List<string>();
                    SearchUserInfoFromMac(param, data.GetMacAddress(), ref strCompany, ref strID, ref ErrorData2);

                    LogFilter filter = new LogFilter(param);
                    filter.UserID = strID;
                    filter.Company = strCompany;
                    filter.UserIP = data.ServerIP;
                    if (filter.IsShowData() == false)
                        continue;

                    string strVersion = string.Format("{0}{1}{2}", data.NVer1, data.NVer2, data.NVer3);
                    string strYearMonth = data.Regdate.Substring(0, 7);

                    foreach(KeyValuePair<string, uint> pair in funcNumDic)
                    {
                        string strKey = string.Empty;
                        if (param.resultType == InputParam.eResultType.kByVersionType)
                            strKey = string.Format("{0}/{1}", pair.Key, strVersion);
                        else if (param.resultType == InputParam.eResultType.kByCompanyType)
                            strKey = string.Format("{0}/{1}/{2}/{3}", strCompany, strID, pair.Key, strVersion);

                        if (resultDic.ContainsKey(strKey) == true)
                        {
                            if (resultDic[strKey]._periodicalSumNumDic.ContainsKey(strYearMonth) == true)
                            {
                                uint num = resultDic[strKey]._periodicalSumNumDic[strYearMonth];
                                num += pair.Value;
                                resultDic[strKey]._periodicalSumNumDic[strYearMonth] = num;
                            }
                            else
                            {
                                resultDic[strKey]._periodicalSumNumDic.Add(strYearMonth, pair.Value);
                            }
                        }
                        else
                        {
                            ResultTable result = new ResultTable();
                            result._company = strCompany;
                            result._id = strID;
                            result._function = pair.Key;
                            result._version = strVersion;
                            result._periodicalSumNumDic.Add(strYearMonth, pair.Value);

                            resultDic.Add(strKey, result);
                        }
                    }
                }
            }
            else if (param.logType == InputParam.eLogType.kLogUseType)
            {
                foreach (TB_Log_T data in DatabasePool.Instance.TB_Log_List)
                {
                        string strID = data.StrID;

                        List<string> userIds = new List<string>();
                        userIds.Add(strID);

                        string strCompany = string.Empty;

                        List<string> ErrorData3 = new List<string>();
                        SearchUserInfoFromIds(param, userIds, ref strCompany, ref ErrorData3);

                        LogFilter filter = new LogFilter(param);
                        filter.UserID = strID;
                        filter.Company = strCompany;
                        filter.UserIP = data.StrIP;
                        if (filter.IsShowData() == false)
                            continue;

                        string strVersion = data.StrVersion;
                        string strYearMonth = data.DSDate.Substring(0, 7);

                        string strKey = string.Empty;
                        if (param.resultType == InputParam.eResultType.kByVersionType)
                            strKey = strVersion;
                        else if (param.resultType == InputParam.eResultType.kByCompanyType)
                            strKey = string.Format("{0}/{1}/{2}", strCompany, strID, strVersion);

                        if (resultDic.ContainsKey(strKey) == true)
                        {
                            if (resultDic[strKey]._periodicalSumNumDic.ContainsKey(strYearMonth) == true)
                            {
                                uint num = resultDic[strKey]._periodicalSumNumDic[strYearMonth];
                                num += 1;
                                resultDic[strKey]._periodicalSumNumDic[strYearMonth] = num;
                            }
                            else
                            {
                                resultDic[strKey]._periodicalSumNumDic.Add(strYearMonth, 1);
                            }
                        }
                        else
                        {
                            ResultTable result = new ResultTable();
                            result._company = strCompany;
                            result._id = strID;
                            result._version = strVersion;
                            result._periodicalSumNumDic.Add(strYearMonth, 1);

                            resultDic.Add(strKey, result);
                        }
                }
            }
        }

        private void ConvertToFunctionTitleFromULog(string strULog, ref Dictionary<string, uint> funcNumDic, ref List<string>ErrData)
        {
            string[] separator = new string[] { ")" };
            string[] strArray = strULog.Split(separator, StringSplitOptions.None);

            foreach (string str in strArray)
            {
                if (str.Contains("(GML.....-") == true)
                {
                    string strNum = str.Substring(10, 1);

                    uint nNum = 0;
                    if (uint.TryParse(strNum, out nNum) == false)
                    {
                        if (this._nAssertCount1 < 1)
                        {
                            System.Diagnostics.Debug.Assert(false, "カウントされていません。確認必要!");
                            this._nAssertCount1++;
                        }
                        continue;
                    }

                    if (funcNumDic.ContainsKey("MemberList") == true)
                    {
                        uint sumNum = funcNumDic["MemberList"];
                        sumNum += nNum;
                        funcNumDic["MemberList"] = sumNum;
                    }
                    else
                    {
                        funcNumDic.Add("MemberList", nNum);
                    }
                }
                else if (str.Contains("(GSP.....-") == true)
                {
                    string strNum = str.Substring(10, 1);

                    uint nNum = 0;
                    if (uint.TryParse(strNum, out nNum) == false)
                    {
                        if (this._nAssertCount2 < 1)
                        {
                            System.Diagnostics.Debug.Assert(false, "カウントされていません。確認必要!");
                            this._nAssertCount2++;
                        }
                        
                        continue;
                    }

                    if (funcNumDic.ContainsKey("FloorPlan/SectionPlan") == true)
                    {
                        uint sumNum = funcNumDic["FloorPlan/SectionPlan"];
                        sumNum += nNum;
                        funcNumDic["FloorPlan/SectionPlan"] = sumNum;
                    }
                    else
                    {
                        funcNumDic.Add("FloorPlan/SectionPlan", nNum);
                    }
                }
            }
        }

        private bool SearchUserInfoFromMac(InputParam param, string strMacAddress, ref string strCompany, ref string strID, ref List<string> ErrData)
        {
            //Mac AddresでUserIDをTB_Log Tableで探す。
            List<string> userIds = new List<string>();

            foreach (TB_Log_T tbLogT in DatabasePool.Instance.TB_Log_List)
            {
                    if (tbLogT.StrMac.Contains(strMacAddress) == true)
                    {
                        if (userIds.Contains(tbLogT.StrID) == false)
                            userIds.Add(tbLogT.StrID);
                    }
                
            }

            if (userIds.Count < 1)
            {
                if (this._nAssertCount3 < 1)
                {
                    string message = string.Format("MacAddress: {0} に対するIDがないです。確認必要！", strMacAddress);
                    ErrData.Add(strMacAddress);
                    System.Diagnostics.Debug.Assert(false, message);

                    this._nAssertCount3++;
                }
                
                return false;
            }
            List<string> ErrorData4 = new List<string>();
            SearchUserInfoFromIds(param, userIds, ref strCompany, ref ErrorData4);

            strID = GetMergeString(userIds, ",");
            return (strCompany != string.Empty && strID != string.Empty);
        }

        private bool SearchUserInfoFromIds(InputParam param, List<string> userIds, ref string strCompany, ref List<string>ErrData)
        {
            List<string> companyNames = new List<string>();

            if (param.strProductName != "CADRobo(Drawing)")
            {
                // 20171026

                //検索したUserIDでCompanyNameをV_Nodeで探す。
                foreach ( string UID in userIds )
                {
                    if (DatabasePool.Instance.V_Node_Dic.ContainsKey(UID) == true)
                    {
                        if (companyNames.Contains(DatabasePool.Instance.V_Node_Dic[UID].Enterprise_name) == false)
                            companyNames.Add(DatabasePool.Instance.V_Node_Dic[UID].Enterprise_name);
                    }
                }

                strCompany = GetMergeString(companyNames, ",");
                return (strCompany != string.Empty);
            }

            //CADRoboみたいにフリワェアはV_Members Tableで探す。
            foreach (string id in userIds)
            {
                if (DatabasePool.Instance.V_Members_Dic.ContainsKey(id) == true)
                {
                    string name = DatabasePool.Instance.V_Members_Dic[id].Enterprise_name;
                    if (companyNames.Contains(name) == false)
                        companyNames.Add(name);
                }
                else
                {
                    if (this._nAssertCount4 < 1)
                    {
                        System.Diagnostics.Debug.Assert(false, "UserIDに対するCompany Nameがないです。確認必要！");
                        ErrData.Add(id);
//                        companyNames.Add("No Company");
                        this._nAssertCount4++;
                    }
                }
            }

            strCompany = GetMergeString(companyNames, ",");
            return (strCompany != string.Empty);
        }

        private string GetMergeString(List<string> stringList, string separatorText)
        {
            string mergeString = string.Empty;
            foreach (string str in stringList)
            {
                if (mergeString == string.Empty)
                    mergeString = str;
                else
                    mergeString = mergeString + separatorText + str;
            }

            return mergeString;
        }

        public void SaveDatabase()
        {
            //XML Save
            /*if (dFromTimestamp == 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<V_Node_T>));
                FileStream fs = new FileStream(strFilePath, FileMode.Create);
                serializer.Serialize(fs, nodeList);
                fs.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                foreach (V_Node_T noddT in nodeList)
                {
                    XmlNode xmlRecordNo = xmlDoc.CreateNode(XmlNodeType.Element, "V_Node_T", null);
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Enterprise_code", noddT.Enterprise_code));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Enterprise_name", noddT.Enterprise_name));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Department_code", noddT.Department_code));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Department_name", noddT.Department_name));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Node_sn", noddT.Node_sn));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Id", noddT.Id));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Node_name", noddT.Node_name));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Regist_timestamp", noddT.Regist_timestamp));
                    xmlRecordNo.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Use_yn", noddT.Use_yn));

                    xmlDoc.DocumentElement.AppendChild(xmlRecordNo);
                }

                xmlDoc.Save(strFilePath);
            }*/

            this._inputParam.progressBar.Style = ProgressBarStyle.Continuous;
            this._inputParam.progressBar.Minimum = 0;
            this._inputParam.progressBar.Maximum = 6;
            this._inputParam.progressBar.Step = 1;
            this._inputParam.progressBar.PerformStep();

            //V_Node Table 保存
            string strFilePath1 = Application.StartupPath + "\\V_Node_List.xml";
            if (File.Exists(strFilePath1) == true)
                File.Delete(strFilePath1);

            this._inputParam.progressBar.PerformStep();

            List<V_Node_T> nodeList = DatabasePool.Instance.V_Node_Dic.Values.ToList();
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<V_Node_T>));
            FileStream fs1 = new FileStream(strFilePath1, FileMode.Create);
            serializer1.Serialize(fs1, nodeList);
            this._inputParam.progressBar.PerformStep();
            fs1.Close();
            this._inputParam.progressBar.PerformStep();

            //V_Members Table 保存
            string strFilePath2 = Application.StartupPath + "\\V_Members_List.xml";
            if (File.Exists(strFilePath2) == true)
                File.Delete(strFilePath2);

            this._inputParam.progressBar.PerformStep();

            List<V_Members_T> memberList = DatabasePool.Instance.V_Members_Dic.Values.ToList();
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<V_Members_T>));
            FileStream fs2 = new FileStream(strFilePath2, FileMode.Create);
            serializer2.Serialize(fs2, memberList);
            this._inputParam.progressBar.PerformStep();
            fs2.Close();
            this._inputParam.progressBar.PerformStep();
        }

        private string CovertLogCode(string strLog)
        {
            string logCode = "ALL";
            switch (strLog)
            {
                case "ImportFile":
                    logCode = "(IF";
                    break;
                case "ImportFileCancel":
                    logCode = "(IFC";
                    break;
                case "DrawIngStyleManager":
                    logCode = "(DSM";
                    break;
                case "GenerateGeneralNote":
                    logCode = "(GGN";
                    break;
                case "GenerateStructurePlane":
                    logCode = "(GSP";
                    break;
                case "GenStructureSection":
                    logCode = "(GSS";
                    break;
                case "GenAxisSection":
                    logCode = "(GXS";
                    break;
                case "GenerateMemberList":
                    logCode = "(GML";
                    break;
                case "GenerateBom":
                    logCode = "(GB";
                    break;
                case "ExportSketchUp":
                    logCode = "(ESU";
                    break;
                case "AutoLabelPlacement":
                    logCode = "(ALP";
                    break;
                case "CopyMemberListTemplate":
                    logCode = "(CMLT";
                    break;
                case "EditMemberListTemplate":
                    logCode = "(EMLT";
                    break;
                case "UpdateTemplate":
                    logCode = "(UT";
                    break;
                case "RegisterRebarSymbol":
                    logCode = "(RRS";
                    break;
                case "ReplaceInternalReference":
                    logCode = "(RIR";
                    break;
            }
            return logCode;
        }
    }
}
