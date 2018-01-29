using DripOldDriver;
using Hangfire;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TuHaoQuNa.Business;
using TuHaoQuNa.Domain.Enum;

namespace TuHaoQuNa.Web.Task
{
    public class QQMovieJob
    {
        /// <summary>
        /// 爬取电影列表
        /// </summary>
        public void Action()
        {
            //初始参数设定
            string[] years = { "100040", "100039", "100038", "100037", "100036", "100035", "100034", "100063", "2016", "2017" };
            int pageSize = 30;
            years.ForEach_(y => {
                int maxPage = 1;
                for (int page = 1; page <= maxPage; page++)
                {
                    //发送请求
                    var httpResult = new HttpHelper().GetHtml(new HttpItem()
                    {
                        URL = "http://v.qq.com/x/list/movie?year=" + y + "&offset=" + ((page - 1) * pageSize),
                        Accept = "text/html",
                        ReadWriteTimeout = 1000 * 60,
                        Timeout = 1000 * 60
                    });

                    //判断请求是否成功
                    if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //将html先解析
                        HtmlDocument hd = new HtmlDocument();
                        hd.LoadHtml(httpResult.Html);

                        //解析li标签
                        var liNodes = hd.DocumentNode.SelectNodes("//li[@class='list_item']");
                        if (liNodes != null)
                            liNodes.ForEach_(li =>
                            {
                                //获取电影地址的a标签
                                var aNode = li.SelectSingleNode("./a[@class='figure']");
                                if (aNode != null)
                                {
                                    var vid = aNode.GetAttributeValue("data-float", "").Trim();
                                    var imgNode = aNode.SelectSingleNode("./img");
                                    var name = imgNode == null ? "未知" : imgNode.GetAttributeValue("alt", "");
                                    if (!string.IsNullOrWhiteSpace(vid))
                                    {
                                        BackgroundJob.Enqueue<QQMovieInfoJob>(j=>j.Action(vid,name,Family.电影));
                                    }
                                }
                            });

                        //解析最大页码
                        var pageNode = hd.DocumentNode.SelectSingleNode("//a[@class='page_num'][last()]");
                        maxPage = pageNode == null ? 0 : pageNode.InnerText.Trim().ToInt_();
                    }
                }
            });
        }
    }

    public class QQTvShowJob
    {
        /// <summary>
        /// 爬取电影列表
        /// </summary>
        public void Action()
        {
            //初始参数设定
            string[] years = { "866", "865", "864", "863", "862", "861", "860", "859", "2017" };
            int pageSize = 30;
            years.ForEach_(y => {
                int maxPage = 1;
                for (int page = 1; page <= maxPage; page++)
                {
                    //发送请求
                    var httpResult = new HttpHelper().GetHtml(new HttpItem()
                    {
                        URL = "http://v.qq.com/x/list/tv?year=" + y + "&offset=" + ((page - 1) * pageSize),
                        Accept = "text/html",
                        ReadWriteTimeout = 1000 * 60,
                        Timeout = 1000 * 60
                    });

                    //判断请求是否成功
                    if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //将html先解析
                        HtmlDocument hd = new HtmlDocument();
                        hd.LoadHtml(httpResult.Html);

                        //解析li标签
                        var liNodes = hd.DocumentNode.SelectNodes("//li[@class='list_item']");
                        if (liNodes != null)
                            liNodes.ForEach_(li =>
                            {
                                //获取电影地址的a标签
                                var aNode = li.SelectSingleNode("./a[@class='figure']");
                                if (aNode != null)
                                {
                                    var vid = aNode.GetAttributeValue("data-float", "").Trim();
                                    var imgNode = aNode.SelectSingleNode("./img");
                                    var name = imgNode == null ? "未知" : imgNode.GetAttributeValue("alt", "");
                                    if (!string.IsNullOrWhiteSpace(vid))
                                    {
                                        BackgroundJob.Enqueue<QQMovieInfoJob>(j => j.Action(vid, name, Family.电视剧));
                                    }
                                }
                            });

                        //解析最大页码
                        var pageNode = hd.DocumentNode.SelectSingleNode("//a[@class='page_num'][last()]");
                        maxPage = pageNode == null ? 0 : pageNode.InnerText.Trim().ToInt_();
                    }
                }
            });
        }
    }

    public class QQMovieInfoJob
    {
        /// <summary>
        /// 获取影片详情
        /// </summary>
        /// <param name="url"></param>
        public void Action(string vid, string name, Family family)
        {
            var url = "https://v.qq.com/detail/" + vid.Substring(0, 1) + "/" + vid + ".html";
            //发送请求
            var httpResult = new HttpHelper().GetHtml(new HttpItem()
            {
                URL = url,
                Accept = "text/html",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });
            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //将html先解析
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(httpResult.Html);
                var score_dbNode = hd.DocumentNode.SelectSingleNode("//a[@class='score_db']");
                if (score_dbNode != null)
                {
                    var doubanUrl = score_dbNode.GetAttributeValue("href", "");
                    var doubanID = "";
                    if (!string.IsNullOrWhiteSpace(doubanUrl))
                        doubanID = doubanUrl.Replace("https://movie.douban.com/subject/", "").TrimEnd('/').Trim();
                    if (!string.IsNullOrWhiteSpace(doubanID))
                    {
                        BackgroundJob.Enqueue(() => Console.WriteLine("{0}===》这是队列任务!"));
                        BackgroundJob.Enqueue<DouBanInfoJob>(j=>j.Action(doubanID));
                    }
                }
            }
        }
    }

    public class DouBanInfoJob
    {
        /// <summary>
        /// 根据豆瓣ID获取该条目的详细信息
        /// </summary>
        /// <param name="doubanId"></param>
        /// <returns></returns>
        public void Action(string doubanId)
        {
            //发送请求
            var httpResult = new HttpHelper().GetHtml(new HttpItem()
            {
                URL = "https://api.douban.com/v2/movie/subject/" + doubanId + "?apikey=" + Config_BLL.Config.Get<string>("DouBan.ApiKey"),
                Accept = "application/json",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });
            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var callsSurplus = httpResult.Header["X-Ratelimit-Remaining2"].ToInt_();

                var json = httpResult.Html;
                var doubanInfo = json.ParseJSON<Models.DouBan.Rootobject>();
                if (doubanInfo != null)
                {
                    var directors = new List<Domain.Entity.Celebrity>();
                    var screenwriters = new List<Domain.Entity.Celebrity>();
                    var performers = new List<Domain.Entity.Celebrity>();
                    var fragments = new List<Domain.Entity.Preview>();
                    var tidbits = new List<Domain.Entity.Preview>();
                    var trailers = new List<Domain.Entity.Preview>();
                    var pictures = new List<string>();
                    var pubdatas = new List<Domain.Entity.PubData>();
                    var durations = new List<Domain.Entity.Duration>();
                    doubanInfo.directors.ForEach_(m =>
                    {
                        if (!string.IsNullOrWhiteSpace(m.id) && directors.Count(c => c.DouBanID == m.id) < 1)
                            directors.Add(new Domain.Entity.Celebrity()
                            {
                                Alt = m.alt,
                                Avatar = m.avatars.large,
                                DouBanID = m.id,
                                Name = m.name
                            });

                    });
                    doubanInfo.writers.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.id) && screenwriters.Count(c => c.DouBanID == m.id) < 1)
                            screenwriters.Add(new Domain.Entity.Celebrity()
                            {
                                Alt = m.alt,
                                Avatar = m.avatars.large,
                                DouBanID = m.id,
                                Name = m.name
                            });
                    });
                    doubanInfo.casts.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.id) && performers.Count(c => c.DouBanID == m.id) < 1)
                            performers.Add(new Domain.Entity.Celebrity()
                            {
                                Alt = m.alt,
                                Avatar = m.avatars.large,
                                DouBanID = m.id,
                                Name = m.name
                            });
                    });
                    doubanInfo.clips.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.id) && fragments.Count(c => c.UID == m.id) < 1)
                            fragments.Add(new Domain.Entity.Preview()
                            {
                                Photo = m.medium,
                                Title = m.title,
                                UID = m.id,
                                Video = m.resource_url
                            });
                    });
                    doubanInfo.bloopers.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.id) && tidbits.Count(c => c.UID == m.id) < 1)
                            tidbits.Add(new Domain.Entity.Preview()
                            {
                                Photo = m.medium,
                                Title = m.title,
                                UID = m.id,
                                Video = m.resource_url
                            });
                    });
                    doubanInfo.trailers.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.id) && trailers.Count(c => c.UID == m.id) < 1)
                            trailers.Add(new Domain.Entity.Preview()
                            {
                                Photo = m.medium,
                                Title = m.title,
                                UID = m.id,
                                Video = m.resource_url
                            });
                    });
                    doubanInfo.photos.ForEach_(m => {
                        if (!string.IsNullOrWhiteSpace(m.image) && pictures.Count(c => c == m.image) < 1)
                            pictures.Add(m.image);
                    });
                    doubanInfo.pubdates.ForEach_(m => {
                        var year = m.Length >= 10 ? m.Substring(0, 10) : "";
                        if (!string.IsNullOrWhiteSpace(year))
                        {
                            var plan = m.Replace(year, "").Replace("(", "").Replace(")", "").Trim();
                            DateTime? date = year.ToDate_();
                            date = Utils.BaseDateTime == date ? null : date;
                            if (date.HasValue && pubdatas.Count(c => c.PubDate == date && c.PubPlace == plan) < 1)
                                pubdatas.Add(new Domain.Entity.PubData()
                                {
                                    PubDate = date.Value,
                                    PubPlace = plan
                                });
                        }
                    });
                    doubanInfo.durations.ForEach_(m => {
                        var min_str = m.IndexOf("分钟") > 0 ? m.Substring(0, m.IndexOf("分钟")) : m.Substring(0);
                        var plan = m.Replace(min_str + (m.IndexOf("分钟") > 0 ? "分钟" : ""), "").Replace("(", "").Replace(")", "").Trim();
                        int min = min_str.ToInt_();
                        if (min > 0 && durations.Count(c => c.LongTime == min && c.Plan == plan) < 1)
                            durations.Add(new Domain.Entity.Duration()
                            {
                                LongTime = min,
                                Plan = plan
                            });

                    });
                    var pubDate_str = doubanInfo.pubdate.Length >= 10 ? doubanInfo.pubdate.Substring(0, 10) : "";
                    DateTime? pubDate = pubDate_str.ToDate_();
                    pubDate = pubDate == Utils.BaseDateTime ? null : pubDate;
                    var pubdataObj = pubdatas.FirstOrDefault();
                    if (!pubDate.HasValue && pubdataObj != null)
                        pubDate = pubdataObj.PubDate;
                    decimal? score = doubanInfo.rating.average;
                    score = score == 0 ? null : score;
                    int? episodes_count = doubanInfo.episodes_count.ToIntOrNull_();
                    var movie = new Domain.Entity.Movie()
                    {
                        Aka = doubanInfo.aka.ToList(),
                        Describe = doubanInfo.summary.Replace("©豆瓣", ""),
                        RatingsCount = doubanInfo.ratings_count,
                        Poster = doubanInfo.images.large,
                        ReviewsCount = doubanInfo.reviews_count,
                        ScheduleUrl = doubanInfo.schedule_url,
                        Score = score,
                        Alt = doubanInfo.alt,
                        ShareUrl = doubanInfo.share_url,
                        WebSite = doubanInfo.website,
                        SeasonsCount = doubanInfo.seasons_count,
                        WishCount = doubanInfo.wish_count,
                        Year = doubanInfo.year.ToIntOrNull_(),
                        OriginalTitle = doubanInfo.original_title,
                        Name = doubanInfo.title,
                        CollectCount = doubanInfo.collect_count,
                        Family = doubanInfo.subtype == "movie" ? Domain.Enum.Family.电影 : Domain.Enum.Family.电视剧,
                        MobileUrl = doubanInfo.mobile_url,
                        EpisodesCount = episodes_count,
                        CommentsCount = doubanInfo.comments_count,
                        DouBanSite = doubanInfo.douban_site,
                        DoCount = doubanInfo.do_count,
                        DouBanID = doubanInfo.id,
                        Categorys = doubanInfo.genres.ToList(),
                        Countries = doubanInfo.countries.ToList(),
                        CurrentSeason = doubanInfo.current_season,
                        Languages = doubanInfo.languages.ToList(),
                        Tags = doubanInfo.tags.ToList(),
                        Directors = directors,
                        Screenwriters = screenwriters,
                        Performers = performers,
                        Fragments = fragments,
                        Tidbits = tidbits,
                        Trailers = trailers,
                        PubDate = pubDate,
                        Pictures = pictures,
                        PubDatas = pubdatas,
                        Durations = durations
                    };
                    var movie_bll = new Movie_BLL();
                    int? movieId = movie_bll.GetMovieIDByDouBanID(doubanInfo.id);
                    if (!movieId.HasValue)
                    {
                        movieId = movie_bll.ThingInsertMovie(movie);
                    }
                    else
                    {
                        //更新
                    }
                   
                }
            }
        }
    }
}