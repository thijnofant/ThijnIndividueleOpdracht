using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// 
    /// </summary>
    public class Channel
    {
        public Channel(int channelID, string name, string discription, bool adds)
        {
            TimeOut = DateTime.Now.AddMinutes(10);

            this.ChannelID = channelID;
            this.Name = name;
            this.ChannelDiscription = discription;
            this.EnabledForAdds = adds;
        }

        public void SetSubscribers(int subs)
        {
            Subscribers = subs;
        }

        public DateTime TimeOut { get; private set; }

        public bool EnabledForAdds {get; private set;}

        public int ChannelID {get; private set;}

        public string Name{get; private set;}

        public List<Video> Videos {get; private set;}

        public string ChannelDiscription { get; private set; }

        public Account Account { get; private set; }

        public int Subscribers { get; private set; }

        public bool UploadVideo()
        {
            throw new NotImplementedException();
        }
    }
}