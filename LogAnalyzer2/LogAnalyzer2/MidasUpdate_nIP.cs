using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer2
{
    public class MidasUpdate_nIP_T
    {
/*
        private string _regdate;
        private string _index_id;
        private string _ClientV;
        private string _ClientMac;
        private string _ClientIP;
        private string _ServerIP;
        private string _nProduct;
        private string _nBuildNum;
        private string _nLang;
        private string _nVer1;
        private string _nVer2;
        private string _nVer3;
        private string _nLic1;
        private string _nLic2;
        private string _nLic3;
        private string _nCRKC;
        private string _strLKNum;
        private string _chk_client;
        private string _strName;
        private string _strCountry;
        private string _txtWhois;
        private string _strMussID;
        private string _ExtLod;
        private string _PLFInfo;
        private string _ULog;
*/ 
        //연산에 의한 결과 값
        private string _MacAddress;


        private object[] MidasUpdate_nIP_Data;

        public string Regdate
        {
            get { return MidasUpdate_nIP_Data[0].ToString(); }
            set { MidasUpdate_nIP_Data[0] = value; }
        }
        public string Index_id
        {
            get { return MidasUpdate_nIP_Data[1].ToString(); }
            set { MidasUpdate_nIP_Data[1] = value; }
        }
        public string ClientV
        {
            get { return MidasUpdate_nIP_Data[2].ToString(); }
            set { MidasUpdate_nIP_Data[2] = value; }
        }
        public string ClientMac
        {
            get { return MidasUpdate_nIP_Data[3].ToString(); }
            set { MidasUpdate_nIP_Data[3] = value; }
        }
        public string ClientIP
        {
            get { return MidasUpdate_nIP_Data[4].ToString(); }
            set { MidasUpdate_nIP_Data[4] = value; }
        }
        public string ServerIP
        {
            get { return MidasUpdate_nIP_Data[5].ToString(); }
            set { MidasUpdate_nIP_Data[5] = value; }
        }
        public string NProduct
        {
            get { return MidasUpdate_nIP_Data[6].ToString(); }
            set { MidasUpdate_nIP_Data[6] = value; }
        }
        public string NBuildNum
        {
            get { return MidasUpdate_nIP_Data[7].ToString(); }
            set { MidasUpdate_nIP_Data[7] = value; }
        }
        public string NLang
        {
            get { return MidasUpdate_nIP_Data[8].ToString(); }
            set { MidasUpdate_nIP_Data[8] = value; }
        }
        public string NVer1
        {
            get { return MidasUpdate_nIP_Data[9].ToString(); }
            set { MidasUpdate_nIP_Data[9] = value; }
        }
        public string NVer2
        {
            get { return MidasUpdate_nIP_Data[10].ToString(); }
            set { MidasUpdate_nIP_Data[10] = value; }
        }
        public string NVer3
        {
            get { return MidasUpdate_nIP_Data[11].ToString(); }
            set { MidasUpdate_nIP_Data[11] = value; }
        }
        public string NLic1
        {
            get { return MidasUpdate_nIP_Data[12].ToString(); }
            set { MidasUpdate_nIP_Data[12] = value; }
        }
        public string NLic2
        {
            get { return MidasUpdate_nIP_Data[13].ToString(); }
            set { MidasUpdate_nIP_Data[13] = value; }
        }
        public string NLic3
        {
            get { return MidasUpdate_nIP_Data[14].ToString(); }
            set { MidasUpdate_nIP_Data[14] = value; }
        }
        public string NCRKC
        {
            get { return MidasUpdate_nIP_Data[15].ToString(); }
            set { MidasUpdate_nIP_Data[15] = value; }
        }
        public string StrLKNum
        {
            get { return MidasUpdate_nIP_Data[16].ToString(); }
            set { MidasUpdate_nIP_Data[16] = value; }
        }
        public string Chk_client
        {
            get { return MidasUpdate_nIP_Data[17].ToString(); }
            set { MidasUpdate_nIP_Data[17] = value; }
        }
        public string StrName
        {
            get { return MidasUpdate_nIP_Data[18].ToString(); }
            set { MidasUpdate_nIP_Data[18] = value; }
        }
        public string StrCountry
        {
            get { return MidasUpdate_nIP_Data[19].ToString(); }
            set { MidasUpdate_nIP_Data[19] = value; }
        }
        public string TxtWhois
        {
            get { return MidasUpdate_nIP_Data[20].ToString(); }
            set { MidasUpdate_nIP_Data[20] = value; }
        }
        public string StrMussID
        {
            get { return MidasUpdate_nIP_Data[21].ToString(); }
            set { MidasUpdate_nIP_Data[21] = value; }
        }
        public string ExtLod
        {
            get { return MidasUpdate_nIP_Data[22].ToString(); }
            set { MidasUpdate_nIP_Data[22] = value; }
        }
        public string PLFInfo
        {
            get { return MidasUpdate_nIP_Data[23].ToString(); }
            set { MidasUpdate_nIP_Data[23] = value; }
        }
        public string ULog
        {
            get { return MidasUpdate_nIP_Data[24].ToString(); }
            set { MidasUpdate_nIP_Data[24] = value; }
        }

/*
        public string Regdate
        {
            get { return _regdate; }
            set { _regdate = value; }
        }
        public string Index_id
        {
            get { return _index_id; }
            set { _index_id = value; }
        }
        public string ClientV
        {
            get { return _ClientV; }
            set { _ClientV = value; }
        }
        public string ClientMac
        {
            get { return _ClientMac; }
            set { _ClientMac = value; }
        }
        public string ClientIP
        {
            get { return _ClientIP; }
            set { _ClientIP = value; }
        }
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }
        public string NProduct
        {
            get { return _nProduct; }
            set { _nProduct = value; }
        }
        public string NBuildNum
        {
            get { return _nBuildNum; }
            set { _nBuildNum = value; }
        }
        public string NLang
        {
            get { return _nLang; }
            set { _nLang = value; }
        }
        public string NVer1
        {
            get { return _nVer1; }
            set { _nVer1 = value; }
        }
        public string NVer2
        {
            get { return _nVer2; }
            set { _nVer2 = value; }
        }
        public string NVer3
        {
            get { return _nVer3; }
            set { _nVer3 = value; }
        }
        public string NLic1
        {
            get { return _nLic1; }
            set { _nLic1 = value; }
        }
        public string NLic2
        {
            get { return _nLic2; }
            set { _nLic2 = value; }
        }
        public string NLic3
        {
            get { return _nLic3; }
            set { _nLic3 = value; }
        }
        public string NCRKC
        {
            get { return _nCRKC; }
            set { _nCRKC = value; }
        }
        public string StrLKNum
        {
            get { return _strLKNum; }
            set { _strLKNum = value; }
        }
        public string Chk_client
        {
            get { return _chk_client; }
            set { _chk_client = value; }
        }
        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }
        public string StrCountry
        {
            get { return _strCountry; }
            set { _strCountry = value; }
        }
        public string TxtWhois
        {
            get { return _txtWhois; }
            set { _txtWhois = value; }
        }
        public string StrMussID
        {
            get { return _strMussID; }
            set { _strMussID = value; }
        }
        public string ExtLod
        {
            get { return _ExtLod; }
            set { _ExtLod = value; }
        }
        public string PLFInfo
        {
            get { return _PLFInfo; }
            set { _PLFInfo = value; }
        }
        public string ULog
        {
            get { return _ULog; }
            set { _ULog = value; }
        }
*/

        public MidasUpdate_nIP_T(object[] values)
        {
//            Array.Copy(values,  this.MidasUpdate_nIP_Data, values.Length+1);
//            Buffer.BlockCopy(values, 0, this.MidasUpdate_nIP_Data, 0, values.Length);
            this.MidasUpdate_nIP_Data = values;
            MidasUpdate_nIP_Data[0] = MidasUpdate_nIP_Data[0].ToString().Replace("/", "-");
        }

        public MidasUpdate_nIP_T()
        {
            Initialize();
        }

        private void Initialize()
        {
/*
            this._regdate = string.Empty;
            this._index_id = string.Empty;
            this._ClientV = string.Empty;
            this._ClientMac = string.Empty;
            this._ClientIP = string.Empty;
            this._ServerIP = string.Empty;
            this._nProduct = string.Empty;
            this._nBuildNum = string.Empty;
            this._nLang = string.Empty;
            this._nVer1 = string.Empty;
            this._nVer2 = string.Empty;
            this._nVer3 = string.Empty;
            this._nLic1 = string.Empty;
            this._nLic2 = string.Empty;
            this._nLic3 = string.Empty;
            this._nCRKC = string.Empty;
            this._strLKNum = string.Empty;
            this._chk_client = string.Empty;
            this._strName = string.Empty;
            this._strCountry = string.Empty;
            this._txtWhois = string.Empty;
            this._strMussID = string.Empty;
            this._ExtLod = string.Empty;
            this._PLFInfo = string.Empty;
            this._ULog = string.Empty;
            this._MacAddress = string.Empty;
*/
        }

        public string GetMacAddress()
        {
            if (this._MacAddress != string.Empty)
                return this._MacAddress;

            string[] separator = new string[] { "/" };
            string[] strArray = this.ClientIP.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length > 1)
                this._MacAddress = strArray[1];
            return this._MacAddress;
        }
    }
}
