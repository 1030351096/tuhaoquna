
<<<<<<< .mine
/********************************************************************************
**
**������������������������������+ +
**�������������������ߩ��������ߩ� + +
**�������������������������������� ��
**�������������������������������� ++ + + +
**������������ ������������������ ��+
**�������������������������������� +
**�����������������������ߡ�������
**�������������������������������� + +
**��������������������������������
**��������������������������������������������������
**���������������������������� + + + +
**������������������������������������Code is far away from bug with the animal protecting��������������
**���������������������������� + �����������ޱ���,������bug����
**����������������������������
**��������������������������������+������������������
**���������������������� �������������� + +
**�������������������� ���������������ǩ�
**�������������������� ������������������
**�����������������������������ש����� + + + +
**�����������������������ϩϡ����ϩ�
**�����������������������ߩ������ߩ�+ + + +
**

** ***********************************************************************
** ����			: TuHaoQuNa.Domain.Entity
** �ļ���			: Database.cs
** ����				: �Ρ���˾��
** ����              : 370326433@qq.com
** ����ʱ��			: 2017-08-16
** ����޸���		: �Ρ���˾��
** ����޸�ʱ��		: 2017-08-16
** ***********************************************************************
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DripOldDriver.Data;

namespace TuHaoQuNa.Domain.Entity
{
    /// <summary>
    /// 电影类型
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Category")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Category_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 筛选时类型ID
		/// </summary>  
		[Column] public int? FID { get; set; }
	}
    /// <summary>
    /// 名人
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Celebrity")]
	[PrimaryKey("ID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Celebrity_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 豆瓣ID
		/// </summary>  
		[Column] public string DouBanID { get; set; }
		/// <summary>
		/// IMDbID
		/// </summary>  
		[Column] public string IMDbID { get; set; }
		/// <summary>
		/// 姓名
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 性别
		/// </summary>  
		[Column] public bool? Gender { get; set; }
		/// <summary>
		/// 星座
		/// </summary>  
		[Column] public string Constellation { get; set; }
		/// <summary>
		/// 生日
		/// </summary>  
		[Column] public DateTime? Birthday { get; set; }
		/// <summary>
		/// 出生地
		/// </summary>  
		[Column] public string Homeplace { get; set; }
		/// <summary>
		/// 照片
		/// </summary>  
		[Column] public string Photo { get; set; }
		/// <summary>
		/// 简介
		/// </summary>  
		[Column] public string Describe { get; set; }
	}
    /// <summary>
    /// 名人姓名
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.CelebrityMoreName")]
	[PrimaryKey("CelebrityID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class CelebrityMoreName_Repository
    {
		/// <summary>
		/// 名人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 中文名或外文名
		/// </summary>  
		[Column] public int Language { get; set; }
	}
    /// <summary>
    /// 国家
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Country")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Country_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 语言
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Language")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Language_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 磁力
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Magnet")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Magnet_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
		/// <summary>
		/// 磁力链接
		/// </summary>  
		[Column] public string MagnetURI { get; set; }
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
    /// <summary>
    /// 电影名称
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.MoreName")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MoreName_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 电影
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Movie")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Movie_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 豆瓣ID
		/// </summary>  
		[Column] public string DouBanID { get; set; }
		/// <summary>
		/// IMDbID
		/// </summary>  
		[Column] public string IMDbID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
		/// <summary>
		/// 片长
		/// </summary>  
		[Column] public int? LongTime { get; set; }
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
		/// 播放次数
		/// </summary>  
		[Column] public int? PlayCount { get; set; }
		/// <summary>
		/// 热度
		/// </summary>  
		[Column] public int? Hot { get; set; }
		/// <summary>
		/// 浏览次数
		/// </summary>  
		[Column] public int? Glance { get; set; }
		/// <summary>
		/// 上映时间
		/// </summary>  
		[Column] public DateTime? ReleaseDate { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 职业
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Occupation")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Occupation_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 职业名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 播放地址
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Player")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Player_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名称
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
    /// <summary>
    /// 电影类型关系
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Category")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Category_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 类型ID
		/// </summary>  
		[Column] public int CategoryID { get; set; }
	}
    /// <summary>
    /// 电影国家关系
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Country")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Country_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 国家ID
		/// </summary>  
		[Column] public int CountryID { get; set; }
	}
    /// <summary>
    /// 电影导演关系表
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Director")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Director_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 电影语言关系
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Language")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Language_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 语言ID
		/// </summary>  
		[Column] public int LanguageID { get; set; }
	}
    /// <summary>
    /// 名人职业关系
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Occupation")]
	[PrimaryKey("CelebrityID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Occupation_Repository
    {
		/// <summary>
		/// 名人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
		/// <summary>
		/// 职业ID
		/// </summary>  
		[Column] public int OccupationID { get; set; }
	}
    /// <summary>
    /// 电影演员关系
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Performer")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Performer_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 电影编剧
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Relation_Screenwriter")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Screenwriter_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 编剧ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 字幕
    /// </summary>
	[DbConnection("TuHaoQuNa")]
	[TableName("dbo.Subtitle")]
	[PrimaryKey("ID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Subtitle_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
		/// <summary>
		/// 下载地址
		/// </summary>  
		[Column] public string Download { get; set; }
		/// <summary>
		/// 清晰度
		/// </summary>  
		[Column] public string Clear { get; set; }
		/// <summary>
		/// 大小
		/// </summary>  
		[Column] public decimal? Size { get; set; }
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
}
||||||| .r156
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DripOldDriver.Data;

namespace TuHaoQuNa.Domain.Entity
{
    /// <summary>
    /// 电影类型
    /// </summary>
	[TableName("dbo.Category")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Category_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 显示的类型名称
		/// </summary>  
		[Column] public string Genre { get; set; }
	}
    /// <summary>
    /// 影人
    /// </summary>
	[TableName("dbo.Celebrity")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Celebrity_Repository
    {
		/// <summary>
		/// 影人ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 影人豆瓣ID
		/// </summary>  
		[Column] public string DouBanID { get; set; }
		/// <summary>
		/// 姓名
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 影人条目URL
		/// </summary>  
		[Column] public string Alt { get; set; }
		/// <summary>
		/// 影人头像
		/// </summary>  
		[Column] public string Avatar { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 配置信息
    /// </summary>
	[TableName("dbo.Config")]
	[PrimaryKey("Key", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Config_Repository
    {
		/// <summary>
		/// 键
		/// </summary>  
		[Column] public string Key { get; set; }
		/// <summary>
		/// 值
		/// </summary>  
		[Column] public string Value { get; set; }
	}
    /// <summary>
    /// 制片国家地区
    /// </summary>
	[TableName("dbo.Countrie")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Countrie_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 显示的国家名称
		/// </summary>  
		[Column] public string Country { get; set; }
	}
    /// <summary>
    /// 下载
    /// </summary>
	[TableName("dbo.Download")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Download_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
		/// <summary>
		/// 磁力链接
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
    /// <summary>
    /// 片长
    /// </summary>
	[TableName("dbo.Duration")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Duration_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 片长
		/// </summary>  
		[Column] public int LongTime { get; set; }
		/// <summary>
		/// 地区
		/// </summary>  
		[Column] public string Plan { get; set; }
	}
    /// <summary>
    /// 语言
    /// </summary>
	[TableName("dbo.Language")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Language_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 电影又名
    /// </summary>
	[TableName("dbo.MovieAka")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MovieAka_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名称
		/// </summary>  
		[Column] public string Name { get; set; }
	}
    /// <summary>
    /// 电影基础信息
    /// </summary>
	[TableName("dbo.MovieBasic")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class MovieBasic_Repository
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
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电影详细信息
    /// </summary>
	[TableName("dbo.MovieDetail")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MovieDetail_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 首映时间
		/// </summary>  
		[Column] public DateTime? PubDate { get; set; }
		/// <summary>
		/// 原名
		/// </summary>  
		[Column] public string OriginalTitle { get; set; }
		/// <summary>
		/// 豆瓣小站URL
		/// </summary>  
		[Column] public string DouBanSite { get; set; }
		/// <summary>
		/// 条目页URL
		/// </summary>  
		[Column] public string Alt { get; set; }
		/// <summary>
		/// 移动版条目页URL
		/// </summary>  
		[Column] public string MobileUrl { get; set; }
		/// <summary>
		/// 分享条目页URL
		/// </summary>  
		[Column] public string ShareUrl { get; set; }
		/// <summary>
		/// 影讯页URL
		/// </summary>  
		[Column] public string ScheduleUrl { get; set; }
		/// <summary>
		/// 官方网站
		/// </summary>  
		[Column] public string WebSite { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电影动态数据
    /// </summary>
	[TableName("dbo.MovieDynamic")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MovieDynamic_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 影评数量
		/// </summary>  
		[Column] public int? ReviewsCount { get; set; }
		/// <summary>
		/// 想看人数
		/// </summary>  
		[Column] public int? WishCount { get; set; }
		/// <summary>
		/// 看过人数
		/// </summary>  
		[Column] public int? CollectCount { get; set; }
		/// <summary>
		/// 在看人数
		/// </summary>  
		[Column] public int? DoCount { get; set; }
		/// <summary>
		/// 短评数量
		/// </summary>  
		[Column] public int? CommentsCount { get; set; }
		/// <summary>
		/// 评分人数
		/// </summary>  
		[Column] public int? RatingsCount { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电影剧照
    /// </summary>
	[TableName("dbo.MoviePhoto")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MoviePhoto_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 剧照
		/// </summary>  
		[Column] public string Picture { get; set; }
	}
    /// <summary>
    /// 电影预览
    /// </summary>
	[TableName("dbo.MoviePreview")]
	[PrimaryKey("UID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MoviePreview_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标识
		/// </summary>  
		[Column] public string UID { get; set; }
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电影上映时间
    /// </summary>
	[TableName("dbo.MoviePubDate")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class MoviePubDate_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 上映时间
		/// </summary>  
		[Column] public DateTime PubDate { get; set; }
		/// <summary>
		/// 上映地点
		/// </summary>  
		[Column] public string PubPlace { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电视剧集数季数
    /// </summary>
	[TableName("dbo.MovieSerial")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class MovieSerial_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 总季数
		/// </summary>  
		[Column] public int? SeasonsCount { get; set; }
		/// <summary>
		/// 当前季的集数
		/// </summary>  
		[Column] public int? EpisodesCount { get; set; }
		/// <summary>
		/// 当前季数
		/// </summary>  
		[Column] public int? CurrentSeason { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 电影标签
    /// </summary>
	[TableName("dbo.MovieTag")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class MovieTag_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// 标签名称
		/// </summary>  
		[Column] public string Name { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 最后操作时间
		/// </summary>  
		[Column] public DateTime? LastTime { get; set; }
	}
    /// <summary>
    /// 播放地址
    /// </summary>
	[TableName("dbo.Player")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Player_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 名称
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
    /// <summary>
    /// 电影类型关系
    /// </summary>
	[TableName("dbo.Relation_Category")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Category_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 类型ID
		/// </summary>  
		[Column] public int CategoryID { get; set; }
	}
    /// <summary>
    /// 电影制片国家关系
    /// </summary>
	[TableName("dbo.Relation_Countrie")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Countrie_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 制片国家ID
		/// </summary>  
		[Column] public int CountrieID { get; set; }
	}
    /// <summary>
    /// 电影导演关系表
    /// </summary>
	[TableName("dbo.Relation_Director")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Director_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 影人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 电影语言关系
    /// </summary>
	[TableName("dbo.Relation_Language")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Language_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 语言ID
		/// </summary>  
		[Column] public int LanguageID { get; set; }
	}
    /// <summary>
    /// 电影演员关系
    /// </summary>
	[TableName("dbo.Relation_Performer")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Performer_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 影人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 电影上映时间关系
    /// </summary>
	[TableName("dbo.Relation_PubDate")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_PubDate_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 上映ID
		/// </summary>  
		[Column] public int PubID { get; set; }
	}
    /// <summary>
    /// 电影编剧
    /// </summary>
	[TableName("dbo.Relation_Screenwriter")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Screenwriter_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 影人ID
		/// </summary>  
		[Column] public int CelebrityID { get; set; }
	}
    /// <summary>
    /// 电影标签关系
    /// </summary>
	[TableName("dbo.Relation_Tag")]
	[PrimaryKey("MovieID", autoIncrement=false)]
	[ExplicitColumns]
    public partial class Relation_Tag_Repository
    {
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标签ID
		/// </summary>  
		[Column] public int TagID { get; set; }
	}
    /// <summary>
    /// 字幕
    /// </summary>
	[TableName("dbo.Subtitle")]
	[PrimaryKey("ID")]
	[ExplicitColumns]
    public partial class Subtitle_Repository
    {
		/// <summary>
		/// ID
		/// </summary>  
		[Column] public int ID { get; set; }
		/// <summary>
		/// Guid
		/// </summary>  
		[Column] public string Guid { get; set; }
		/// <summary>
		/// 电影ID
		/// </summary>  
		[Column] public int MovieID { get; set; }
		/// <summary>
		/// 标题
		/// </summary>  
		[Column] public string Title { get; set; }
		/// <summary>
		/// 下载地址
		/// </summary>  
		[Column] public string Download { get; set; }
		/// <summary>
		/// 清晰度
		/// </summary>  
		[Column] public string Clear { get; set; }
		/// <summary>
		/// 大小
		/// </summary>  
		[Column] public decimal? Size { get; set; }
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
		/// <summary>
		/// 创建时间
		/// </summary>  
		[Column] public DateTime? CreateTime { get; set; }
	}
}
>>>>>>> .r402
