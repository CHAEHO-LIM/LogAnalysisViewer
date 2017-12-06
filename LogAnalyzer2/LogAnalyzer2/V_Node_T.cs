using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogAnalyzer2
{
    public class V_Node_T
    {

        private string _enterprise_code;
        private string _enterprise_name;
        private string _department_code;
        private string _department_name;
        private string _node_sn;
        private string _id;
        private string _node_name;
        private string _mac;
        private string _ip;
        private string _regist_timestamp;
        private string _use_yn;

/*
        private object[] V_Node_data;

        public string Enterprise_code
        {
            get { return V_Node_data[0].ToString(); }
            set { V_Node_data[0] = value; }
        }
        public string Enterprise_name
        {
            get { return V_Node_data[1].ToString(); }
            set { V_Node_data[1] = value; }
        }
        public string Department_code
        {
            get { return V_Node_data[2].ToString(); }
            set { V_Node_data[2] = value; }
        }
        public string Department_name
        {
            get { return V_Node_data[3].ToString(); }
            set { V_Node_data[3] = value; }
        }
        public string Node_sn
        {
            get { return V_Node_data[4].ToString(); }
            set { V_Node_data[4] = value; }
        }
        public string Id
        {
            get { return V_Node_data[5].ToString(); }
            set { V_Node_data[5] = value; }
        }
        public string Node_name
        {
            get { return V_Node_data[6].ToString(); }
            set { V_Node_data[6] = value; }
        }
        public string Mac
        {
            get { return V_Node_data[7].ToString(); }
            set { V_Node_data[7] = value; }
        }
        public string Ip
        {
            get { return V_Node_data[8].ToString(); }
            set { V_Node_data[8] = value; }
        }
        public string Regist_timestamp
        {
            get { return V_Node_data[9].ToString(); }
            set { V_Node_data[9] = value; }
        }
        public string Use_yn
        {
            get { return V_Node_data[10].ToString(); }
            set { V_Node_data[10] = value; }
        }
*/

        public string Enterprise_code
        {
            get { return _enterprise_code; }
            set { _enterprise_code = value; }
        }
        public string Enterprise_name
        {
            get { return _enterprise_name; }
            set { _enterprise_name = value; }
        }
        public string Department_code
        {
            get { return _department_code; }
            set { _department_code = value; }
        }
        public string Department_name
        {
            get { return _department_name; }
            set { _department_name = value; }
        }
        public string Node_sn
        {
            get { return _node_sn; }
            set { _node_sn = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Node_name
        {
            get { return _node_name; }
            set { _node_name = value; }
        }
        public string Mac
        {
            get { return _mac; }
            set { _mac = value; }
        }
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string Regist_timestamp
        {
            get { return _regist_timestamp; }
            set { _regist_timestamp = value; }
        }
        public string Use_yn
        {
            get { return _use_yn; }
            set { _use_yn = value; }
        }

/*
        public V_Node_T(object[] values)
        {
            this.V_Node_data = values;
            //            if (this.V_Node_data[9] == null) V_Node_data[9] = "";
            //            if (this.V_Node_data[10] == null) V_Node_data[10] = "";
        }
*/
        public V_Node_T()
        {
            Initialize();
        }

        private void Initialize()
        {

            this._enterprise_code = string.Empty;
            this._enterprise_name = string.Empty;
            this._department_code = string.Empty;
            this._department_name = string.Empty;
            this._node_sn = string.Empty;
            this._id = string.Empty;
            this._node_name = string.Empty;
            this._mac = string.Empty;
            this._ip = string.Empty;
            this._regist_timestamp = string.Empty;
            this._use_yn = string.Empty;

        }
    }
}
