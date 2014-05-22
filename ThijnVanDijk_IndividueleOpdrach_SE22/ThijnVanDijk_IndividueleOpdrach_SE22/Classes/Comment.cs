using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    /// <summary>
    /// Summary description for Comment
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// This Constructor is used to make a comment on a video
        /// </summary>
        public Comment()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Constructor is used to make a reply on a comment
        /// </summary>
        public Comment()
        {
            throw new NotImplementedException();
        }

        public Video Video{get; private set;}

        public Comment Comment {get; private set;}

        public Account Account {get; private set;}

        public string Content {get; private set;}

        public void EditTekst(string newTekst)
        {
            throw new NotImplementedException();
        }
        
        public void NewReply(string replyTekst)
        {
            throw new NotImplementedException();
        }
    }
}
