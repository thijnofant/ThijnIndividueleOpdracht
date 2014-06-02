using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// The Account class 
    /// </summary>
    public class Account
    {
        public Account()
        {
            TimeOut = DateTime.Now.AddMinutes(10);
        }

        public string Name { get; private set; }

        public List<Channel> Subscribtion { get; private set; }

        public DateTime TimeOut { get; private set; }
    }
}