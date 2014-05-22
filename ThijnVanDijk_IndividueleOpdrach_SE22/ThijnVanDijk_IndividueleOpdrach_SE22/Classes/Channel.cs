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
        public Channel()
        {
            throw new NotImplementedException();
        }

        public string Name{get; private set;}

        public List<Video> Videos {get; private set;}

        public string ChannelDiscription { get; private set; }

        public Account Account { get; private set; }

        public bool UploadVideo()
        {
            throw new NotImplementedException();
        }
    }
}