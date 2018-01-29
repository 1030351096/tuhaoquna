using DripOldDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Business;

namespace TuHaoQuNa.Reptile
{
    public class DouBanCollection
    {
        HttpHelper http;
        Movie_BLL movie_bll;

        public DouBanCollection()
        {
            http = new HttpHelper();
            movie_bll = new Movie_BLL();
        }

        /// <summary>
        /// 根据豆瓣ID获取该条目的详细信息
        /// </summary>
        /// <param name="doubanId"></param>
        /// <returns></returns>
        public int? CollectionDouBanInfo(string doubanId)
        {
            Console.WriteLine("正在获取豆瓣信息...");
            //发送请求
            var httpResult = http.GetHtml(new HttpItem()
            {
                URL = "https://api.douban.com/v2/movie/subject/"+ doubanId + "?apikey="+ Config_BLL.Config.Get<string>("DouBan.ApiKey"),
                Accept = "application/json",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });
            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var callsSurplus = httpResult.Header["X-Ratelimit-Remaining2"].ToInt_();
                Console.WriteLine("剩余调用次数："+callsSurplus);
                try
                {
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
                        var categorys = new List<string>();
                        var countries = new List<string>();
                        var languages = new List<string>();
                        var tags = new List<string>();
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
                                fragments.Add(new Domain.Entity.Preview() {
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
                        doubanInfo.photos.ForEach_(m=> {
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
                            var min_str = m.IndexOf("分钟")>0?m.Substring(0, m.IndexOf("分钟")): m.Substring(0);
                            var plan = m.Replace(min_str + (m.IndexOf("分钟") > 0?"分钟":""), "").Replace("(", "").Replace(")", "").Trim();
                            int min = min_str.ToInt_();
                            if (min>0 && durations.Count(c => c.LongTime == min && c.Plan == plan) < 1)
                                durations.Add(new Domain.Entity.Duration()
                                {
                                    LongTime = min,
                                    Plan = plan
                                });

                        });
                        doubanInfo.genres.ForEach_(m => {
                            if (categorys.Count(c=>c==m) < 1)
                                categorys.Add(m);
                        });
                        doubanInfo.countries.ForEach_(m=> {
                            if (countries.Count(c => c == m) < 1)
                                countries.Add(m);
                        });
                        doubanInfo.languages.ForEach_(m => {
                            if (languages.Count(c => c == m) < 1)
                                languages.Add(m);
                        });
                        doubanInfo.tags.ForEach_(m => {
                            if (tags.Count(c => c == m) < 1)
                                tags.Add(m);
                        });
                        var pubDate_str = doubanInfo.pubdate.Length >= 10 ? doubanInfo.pubdate.Substring(0, 10) : "";
                        DateTime ? pubDate = pubDate_str.ToDate_();
                        pubDate = pubDate == Utils.BaseDateTime ? null : pubDate;
                        var pubdataObj = pubdatas.FirstOrDefault();
                        if (!pubDate.HasValue&& pubdataObj!=null)
                            pubDate = pubdataObj.PubDate;
                        decimal? score = doubanInfo.rating.average;
                        score = score == 0 ? null : score;
                        int? episodes_count = doubanInfo.episodes_count.ToIntOrNull_();
                        int? movieId = movie_bll.GetMovieIDByDouBanID(doubanInfo.id);
                        var movieObj = new Domain.Entity.Movie()
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
                            Categorys = categorys,
                            Countries = countries,
                            CurrentSeason = doubanInfo.current_season,
                            Languages = languages,
                            Tags = tags,
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
                        if (!movieId.HasValue)
                        {
                            movieId = movie_bll.ThingInsertMovie(movieObj);
                        }
                        else
                        {
                            movieObj.ID = movieId.Value;
                            //更新
                            movie_bll.ThingUpdateMovie(movieObj);
                        }
                        if (movieId.HasValue)
                            Console.WriteLine((doubanInfo.subtype == "movie" ? Domain.Enum.Family.电影 : Domain.Enum.Family.电视剧).ToString_() + ":\t" + doubanInfo.title + "\t写入数据库成功！");
                        else
                            Console.WriteLine((doubanInfo.subtype == "movie" ? Domain.Enum.Family.电影 : Domain.Enum.Family.电视剧).ToString_() + ":\t" + doubanInfo.title + "\t写入数据库失败！");

                        return movieId;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(httpResult.Html);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
                return null;
            }
        }

    }
}
