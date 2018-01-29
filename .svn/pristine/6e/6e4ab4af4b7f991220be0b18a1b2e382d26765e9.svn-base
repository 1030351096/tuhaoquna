using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Domain.Entity
{
    /// <summary>
    /// 电影详细信息
    /// </summary>
    public class Movie
    {
        #region 基础信息
        /// <summary>
		/// ID
		/// </summary>  
		public int ID { get; set; }
        /// <summary>
        /// 豆瓣ID
        /// </summary>  
        public string DouBanID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>  
        public string Name { get; set; }
        /// <summary>
        /// 评分
        /// </summary>  
        public decimal? Score { get; set; }
        /// <summary>
        /// 简介
        /// </summary>  
        public string Describe { get; set; }
        /// <summary>
        /// 类型
        /// </summary>  
        public Enum.Family Family { get; set; }
        /// <summary>
        /// 封面
        /// </summary>  
        public string Poster { get; set; }
        /// <summary>
        /// 年份
        /// </summary>  
        public int? Year { get; set; }
        #endregion
        #region 动态数据
        /// <summary>
        /// 影评数量
        /// </summary>  
        public int? ReviewsCount { get; set; }
        /// <summary>
        /// 想看人数
        /// </summary>  
        public int? WishCount { get; set; }
        /// <summary>
        /// 看过人数
        /// </summary>  
        public int? CollectCount { get; set; }
        /// <summary>
        /// 在看人数
        /// </summary>  
        public int? DoCount { get; set; }
        /// <summary>
        /// 短评数量
        /// </summary>  
        public int? CommentsCount { get; set; }
        /// <summary>
        /// 评分人数
        /// </summary>  
        public int? RatingsCount { get; set; }
        #endregion
        #region 详细信息
        /// <summary>
		/// 首映时间
		/// </summary>  
		public DateTime? PubDate { get; set; }
        /// <summary>
        /// 原名
        /// </summary>  
        public string OriginalTitle { get; set; }
        /// <summary>
        /// 豆瓣小站URL
        /// </summary>  
        public string DouBanSite { get; set; }
        /// <summary>
        /// 条目页URL
        /// </summary>  
        public string Alt { get; set; }
        /// <summary>
        /// 移动版条目页URL
        /// </summary>  
        public string MobileUrl { get; set; }
        /// <summary>
        /// 分享条目页URL
        /// </summary>  
        public string ShareUrl { get; set; }
        /// <summary>
        /// 影讯页URL
        /// </summary>  
        public string ScheduleUrl { get; set; }
        /// <summary>
        /// 官方网站
        /// </summary>  
        public string WebSite { get; set; }
        #endregion
        #region 集数季数
        /// <summary>
		/// 总季数
		/// </summary>  
		public int? SeasonsCount { get; set; }
        /// <summary>
        /// 当前季的集数
        /// </summary>  
        public int? EpisodesCount { get; set; }
        /// <summary>
        /// 当前季数
        /// </summary>  
        public int? CurrentSeason { get; set; }
        #endregion
        #region 其它信息
        /// <summary>
        /// 上映时间
        /// </summary>
        public List<PubData> PubDatas { get; set; }
        /// <summary>
        /// 又名
        /// </summary>
        public List<string> Aka { get; set; }
        /// <summary>
        /// 预告片
        /// </summary>
        public List<Preview> Trailers { get; set; }
        /// <summary>
        /// 花絮
        /// </summary>
        public List<Preview> Tidbits { get; set; }
        /// <summary>
        /// 片段
        /// </summary>
        public List<Preview> Fragments { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public List<string> Languages { get; set; }
        /// <summary>
        /// 剧照
        /// </summary>
        public List<string> Pictures { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// 电影类型
        /// </summary>
        public List<string> Categorys { get; set; }
        /// <summary>
        /// 制片国家地区
        /// </summary>
        public List<string> Countries { get; set; }
        /// <summary>
        /// 编剧
        /// </summary>
        public List<Celebrity> Screenwriters { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public List<Celebrity> Directors { get; set; }
        /// <summary>
        /// 演员
        /// </summary>
        public List<Celebrity> Performers { get; set; }
        /// <summary>
        /// 片长
        /// </summary>
        public List<Duration> Durations { get; set; }
        #endregion

    }

    /// <summary>
    /// 上映时间
    /// </summary>
    public class PubData
    {
        /// <summary>
		/// 上映时间
		/// </summary>  
		public DateTime PubDate { get; set; }
        /// <summary>
        /// 上映地点
        /// </summary>  
        public string PubPlace { get; set; }
    }

    /// <summary>
    /// 预览
    /// </summary>
    public class Preview
    {
        /// <summary>
		/// 标识
		/// </summary>  
		public string UID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>  
        public string Title { get; set; }
        /// <summary>
        /// 图片
        /// </summary>  
        public string Photo { get; set; }
        /// <summary>
        /// 视频
        /// </summary>  
        public string Video { get; set; }
    }

    /// <summary>
    /// 影人
    /// </summary>
    public class Celebrity
    {
        /// <summary>
        /// 影人豆瓣ID
        /// </summary>  
        public string DouBanID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>  
        public string Name { get; set; }
        /// <summary>
        /// 影人条目URL
        /// </summary>  
        public string Alt { get; set; }
        /// <summary>
        /// 影人头像
        /// </summary>  
        public string Avatar { get; set; }
    }

    /// <summary>
    /// 片长
    /// </summary>
    public class Duration
    {
        /// <summary>
        /// 时长
        /// </summary>
        public int LongTime { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string Plan { get; set; }
    }
}
