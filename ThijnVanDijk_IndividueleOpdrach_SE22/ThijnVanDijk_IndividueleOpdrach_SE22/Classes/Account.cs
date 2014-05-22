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
            throw new NotImplementedException();
        }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public List<Channel> Subscribtion { get; private set; }

        public bool Upgrade()
        {
            throw new NotImplementedException();
        }

        public bool LogIn(string password)
        {
            throw new NotImplementedException();
        }
    }
}