using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class DBConnect
    {
        public OracleConnection conn;
        string pcn = "dbi292195";
        string pw = "kd1qoIM98M";
        private int fileIdIn;
        private int reactieIdIn;

        public DBConnect()
        {
            conn = new OracleConnection();
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + " //192.168.15.50:1521/fhictora" + ";";
        }
      
    }
}