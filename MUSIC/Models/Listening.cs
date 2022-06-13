using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MUSIC.Models;

namespace MUSIC.Models
{
    public class Listening
    {
        DBcontent db = new DBcontent();

        

        public int idbaihat { get; set; }
        public Listening(int id)
        {
            idbaihat = id;
            BAIHAT bAIHAT = db.BAIHATs.Single(n => n.idbaihat == id);
            tenbaihat=bAIHAT.tenbaihat;
            hinhbaihat=bAIHAT.hinhbaihat ;
            casi=bAIHAT.casi ;
            luotthich=bAIHAT.luotthich ;
            luotxem=bAIHAT.luotxem ;
            lyrics=bAIHAT.lyrics ;
            linkbaihat = bAIHAT.linkbaihat;
        }
        public string tenbaihat { get; set; }
        public string hinhbaihat { get; set; }
        public string casi { get; set; }
        public string linkbaihat { get; set; }
        public string lyrics { get; set; }
        public int? luotxem { get; set; }
        public int? luotthich { get; set; }
    }
}