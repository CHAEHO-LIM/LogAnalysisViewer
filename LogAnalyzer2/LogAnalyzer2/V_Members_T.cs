using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace LogAnalyzer2
{
    public class V_Members_T
    {

        private string _id;
        private string _first_name;
        private string _last_name;
        private string _eng_first_name;
        private string _eng_last_name;
        private string _email;
        private string _mobile;
        private string _fax;
        private string _telephone;
        private string _enterprise_name;
        private string _department_name;
        private string _duty;
        private string _address;
        private string _area_code;
        private string _regist_datetime;
        private string _update_datetime;

/*
        private object[] V_Members_data;

        public string Id
        {
            get { return V_Members_data[0].ToString(); }
            set { V_Members_data[0] = value; }
        }
        public string First_name
        {
            get { return V_Members_data[1].ToString(); }
            set { V_Members_data[1] = value; }
        }
        public string Last_name
        {
            get { return V_Members_data[2].ToString(); }
            set { V_Members_data[2] = value; }
        }
        public string Eng_first_name
        {
            get { return V_Members_data[3].ToString(); }
            set { V_Members_data[3] = value; }
        }
        public string Eng_last_name
        {
            get { return V_Members_data[4].ToString(); }
            set { V_Members_data[4] = value; }
        }
        public string Email
        {
            get { return V_Members_data[5].ToString(); }
            set { V_Members_data[5] = value; }
        }
        public string Mobile
        {
            get { return V_Members_data[6].ToString(); }
            set { V_Members_data[6] = value; }
        }
        public string Fax
        {
            get { return V_Members_data[7].ToString(); }
            set { V_Members_data[7] = value; }
        }
        public string Telephone
        {
            get { return V_Members_data[8].ToString(); }
            set { V_Members_data[8] = value; }
        }
        public string Enterprise_name
        {
            get { return V_Members_data[9].ToString(); }
            set { V_Members_data[9] = HttpUtility.HtmlDecode(value); }
            //            set { _enterprise_name = value; }
        }
        public string Department_name
        {
            get { return V_Members_data[10].ToString(); }
            set { V_Members_data[10] = value; }
        }
        public string Duty
        {
            get { return V_Members_data[11].ToString(); }
            set { V_Members_data[11] = value; }
        }
        public string Address
        {
            get { return V_Members_data[12].ToString(); }
            set { V_Members_data[12] = value; }
        }
        public string Area_code
        {
            get { return V_Members_data[13].ToString(); }
            set { V_Members_data[13] = value; }
        }
        public string Regist_datetime
        {
            get { return V_Members_data[14].ToString(); }
            set { V_Members_data[14] = value; }
        }
        public string Update_datetime
        {
            get { return V_Members_data[15].ToString(); }
            set { V_Members_data[15] = value; }
        }
*/

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string First_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        public string Last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public string Eng_first_name
        {
            get { return _eng_first_name; }
            set { _eng_first_name = value; }
        }
        public string Eng_last_name
        {
            get { return _eng_last_name; }
            set { _eng_last_name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        public string Enterprise_name
        {
            get { return _enterprise_name; }
            set { _enterprise_name = HttpUtility.HtmlDecode(value); }
//            set { _enterprise_name = value; }
        }
        public string Department_name
        {
            get { return _department_name; }
            set { _department_name = value; }
        }
        public string Duty
        {
            get { return _duty; }
            set { _duty = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Area_code
        {
            get { return _area_code; }
            set { _area_code = value; }
        }
        public string Regist_datetime
        {
            get { return _regist_datetime; }
            set { _regist_datetime = value; }
        }
        public string Update_datetime
        {
            get { return _update_datetime; }
            set { _update_datetime = value; }
        }


/*
        public V_Members_T(object[] values)
        {
            this.V_Members_data = values;
            V_Members_data[9] = HttpUtility.HtmlDecode(V_Members_data[9].ToString());
        }
*/
        public V_Members_T()
        {
            Initialize();
        }

        private void Initialize()
        {

            this._id = string.Empty;
            this._first_name = string.Empty;
            this._last_name = string.Empty;
            this._eng_first_name = string.Empty;
            this._eng_last_name = string.Empty;
            this._email = string.Empty;
            this._mobile = string.Empty;
            this._fax = string.Empty;
            this._telephone = string.Empty;
            this._enterprise_name = string.Empty;
            this._department_name = string.Empty;
            this._duty = string.Empty;
            this._address = string.Empty;
            this._area_code = string.Empty;
            this._regist_datetime = string.Empty;
            this._update_datetime = string.Empty;

        }
    }
}
