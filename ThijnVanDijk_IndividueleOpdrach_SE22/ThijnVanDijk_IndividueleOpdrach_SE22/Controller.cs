using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class Controller
    {
        public DBConnect Connector;
        public Controller()
        {
            Connector = new DBConnect();
        }

        public List<Account> accounts { get; private set; }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}