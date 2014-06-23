using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// Summary description for Video
    /// </summary>
    public class Video
    {
        public string VideoName{get; private set;}

        public string ChannelName{get; private set;}

        public string FilePath { get; private set; }

        public int Lenght {get; private set;}

        public int Likes {get; private set;}

        public int Dislikes {get; private set;}

        public List<string> Tags {get; private set;}

        public Video(string name, string channelName, int lenght, string filepath)
        {
            this.VideoName = name;
            this.ChannelName = channelName;
            this.Lenght = lenght;
            this.FilePath = filepath;
        }

        public Video(string name, string channelName, int lenght, string filepath, int likes, int dislikes)
        {
            this.VideoName = name;
            this.ChannelName = channelName;
            this.Lenght = lenght;
            this.FilePath = filepath;
            this.Likes = likes;
            this.Dislikes = dislikes;
        }

        public void Like()
        {
            throw new NotImplementedException();
        }

        public void Dislike()
        {
            throw new NotImplementedException();
        }

        public void NewComment()
        {
            throw new NotImplementedException();
        }
    }
}