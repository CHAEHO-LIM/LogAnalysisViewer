using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzer2
{
    public class LogFilter
    {
        public string UserID;
        public string Company;
        public string UserIP;
        private InputParam _inputParam;
        List<string> _CompanyIPList;

        public LogFilter(InputParam param)
        {
            Initialize();
            _inputParam = param;
        }

        private void Initialize()
        {
            this.UserID = string.Empty;
            this.Company = string.Empty;
            this.UserIP = string.Empty;
            _CompanyIPList = new List<string>();
            _CompanyIPList.Add("124.110.62");//.155");
            _CompanyIPList.Add("121.157.60");//.6");
            //_CompanyIPList.Add("121.157.60.7");
            //_CompanyIPList.Add("121.157.60.30");
        }

        public bool IsShowData()
        {
            if (this.UserIP.Contains(".") == true)//&& this.UserIP == "124.110.62.155")
            {
                string[] separator = new string[] { "." };
                string[] arrayIP = this.UserIP.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string ip3 = string.Format("{0}.{1}.{2}", arrayIP[0], arrayIP[1], arrayIP[2]);

                if (_CompanyIPList.Contains(ip3) == true)
                    return false;
            }

            if (this.UserIP != string.Empty)
            {
                uint IPAddr = 0;
                if (uint.TryParse(this.UserIP, out IPAddr) == true)
                {
                    string strIP = ConvertToIP(IPAddr);//new System.Net.IPAddress(IPAddr).ToString();

                    string[] separator = new string[] { "." };
                    string[] arrayIP = strIP.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string ip3 = string.Format("{0}.{1}.{2}", arrayIP[0], arrayIP[1], arrayIP[2]);

                    if (_CompanyIPList.Contains(ip3) == true)//if (strIP == "124.110.62.155")
                        return false;
                }
            }

            if (_inputParam.strFilterCompany != string.Empty)
            {
                if (!this.Company.ToLower().Contains(_inputParam.strFilterCompany.ToLower()) )
                    return false;
            }

            if (_inputParam.strFilterUserID != string.Empty)
            {
                if (!this.UserID.ToLower().Contains(_inputParam.strFilterUserID.ToLower()))
                    return false;
            }

            return true;
        }

        private string ConvertToIP(uint IPAddr)
        {
            //2^24  = 16777216
            //2^16  = 65536
            //2^8   = 256
            uint nIP1 = IPAddr / 16777216;
            uint nIP2 = (IPAddr - (nIP1 * 16777216)) / 65536;
            uint nIP3 = (IPAddr - (nIP1 * 16777216) - (nIP2 * 65536)) / 256;
            uint nIP4 = IPAddr - (nIP1 * 16777216) - (nIP2 * 65536) - (nIP3 * 256);
            string strIP = string.Format("{0}.{1}.{2}.{3}", nIP1, nIP2, nIP3, nIP4);
            return strIP;
        }
    }
}
