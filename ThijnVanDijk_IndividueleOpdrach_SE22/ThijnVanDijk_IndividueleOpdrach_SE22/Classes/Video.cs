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

        public Channel Channel{get; private set;}

        public string Lenght {get; private set;}

        public int Likes {get; private set;}

        public int Dislikes {get; private set;}

        public List<string> Tags {get; private set;}

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