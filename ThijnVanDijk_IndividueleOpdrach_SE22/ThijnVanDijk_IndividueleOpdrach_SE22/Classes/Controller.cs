using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class Controller
    {
        private static Controller _instance = new Controller();
        private List<Channel> channels;
        private DBConnect connector = new DBConnect();

        private Controller() 
        {
            this.channels = new List<Channel>();
        }

        public static Controller Instance
        {
            get
            {
                return _instance;
            }
        }

        public string LogIn(string userName, string password) 
        {
            return this.connector.LogIn(userName, password);
        }

        public void NewAccount(string userName, string password)
        {
            this.connector.CreateAccount(userName, password);
        }

        public void UpgradeAccount(string userName, string channelName, bool adds, string desc)
        {
            this.connector.UpgradeAccount(userName, channelName, adds, desc);
        }

        public string GetSubs(string channelName)
        {
            Channel temp = this.connector.GetChannel(channelName);
            this.channels.Add(temp);
            if (temp != null)
            {
                return temp.Subscribers.ToString();
            }
            return string.Empty;
        }

        public string GetDisc(string channelName)
        {
            foreach (Channel a in this.channels)
            {
                if (a != null)
                {
                    if (a.Name == channelName)
                    {
                        return a.ChannelDiscription;
                    }
                }
            }
            Channel temp = this.connector.GetChannel(channelName);
            this.channels.Add(temp);
            if(temp != null)
            {
                return temp.ChannelDiscription;
            }
            return string.Empty;
        }

        public void Subscribe(string channelName, string userName)
        {
            this.connector.Subscribe(channelName, userName);
        }
    }
}