using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Web.Task.Models.DouBan
{
    public class Rootobject
    {
        /// <summary>
        /// 评分
        /// </summary>
        public Rating rating { get; set; }
        /// <summary>
        /// 影评数量
        /// </summary>
        public int? reviews_count { get; set; }
        /// <summary>
        /// 兼容性数据，未来会去掉，大陆上映日期，如果条目类型是电影则为上映日期，如果是电视剧则为首播日期
        /// </summary>
        public string pubdate { get; set; }
        /// <summary>
        /// 想看人数	
        /// </summary>
        public int? wish_count { get; set; }
        /// <summary>
        /// 原名
        /// </summary>
        public string original_title { get; set; }
        /// <summary>
        /// 花絮URL，对高级用户以上开放，最多开放4个地址
        /// </summary>
        public string[] blooper_urls { get; set; }
        /// <summary>
        /// 看过人数
        /// </summary>
        public int? collect_count { get; set; }
        /// <summary>
        /// 豆瓣小站
        /// </summary>
        public string douban_site { get; set; }
        /// <summary>
        /// 年代
        /// </summary>
        public string year { get; set; }
        /// <summary>
        /// 电影海报图，分别提供288px x 465px(大)，96px x 155px(中) 64px x 103px(小)尺寸
        /// </summary>
        public Images images { get; set; }
        /// <summary>
        /// 条目页URL
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 条目id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 移动版条目页URL	
        /// </summary>
        public string mobile_url { get; set; }
        /// <summary>
        /// 中文名	
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 在看人数，如果是电视剧，默认值为0，如果是电影值为null
        /// </summary>
        public int? do_count { get; set; }
        /// <summary>
        /// 分享条目页URL
        /// </summary>
        public string share_url { get; set; }
        /// <summary>
        /// 总季数(tv only)
        /// </summary>
        public int? seasons_count { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string[] languages { get; set; }
        /// <summary>
        /// 影讯页URL(movie only)
        /// </summary>
        public string schedule_url { get; set; }
        /// <summary>
        /// 编剧，数据结构为影人的简化描述
        /// </summary>
        public Celebrity[] writers { get; set; }
        /// <summary>
        /// 如果条目类型是电影则为上映日期，如果是电视剧则为首映日期
        /// </summary>
        public string[] pubdates { get; set; }
        /// <summary>
        /// 官方网站
        /// </summary>
        public string website { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string[] tags { get; set; }
        /// <summary>
        /// 片长
        /// </summary>
        public string[] durations { get; set; }
        /// <summary>
        /// 影片类型，最多提供3个
        /// </summary>
        public string[] genres { get; set; }
        /// <summary>
        /// 预告
        /// </summary>
        public Preview[] trailers { get; set; }
        /// <summary>
        /// 当前季的集数(tv only)
        /// </summary>
        public string episodes_count { get; set; }
        /// <summary>
        /// 预告片URL，对高级用户以上开放，最多开放4个地址
        /// </summary>
        public string[] trailer_urls { get; set; }
        /// <summary>
        /// 花絮
        /// </summary>
        public Preview[] bloopers { get; set; }
        /// <summary>
        /// 片段URL，对高级用户以上开放，最多开放4个地址
        /// </summary>
        public string[] clip_urls { get; set; }
        /// <summary>
        /// 当前季数(tv only)
        /// </summary>
        public int? current_season { get; set; }
        /// <summary>
        /// 主演，最多可获得4个，数据结构为影人的简化描述
        /// </summary>
        public Celebrity[] casts { get; set; }
        /// <summary>
        /// 制片国家/地区
        /// </summary>
        public string[] countries { get; set; }
        /// <summary>
        /// 大陆上映日期，如果条目类型是电影则为上映日期，如果是电视剧则为首播日期
        /// </summary>
        public string mainland_pubdate { get; set; }
        /// <summary>
        /// 电影剧照，前10张
        /// </summary>
        public Photo[] photos { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        /// 片段
        /// </summary>
        public Preview[] clips { get; set; }
        /// <summary>
        /// 条目分类, movie或者tv
        /// </summary>
        public string subtype { get; set; }
        /// <summary>
        /// 导演，数据结构为影人的简化描述
        /// </summary>
        public Celebrity[] directors { get; set; }
        /// <summary>
        /// 短评数量
        /// </summary>
        public int? comments_count { get; set; }
        /// <summary>
        /// 影评，前10条，影评结构
        /// </summary>
        public Review[] popular_reviews { get; set; }
        /// <summary>
        /// 评分人数
        /// </summary>
        public int? ratings_count { get; set; }
        /// <summary>
        /// 又名
        /// </summary>
        public string[] aka { get; set; }
    }
    
    public class Rating
    {
        /// <summary>
        /// 最高评分
        /// </summary>
        public decimal max { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public decimal average { get; set; }
        /// <summary>
        /// 最低评分
        /// </summary>
        public decimal min { get; set; }
    }

    public class ReviewRating
    {
        /// <summary>
        /// 最高评分
        /// </summary>
        public decimal max { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public decimal value { get; set; }
        /// <summary>
        /// 最低评分
        /// </summary>
        public decimal min { get; set; }
    }


    public class Images
    {
        /// <summary>
        /// 小
        /// </summary>
        public string small { get; set; }
        /// <summary>
        /// 大
        /// </summary>
        public string large { get; set; }
        /// <summary>
        /// 中
        /// </summary>
        public string medium { get; set; }
    }

    public class Celebrity
    {
        /// <summary>
        /// 影人条目URL
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 影人头像，分别提供420px x 600px(大)，140px x 200px(中) 70px x 100px(小)尺寸
        /// </summary>
        public Images avatars { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 影人条目id
        /// </summary>
        public string id { get; set; }
    }

    public class Preview
    {
        /// <summary>
        /// 中 图片
        /// </summary>
        public string medium { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 条目ID
        /// </summary>
        public string subject_id { get; set; }
        /// <summary>
        /// 展示页URL
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 小 图片
        /// </summary>
        public string small { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string resource_url { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string id { get; set; }
    }
    
    public class Photo
    {
        /// <summary>
        /// 图片地址，thumb尺寸
        /// </summary>
        public string thumb { get; set; }
        /// <summary>
        /// 图片地址，image尺寸
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 图片地址，cover尺寸
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 图片展示页URL
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 图片id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 图片地址，icon尺寸
        /// </summary>
        public string icon { get; set; }
    }

    public class Review
    {
        public ReviewRating rating { get; set; }
        /// <summary>
        /// 影评名
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 条目id
        /// </summary>
        public string subject_id { get; set; }
        /// <summary>
        /// 上传用户
        /// </summary>
        public Author author { get; set; }
        /// <summary>
        /// 摘要，100字以内
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        /// 影评url
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 影评id
        /// </summary>
        public string id { get; set; }
    }

    public class Author
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 用户签名
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 用户个人主页url
        /// </summary>
        public string alt { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
    }


}