using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Domain.View
{
    /// <summary>
    /// 影视条目
    /// </summary>
    [TableName("View_FilmInfo")]
    [ExplicitColumns]
    public class View_FilmInfo_Repository
    {
        /// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
        /// <summary>
        /// 豆瓣ID
        /// </summary>  
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>  
        [Column] public string Name { get; set; }
        /// <summary>
        /// 评分
        /// </summary>  
        [Column] public decimal? Score { get; set; }
        /// <summary>
        /// 简介
        /// </summary>  
        [Column] public string Describe { get; set; }
        /// <summary>
        /// 1电影,2电视剧
        /// </summary>  
        [Column] public int Family { get; set; }
        /// <summary>
        /// 封面
        /// </summary>  
        [Column] public string Poster { get; set; }
        /// <summary>
        /// 年份
        /// </summary>  
        [Column] public int? Year { get; set; }
        /// <summary>
		/// 首映时间
		/// </summary>  
		[Column] public DateTime? PubDate { get; set; }
        /// <summary>
        /// 原名
        /// </summary>  
        [Column] public string OriginalTitle { get; set; }
        /// <summary>
		/// 条目页URL
		/// </summary>  
		[Column] public string Alt { get; set; }
        /// <summary>
        /// 更多名称 xxx / xxx / xxx
        /// </summary>
        [Column] public string AkaNames { get; set; }
        /// <summary>
        /// 类型 xxxx / xx / xxx
        /// </summary>
        [Column] public string CategoryNames { get; set; }
        /// <summary>
        /// 上映时间 1978-02-15(xxx) / 1978-02-15(xxx)
        /// </summary>
        [Column] public string PubDates { get; set; }
        /// <summary>
        /// 制片国家 xxx / xxx
        /// </summary>
        [Column] public string CountrieNames { get; set; }
        /// <summary>
        /// 图片 xxx.jpg,xxx.jpg
        /// </summary>
        [Column] public string Pictures { get; set; }
        /// <summary>
        /// 片长 xxx(xxx) / xxx(xx)
        /// </summary>
        [Column] public string LongTimes { get; set; }
    }

    /// <summary>
    /// 预告
    /// </summary>
    [TableName("View_MoviePreview")]
    [ExplicitColumns]
    public class View_MoviePreview_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
        /// <summary>
        /// 图片
        /// </summary>  
        [Column] public string Photo { get; set; }
        /// <summary>
        /// 视频
        /// </summary>  
        [Column] public string Video { get; set; }
        /// <summary>
        /// 1预告片、2花絮、3片段
        /// </summary>  
        [Column] public int PreviewType { get; set; }
    }

    /// <summary>
    /// 导演
    /// </summary>
    [TableName("View_MovieDirector")]
    [ExplicitColumns]
    public class View_MovieDirector_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 影人DouBanID
        /// </summary>
        [Column] public string CelebrityDouBanID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Column] public string Name { get; set; }
        /// <summary>
        /// 影人条目
        /// </summary>
        [Column] public string Alt { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column] public string Avatar { get; set; }
    }

    /// <summary>
    /// 编剧
    /// </summary>
    [TableName("View_MovieScreenwriter")]
    [ExplicitColumns]
    public class View_MovieScreenwriter_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 影人DouBanID
        /// </summary>
        [Column] public string CelebrityDouBanID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Column] public string Name { get; set; }
        /// <summary>
        /// 影人条目
        /// </summary>
        [Column] public string Alt { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column] public string Avatar { get; set; }
    }

    /// <summary>
    /// 演员
    /// </summary>
    [TableName("View_MoviePerformer")]
    [ExplicitColumns]
    public class View_MoviePerformer_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 影人DouBanID
        /// </summary>
        [Column] public string CelebrityDouBanID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Column] public string Name { get; set; }
        /// <summary>
        /// 影人条目
        /// </summary>
        [Column] public string Alt { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column] public string Avatar { get; set; }
    }

    /// <summary>
    /// 下载
    /// </summary>
    [TableName("View_MovieDownload")]
    [ExplicitColumns]
    public class View_MovieDownload_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 下载Guid
        /// </summary>
        [Column] public string DownloadGuid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column] public string Title { get; set; }
        /// <summary>
        /// 磁力
        /// </summary>
        [Column] public string Magnet { get; set; }
        /// <summary>
        /// 种子
        /// </summary>
        [Column] public string BitTorrent { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [Column] public decimal? Size { get; set; }
        /// <summary>
        /// 清晰度
        /// </summary>
        [Column] public string Clear { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column] public string Meta { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [Column] public string Source { get; set; }
    }

    /// <summary>
    /// 字幕
    /// </summary>
    [TableName("View_MovieSubtitle")]
    [ExplicitColumns]
    public class View_MovieSubtitle_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 字幕Guid
        /// </summary>
        [Column] public string SubtitleGuid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column] public string Title { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        [Column] public string Download { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [Column] public decimal? Size { get; set; }
        /// <summary>
        /// 清晰度
        /// </summary>
        [Column] public string Clear { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        [Column] public string Language { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column] public string Meta { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [Column] public string Source { get; set; }
        /// <summary>
        /// 格式
        /// </summary>
        [Column] public string Format { get; set; }
    }

    /// <summary>
    /// 播放
    /// </summary>
    [TableName("View_MoviePlayer")]
    [ExplicitColumns]
    public class View_MoviePlayer_Repository
    {
        /// <summary>
        /// DouBanID
        /// </summary>
        [Column] public string DouBanID { get; set; }
        /// <summary>
        /// 播放Guid
        /// </summary>
        [Column] public string PlayerGuid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column] public string Name { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        [Column] public string Platform { get; set; }
        /// <summary>
        /// 标识ID
        /// </summary>
        [Column] public string VID { get; set; }
        /// <summary>
        /// 播放地址
        /// </summary>
        [Column] public string PlayerUrl { get; set; }
        /// <summary>
        /// 需要Vip
        /// </summary>
        [Column] public int? HasVip { get; set; }
        /// <summary>
        /// 集数
        /// </summary>
        [Column] public int? Episodes { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column] public string Description { get; set; }
    }
}
