using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogAnalyzer2
{
    public class ModuleID_Log_T
    {
/*
        private string _strPID;
        private string _nProductID;
*/

        private object[] ModuleID_Log_data;

        public string strPID
        {
            get { return ModuleID_Log_data[0].ToString(); }
            set { ModuleID_Log_data[0] = value; }
        }
        public string nProductID
        {
            get { return ModuleID_Log_data[1].ToString(); }
            set { ModuleID_Log_data[1] = value; }
        }

/*
        public string strPID
        {
            get { return _strPID; }
            set { _strPID = value; }
        }
        public string nProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
*/

        public ModuleID_Log_T(object[] values)
        {
            this.ModuleID_Log_data = values;
        }

        public ModuleID_Log_T()
        {
            Initialize();
        }

        private void Initialize()
        {
/*
            this._strPID = string.Empty;
            this._nProductID = string.Empty;
*/
        }
    }
}
