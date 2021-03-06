﻿using System;
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

        public bool uploadvid(Video vid)
        {
            return connector.VideoUpload(vid);
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

        public string lenghtconverter(int secs)
        {
            string returnstring = string.Empty;
            int time = secs;
            int hours = 0;
            int minutes = 0;
            while(time / 3600 >= 1)
            {
                hours = hours + 1;
                time = time - 3600;
            }
            while(time / 60 >= 1)
            {
                minutes = minutes + 1;
                time = time - 60;
            }

            if (hours == 0)
                returnstring += "00:";
            else if (hours < 10)
                returnstring += "0" + hours + ":";
            else
                returnstring += hours;
            if (minutes == 0)
                returnstring += "00:";
            else if (minutes < 10)
                returnstring += "0" + minutes + ":";
            else
                returnstring += minutes;
            if (time == 0)
                returnstring += "00";
            else if (time < 10)
                returnstring += "0" + time;
            else
                returnstring += time;

            return returnstring;
        }

        public Video GetVid(int id)
        {
            return connector.GetVidByID(id);
        }
    }
}