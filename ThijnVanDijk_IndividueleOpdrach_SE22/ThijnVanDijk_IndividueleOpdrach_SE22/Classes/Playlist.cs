using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// Summary description for Playlist
    /// </summary>
    public class Playlist
    {
        public Playlist()
        {
            throw new NotImplementedException();
        }

        public string PlaylistName {get; private set;}

        public List<Video> Videos {get; private set;}

        public Channel Channel {get; private set;}

        public void AddVideo()
        {
            throw new NotImplementedException();
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }

        public void DeleteVideo()
        {
            throw new NotImplementedException();
        }
    }
}