using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class Controller
    {
        #region singleton
        // Thread-safe oplossing om slechts één instantie aan te maken.
        private static Controller _instance = new Controller();

        // Private constructor om te voorkomen dat anderen een instantie kunnen aanmaken.
        private Controller() { }

        // Via een static read-only property kan de instantie benaderd worden.
        public static Controller Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private DBConnect connector = new DBConnect();

        public string LogIn(string userName, string password) 
        {
            return connector.LogIn(userName, password);
        }

        public void NewAccount(string userName, string password)
        {
            connector.CreateAccount(userName, password);
        }

        public void upgradeAccount(string userName, string channelName, bool adds)
        {
            connector.UpgradeAccount(userName, channelName, adds);
        }

        public string GetSubs(string ChannelName)
        {
            return connector.GetSubs(ChannelName);
        }

        public void Subscribe(string channelName, string userName)
        {
            connector.Subscribe(channelName, userName);
        }
    }
}