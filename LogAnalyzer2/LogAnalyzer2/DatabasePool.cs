using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogAnalyzer2
{
    public class DatabasePool
    {
        private List<TB_Log_T> _TB_Log_List;
        private List<MidasUpdate_nIP_T> _MidasUpdate_nIP_List;
        private Dictionary<string,V_Node_T> _V_Node_Dic;
        private Dictionary<string, V_Members_T> _V_Members_Dic;
//        private Dictionary<string,ModuleID_Log_T> _ModuleID_Log_Dic;

        private static DatabasePool _instance;
        public static DatabasePool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabasePool();
                return _instance;
            }
        }

        public List<TB_Log_T> TB_Log_List
        {
            get { return _TB_Log_List; }
            set { _TB_Log_List = value; }
        }

        public List<MidasUpdate_nIP_T> MidasUpdate_nIP_List
        {
            get { return _MidasUpdate_nIP_List; }
            set { _MidasUpdate_nIP_List = value; }
        }

        public Dictionary<string,V_Node_T> V_Node_Dic
        {
            get { return _V_Node_Dic; }
            set { _V_Node_Dic = value; }
        }

        public Dictionary<string, V_Members_T> V_Members_Dic
        {
            get { return _V_Members_Dic; }
            set { _V_Members_Dic = value; }
        }

        public DatabasePool()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (_TB_Log_List == null)
                _TB_Log_List = new List<TB_Log_T>();
            else
                _TB_Log_List.Clear();

            if (_MidasUpdate_nIP_List == null)
                _MidasUpdate_nIP_List = new List<MidasUpdate_nIP_T>();
            else
                _MidasUpdate_nIP_List.Clear();

            if (_V_Node_Dic == null)
                _V_Node_Dic = new Dictionary<string,V_Node_T>();
            else
                _V_Node_Dic.Clear();

            if (_V_Members_Dic == null)
                _V_Members_Dic = new Dictionary<string, V_Members_T>();
            else
                _V_Members_Dic.Clear();
        }

        

    }
}
