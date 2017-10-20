using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set { _enterprise_name = value; }
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
