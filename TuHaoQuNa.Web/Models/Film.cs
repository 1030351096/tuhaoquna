using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuHaoQuNa.Web.Models
{
    /// <summary>
    /// 影片
    /// </summary>
    public class Film
    {
        /// <summary>
        /// DouBanID
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
        /// 1电影,2电视剧
        /// </summary>  
        public int Family { get; set; }
        /// <summary>
        /// 封面
        /// </summary>  
        public string Poster { get; set; }
        /// <summary>
        /// 年份
        /// </summary>  
        public int? Year { get; set; }
    }

    /// <summary>
    /// 影片详细信息
    /// </summary>
    public class FilmInfo
    {
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
        /// 1电影,2电视剧
        /// </summary>  
        public int Family { get; set; }
        /// <summary>
        /// 封面
        /// </summary>  
        public string Poster { get; set; }
        /// <summary>
        /// 年份
        /// </summary>  
        public int? Year { get; set; }
        /// <summary>
		/// 首映时间
		/// </summary>  
		public DateTime? PubDate { get; set; }
        /// <summary>
        /// 原名
        /// </summary>  
        public string OriginalTitle { get; set; }
        /// <summary>
		/// 条目页URL
		/// </summary>  
		public string Alt { get; set; }
        /// <summary>
        /// 更多名称 xxx / xxx / xxx
        /// </summary>
        public string AkaNames { get; set; }
        /// <summary>
        /// 类型 xxxx / xx / xxx
        /// </summary>
        public string CategoryNames { get; set; }
        /// <summary>
        /// 上映时间 1978-02-15(xxx) / 1978-02-15(xxx)
        /// </summary>
        public string PubDates { get; set; }
        /// <summary>
        /// 制片国家 xxx / xxx
        /// </summary>
        public string CountrieNames { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string[] Pictures { get; set; }
        /// <summary>
        /// 片长
        /// </summary>
        public string LongTimes { get; set; }
    }

}