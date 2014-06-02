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
        private Controller() 
        {
            Channels = new List<Channel>();
        }

        // Via een static read-only property kan de instantie benaderd worden.
        public static Controller Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        List<Channel> Channels;

        private DBConnect connector = new DBConnect();

        public string LogIn(string userName, string password) 
        {
            return connector.LogIn(userName, password);
        }

        public void NewAccount(string userName, string password)
        {
            connector.CreateAccount(userName, password);
        }

        public void upgradeAccount(string userName, string channelName, bool adds, string desc)
        {
            connector.UpgradeAccount(userName, channelName, adds, desc);
        }

        public string GetSubs(string ChannelName)
        {
            foreach (Channel a in Channels)
            {
                if (a.Name == ChannelName && a.TimeOut < DateTime.Now)
                {
                    return a.Subscribers.ToString();
                }
            }
            Channel temp = connector.GetChannel(ChannelName);
            Channels.Add(temp);
            return temp.Subscribers.ToString();
        }

        public string GetDisc(string ChannelName)
        {
            foreach (Channel a in Channels)
            {
                if (a.Name == ChannelName && a.TimeOut < DateTime.Now)
                {
                    return a.ChannelDiscription;
                }
            }
            Channel temp = connector.GetChannel(ChannelName);
            Channels.Add(temp);
            return temp.ChannelDiscription;
        }

        public void Subscribe(string channelName, string userName)
        {
            connector.Subscribe(channelName, userName);
        }
    }
}