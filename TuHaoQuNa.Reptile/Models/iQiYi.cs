using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuHaoQuNa.Reptile.Models.iQiYi
{

    public class Rootobject
    {
        public Data data { get; set; }
        public string code { get; set; }
    }

    public class Data
    {
        public string code { get; set; }
        public Docinfo[] docinfos { get; set; }
        public string result_num { get; set; }
        public string qc { get; set; }
        public bool need_qc { get; set; }
        public bool isreplaced { get; set; }
        public string event_id { get; set; }
        public string bkt { get; set; }
        public string search_time { get; set; }
        public string server_time { get; set; }
        public string all_channels { get; set; }
        public string page_num { get; set; }
        public string page_size { get; set; }
        public string max_result_number { get; set; }
        public string real_query { get; set; }
        public string intent_type { get; set; }
        public string intent_result_num { get; set; }
        public bool has_unnormal_copyright { get; set; }
        public string index_layer { get; set; }
    }

    public class Docinfo
    {
        public string doc_id { get; set; }
        public float score { get; set; }
        public string pos { get; set; }
        public Albumdocinfo albumDocInfo { get; set; }
        public string sort { get; set; }
        public bool is_from_intent { get; set; }
    }

    public class Albumdocinfo
    {
        public string albumId { get; set; }
        public string albumTitle { get; set; }
        public string albumAlias { get; set; }
        public string albumEnglishTitle { get; set; }
        public string channel { get; set; }
        public string albumLink { get; set; }
        public string albumVImage { get; set; }
        public string albumHImage { get; set; }
        public string director { get; set; }
        public string star { get; set; }
        public string region { get; set; }
        public string season { get; set; }
        public string releaseDate { get; set; }
        public string itemTotalNumber { get; set; }
        public string siteName { get; set; }
        public string siteId { get; set; }
        public string albumImg { get; set; }
        public string contentType { get; set; }
        public string isPurchase { get; set; }
        public float score { get; set; }
        public bool series { get; set; }
        public string threeCategory { get; set; }
        public string tvFocus { get; set; }
        public string videoDocType { get; set; }
        public bool isDownload { get; set; }
        public bool is3D { get; set; }
        public Videoinfo[] videoinfos { get; set; }
        public bool is_exclusive { get; set; }
        public string qipu_id { get; set; }
        public Video_Lib_Meta video_lib_meta { get; set; }
        public string latest_update_time { get; set; }
        public bool is_qiyi_produced { get; set; }
        public string bitrate { get; set; }
        public bool is_third_party_vip { get; set; }
        public bool is_domestic_only { get; set; }
        public string access_play_control_platform { get; set; }
        public string downloadable_platforms { get; set; }
        public Super_Show_Cluster super_show_cluster { get; set; }
        public bool is_member_downloadable_only { get; set; }
        public string paymark { get; set; }
        public Circle_Summaries[] circle_summaries { get; set; }
        public bool is_pano { get; set; }
        public int[] universal_search_order { get; set; }
        public string secret_link { get; set; }
        public string tag { get; set; }
        public string playCount { get; set; }
        public string source { get; set; }
        public string sourceCode { get; set; }
        public string album_type { get; set; }
        public string is_boss_mixer { get; set; }
        public Black_Platform_Region[] black_platform_region { get; set; }
        public string albumSubTitle { get; set; }
        public bool on_demand { get; set; }
        public string stragyTime { get; set; }
        public string newest_item_number { get; set; }
        public string super_album_order { get; set; }
    }

    public class Video_Lib_Meta
    {
        public string entity_id { get; set; }
        public string title { get; set; }
        public Director[] director { get; set; }
        public Actor[] actor { get; set; }
        public string total_video_count { get; set; }
        public string duration { get; set; }
        public string china_publish_date { get; set; }
        public string poster { get; set; }
        public string[] language { get; set; }
        public string[] region { get; set; }
        public string[] category { get; set; }
        public string link { get; set; }
        public long? douban_id { get; set; }
        public string filmtv_update_strategy { get; set; }
        public string description { get; set; }
        public string alias { get; set; }
        public Host[] host { get; set; }
        public string season { get; set; }
    }

    public class Director
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
    }

    public class Actor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
    }

    public class Host
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
    }

    public class Super_Show_Cluster
    {
    }

    public class Videoinfo
    {
        public string itemTitle { get; set; }
        public string itemNumber { get; set; }
        public string itemHImage { get; set; }
        public string itemLink { get; set; }
        public string timeLength { get; set; }
        public string playedNumber { get; set; }
        public string initialIssueTime { get; set; }
        public string tvId { get; set; }
        public string vid { get; set; }
        public bool is1080p { get; set; }
        public string year { get; set; }
        public string uploadTime { get; set; }
        public string itemshortTitle { get; set; }
        public string qipu_id { get; set; }
        public bool is_new { get; set; }
        public bool is_vip { get; set; }
        public bool is_domestic_only { get; set; }
        public string access_play_control_platform { get; set; }
        public bool is_dolby { get; set; }
        public string downloadable_platforms { get; set; }
        public bool is_pano { get; set; }
        public string secret_link { get; set; }
        public string subTitle { get; set; }
        public string albumId { get; set; }
        public string itemUploadID { get; set; }
        public string p2pLink { get; set; }
    }

    public class Circle_Summaries
    {
        public string id { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public string description { get; set; }
        public string circle_type { get; set; }
        public string circle_user_count { get; set; }
        public string hadMaster { get; set; }
        public string celebrity_id { get; set; }
    }

    public class Black_Platform_Region
    {
        public string play_platform { get; set; }
        public Location[] location { get; set; }
    }

    public class Location
    {
        public string province { get; set; }
        public string province_id { get; set; }
        public string country { get; set; }
        public string country_id { get; set; }
        public string area { get; set; }
        public string area_id { get; set; }
    }


}

namespace TuHaoQuNa.Reptile.Models.iQiYi.Palyer
{


    public class Rootobject
    {
        public Mixinvideo[] mixinVideos { get; set; }
        public string page { get; set; }
        public string size { get; set; }
        public string total { get; set; }
        public string part { get; set; }
    }

    public class Mixinvideo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string tvId { get; set; }
        public string vid { get; set; }
        public string url { get; set; }
        public string playCount { get; set; }
        public string albumId { get; set; }
        public string videoType { get; set; }
        public Crumblist[] crumbList { get; set; }
        public User user { get; set; }
        public string duration { get; set; }
        public string upCount { get; set; }
        public string downCount { get; set; }
        public string imageUrl { get; set; }
        public string issueTime { get; set; }
        public Category[] categories { get; set; }
        public string channelId { get; set; }
        public string latestOrder { get; set; }
        public string updateFlag { get; set; }
        public string subtitle { get; set; }
        public int? isPurchase { get; set; }
        public string commentCount { get; set; }
        public string shareCount { get; set; }
        public string downloadAllowed { get; set; }
        public string logoId { get; set; }
        public string logoPosition { get; set; }
        public string userId { get; set; }
        public string season { get; set; }
        public string period { get; set; }
        public string exclusive { get; set; }
        public string albumName { get; set; }
        public string qitanId { get; set; }
        public int? order { get; set; }
        public string baikeUrl { get; set; }
        public string mode1080p { get; set; }
        public string mode720p { get; set; }
        public string dolby { get; set; }
        public string albumImageUrl { get; set; }
        public string posterUrl { get; set; }
        public string series { get; set; }
        public string filmId { get; set; }
        public string playlistReason { get; set; }
        public string effective { get; set; }
        public string qiyiProduced { get; set; }
        public string albumUrl { get; set; }
        public string sourceId { get; set; }
        public string focus { get; set; }
        public string videoCount { get; set; }
        public string videoImageUrl { get; set; }
        public string albumQipuId { get; set; }
        public string qipuId { get; set; }
        public int[] platforms { get; set; }
        public string crFreeStartDate { get; set; }
        public string dimension { get; set; }
        public string videoPageStatus { get; set; }
        public string copyrightStatus { get; set; }
        public string shortTitle { get; set; }
        public string solo { get; set; }
        public string latestUrl { get; set; }
        public string latestId { get; set; }
        public string albumFocus { get; set; }
        public string purchaseType { get; set; }
        public string displayBulletHell { get; set; }
        public Ppsbase ppsBase { get; set; }
        public string contentType { get; set; }
        public string fgtwVideo { get; set; }
        public string topChart { get; set; }
        public string isPpsExclusiveStatus { get; set; }
        public object[] topicIds { get; set; }
        public object[] notices { get; set; }
        public string commentAllowed { get; set; }
        public float score { get; set; }
        public object[] seoKeywords { get; set; }
        public Panorama panorama { get; set; }
        public string bossMixerAlbum { get; set; }
        public string ppsUrl { get; set; }
        public string publicLevel { get; set; }
        public string relatedKeyword { get; set; }
        public string featureKeyword { get; set; }
        public object[] votes { get; set; }
        public string featureAlbumId { get; set; }
        public string resolution { get; set; }
        public string editorInfo { get; set; }
        public string paikeType { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public Circle circle { get; set; }
        public string displayCircle { get; set; }
        public string payMark { get; set; }
        public string rewardAllowed { get; set; }
        public string rewardMessage { get; set; }
        public string albumBossStatus { get; set; }
        public object[] supportedDrmTypes { get; set; }
        public string ablumQipuId { get; set; }
        public string ipId { get; set; }
        public Intellectual intellectual { get; set; }
        public string qualityImageUrl { get; set; }
        public long[] feedIds { get; set; }
        public string programId { get; set; }
        public string irChannelId { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string description { get; set; }
        public string profileUrl { get; set; }
        public string ppsUrl { get; set; }
    }

    public class Ppsbase
    {
        public string name { get; set; }
        public string channelId { get; set; }
        public string pageStatus { get; set; }
        public string focus { get; set; }
        public string imageUrl { get; set; }
        public string posterImageUrl { get; set; }
        public string pageUrl { get; set; }
    }

    public class Panorama
    {
        public string videoType { get; set; }
        public float videwAngleX { get; set; }
        public float viewAangleY { get; set; }
        public float zoomRate { get; set; }
    }

    public class Circle
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Intellectual
    {
        public string id { get; set; }
        public string deleted { get; set; }
        public int[] books { get; set; }
        public object[] tickets { get; set; }
        public object[] games { get; set; }
        public object[] comicbooks { get; set; }
    }

    public class Crumblist
    {
        public string title { get; set; }
        public string level { get; set; }
        public string url { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string subName { get; set; }
        public string subType { get; set; }
        public string level { get; set; }
        public string qipuId { get; set; }
        public string parentId { get; set; }
    }


}
