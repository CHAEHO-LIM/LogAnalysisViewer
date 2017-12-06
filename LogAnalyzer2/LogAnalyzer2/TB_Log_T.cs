using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer2
{
    public class TB_Log_T
    {

        private string _idx;
        private string _dSDate;
        private string _dEDate;
        private string _strLogCode;
        private string _strLogString;
        private string _idxRealConn;
        private string _strCMD;
        private string _strID;
        private string _strPWD;
        private string _strIP;
        private string _strMac;
        private string _strPID;
        private string _strLangCode;
        private string _strProgCode;
        private string _strVersion;
        private string _nUseOpt;
        private string _nUseOpt2;
        private string _nUseOpt3;
        private string _nUseOpt4;
        private string _nNationalOpt;
        private string _strProtectKey;

/*
        private object[] TB_Log_Data;

        public string Idx
        {
            get { return TB_Log_Data[0].ToString(); }
            set { TB_Log_Data[0] = value; }
        }
        public string DSDate
        {
            get { return TB_Log_Data[1].ToString(); }
            set { TB_Log_Data[1] = value; }
        }
        public string DEDate
        {
            get { return TB_Log_Data[2].ToString(); }
            set { TB_Log_Data[2] = value; }
        }
        public string StrLogCode
        {
            get { return TB_Log_Data[3].ToString(); }
            set { TB_Log_Data[3] = value; }
        }
        public string StrLogString
        {
            get { return TB_Log_Data[4].ToString(); }
            set { TB_Log_Data[4] = value; }
        }
        public string IdxRealConn
        {
            get { return TB_Log_Data[5].ToString(); }
            set { TB_Log_Data[5] = value; }
        }
        public string StrCMD
        {
            get { return TB_Log_Data[6].ToString(); }
            set { TB_Log_Data[6] = value; }
        }
        public string StrID
        {
            get { return TB_Log_Data[7].ToString(); }
            set { TB_Log_Data[7] = value; }
        }
        public string StrPWD
        {
            get { return TB_Log_Data[8].ToString(); }
            set { TB_Log_Data[8] = value; }
        }
        public string StrIP
        {
            get { return TB_Log_Data[9].ToString(); }
            set { TB_Log_Data[9] = value; }
        }
        public string StrMac
        {
            get { return TB_Log_Data[10].ToString(); }
            set { TB_Log_Data[10] = value; }
        }
        public string StrPID
        {
            get { return TB_Log_Data[11].ToString(); }
            set { TB_Log_Data[11] = value; }
        }
        public string StrLangCode
        {
            get { return TB_Log_Data[12].ToString(); }
            set { TB_Log_Data[12] = value; }
        }
        public string StrProgCode
        {
            get { return TB_Log_Data[13].ToString(); }
            set { TB_Log_Data[13] = value; }
        }
        public string StrVersion
        {
            get { return TB_Log_Data[14].ToString(); }
            set { TB_Log_Data[14] = value; }
        }
        public string NUseOpt
        {
            get { return TB_Log_Data[15].ToString(); }
            set { TB_Log_Data[15] = value; }
        }
        public string NUseOpt2
        {
            get { return TB_Log_Data[16].ToString(); }
            set { TB_Log_Data[16] = value; }
        }
        public string NUseOpt3
        {
            get { return TB_Log_Data[17].ToString(); }
            set { TB_Log_Data[17] = value; }
        }
        public string NUseOpt4
        {
            get { return TB_Log_Data[18].ToString(); }
            set { TB_Log_Data[18] = value; }
        }
        public string NNationalOpt
        {
            get { return TB_Log_Data[19].ToString(); }
            set { TB_Log_Data[19] = value; }
        }
        public string StrProtectKey
        {
            get { return TB_Log_Data[20].ToString(); }
            set { TB_Log_Data[20] = value; }
        }
*/

        public string Idx
        {
            get { return _idx; }
            set { _idx = value; }
        }
        public string DSDate
        {
            get { return _dSDate; }
            set { _dSDate = value; }
        }
        public string DEDate
        {
            get { return _dEDate; }
            set { _dEDate = value; }
        }
        public string StrLogCode
        {
            get { return _strLogCode; }
            set { _strLogCode = value; }
        }
        public string StrLogString
        {
            get { return _strLogString; }
            set { _strLogString = value; }
        }
        public string IdxRealConn
        {
            get { return _idxRealConn; }
            set { _idxRealConn = value; }
        }
        public string StrCMD
        {
            get { return _strCMD; }
            set { _strCMD = value; }
        }
        public string StrID
        {
            get { return _strID; }
            set { _strID = value; }
        }
        public string StrPWD
        {
            get { return _strPWD; }
            set { _strPWD = value; }
        }
        public string StrIP
        {
            get { return _strIP; }
            set { _strIP = value; }
        }
        public string StrMac
        {
            get { return _strMac; }
            set { _strMac = value; }
        }
        public string StrPID
        {
            get { return _strPID; }
            set { _strPID = value; }
        }
        public string StrLangCode
        {
            get { return _strLangCode; }
            set { _strLangCode = value; }
        }
        public string StrProgCode
        {
            get { return _strProgCode; }
            set { _strProgCode = value; }
        }
        public string StrVersion
        {
            get { return _strVersion; }
            set { _strVersion = value; }
        }
        public string NUseOpt
        {
            get { return _nUseOpt; }
            set { _nUseOpt = value; }
        }
        public string NUseOpt2
        {
            get { return _nUseOpt2; }
            set { _nUseOpt2 = value; }
        }
        public string NUseOpt3
        {
            get { return _nUseOpt3; }
            set { _nUseOpt3 = value; }
        }
        public string NUseOpt4
        {
            get { return _nUseOpt4; }
            set { _nUseOpt4 = value; }
        }
        public string NNationalOpt
        {
            get { return _nNationalOpt; }
            set { _nNationalOpt = value; }
        }
        public string StrProtectKey
        {
            get { return _strProtectKey; }
            set { _strProtectKey = value; }
        }

/*
        public TB_Log_T(Object[] values)
        {
            this.TB_Log_Data = values;
            this.TB_Log_Data[1] = this.TB_Log_Data[1].ToString().Replace("/", "-");
            this.TB_Log_Data[2] = this.TB_Log_Data[2].ToString().Replace("/", "-");
        }
*/
        public TB_Log_T()
        {
            Initialize();
        }

        private void Initialize()
        {

            this._idx = string.Empty;
            this._dSDate = string.Empty;
            this._dEDate = string.Empty;
            this._strLogCode = string.Empty;
            this._strLogString = null;
            this._idxRealConn = string.Empty;
            this._strCMD = string.Empty;
            this._strID = string.Empty;
            this._strPWD = string.Empty;
            this._strIP = string.Empty;
            this._strMac = string.Empty;
            this._strPID = string.Empty;
            this._strLangCode = string.Empty;
            this._strProgCode = string.Empty;
            this._strVersion = string.Empty;
            this._nUseOpt = string.Empty;
            this._nUseOpt2 = string.Empty;
            this._nUseOpt3 = string.Empty;
            this._nUseOpt4 = string.Empty;
            this._nNationalOpt = string.Empty;
            this._strProtectKey = string.Empty;

        }
    }
}
