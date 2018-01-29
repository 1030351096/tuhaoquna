using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Reptile.Models.QQ.Player
{

    public class Rootobject
    {
        public Playlistitem PlaylistItem { get; set; }
        public string error { get; set; }
        public string msg { get; set; }
    }

    public class Playlistitem
    {
        public string asyncParam { get; set; }
        public object[] btnList { get; set; }
        public string btnPlayUrl { get; set; }
        public string btnTitle { get; set; }
        public string displayType { get; set; }
        public string[] indexList { get; set; }
        public string name { get; set; }
        public bool needAsync { get; set; }
        public string payType { get; set; }
        public string realName { get; set; }
        public string title { get; set; }
        public string totalEpisode { get; set; }
        public Videoplaylist[] videoPlayList { get; set; }
    }

    public class Videoplaylist
    {
        public string id { get; set; }
        public Marklabellist[] markLabelList { get; set; }
        public string payType { get; set; }
        public string pic { get; set; }
        public string playUrl { get; set; }
        public string title { get; set; }
    }

    public class Marklabellist
    {
        public string markImageUrl { get; set; }
        public string position { get; set; }
        public string primeText { get; set; }
        public string type { get; set; }
    }

}
