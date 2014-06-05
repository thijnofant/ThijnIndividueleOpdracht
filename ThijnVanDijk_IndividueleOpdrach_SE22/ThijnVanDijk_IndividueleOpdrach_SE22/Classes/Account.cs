using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// The Account class 
    /// </summary>
    public class Account
    {
        public Account()
        {
        }

        public string Name { get; private set; }

        public List<Channel> Subscribtion { get; private set; }

        public DataTable GetSubsVids()
        {
            return null;
        }
    }
}