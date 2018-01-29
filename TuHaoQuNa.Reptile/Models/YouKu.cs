using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Reptile.Models.YouKu
{

    public class Rootobject
    {
        public string cateId { get; set; }
        public string cateName { get; set; }
        public string channelUrl { get; set; }
        public string showid_en { get; set; }
        public string showid { get; set; }
        public string videoId { get; set; }
        public string doubanKey { get; set; }
        public string doubanId { get; set; }
        public string ownerId { get; set; }
        public string size { get; set; }
        public string copytoclip { get; set; }
    }

}

namespace TuHaoQuNa.Reptile.Models.YouKu.Player
{

    public class Rootobject
    {
        public int error { get; set; }
        public string message { get; set; }
        public string html { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string tab { get; set; }
        public string callback { get; set; }
        public string _ { get; set; }
        public string token { get; set; }
        public string view { get; set; }
    }

}
