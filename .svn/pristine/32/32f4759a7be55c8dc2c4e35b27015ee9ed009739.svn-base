using DripOldDriver;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Business;
using TuHaoQuNa.Domain.Enum;

namespace TuHaoQuNa.Reptile
{
    public class QQCollection
    {
        HttpHelper http;
        Movie_BLL movie_bll;
        Player_BLL player_bll;
        DouBanCollection douBanCollection;
        public QQCollection()
        {
            http = new HttpHelper();
            movie_bll = new Movie_BLL();
            player_bll = new Player_BLL();
            douBanCollection = new DouBanCollection();
        }

        /// <summary>
        /// 爬取电影列表
        /// </summary>
        /// <param name="family"></param>
        public void CollectionMovies(Family family)
        {
            //初始参数设定
            string[] movie_years = { "100040", "100039", "100038", "100037", "100036", "100035", "100034", "100063", "2016", "2017" };
            string[] tv_years = { "866", "865", "864", "863", "862", "861", "860", "859", "2017" };
            string[] years = family == Family.电影 ? movie_years : tv_years;
            int pageSize = 30;

            years.ForEach_(y=> {
                int maxPage = 1;
                for (int page = 1; page <= maxPage; page++)
                {
                    //发送请求
                    var httpResult = http.GetHtml(new HttpItem()
                    {
                        URL = "http://v.qq.com/x/list/" + (family == Family.电影 ? "movie" : "tv")+ "?year="+y+ "&offset="+((page-1)*pageSize),
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
                                        Console.WriteLine("正在获取" + family.ToString_() + name + "的详细信息...");
                                        GetMovieInfo(vid, name, family);
                                    }
                                }
                            });

                        //解析最大页码
                        var pageNode = hd.DocumentNode.SelectSingleNode("//a[@class='page_num'][last()]");
                        maxPage = pageNode == null ? 0 : pageNode.InnerText.Trim().ToInt_();
                    }
                    else
                        Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
                }
            });
        }
        

        /// <summary>
        /// 获取影片详情
        /// </summary>
        /// <param name="url"></param>
        void GetMovieInfo(string vid, string name, Family family)
        {
            var url = "https://v.qq.com/detail/" + vid.Substring(0, 1) + "/" + vid + ".html";
            //发送请求
            var httpResult = http.GetHtml(new HttpItem()
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
                        ////判断该豆瓣ID是否已经存在
                        //int? movieId = movie_bll.GetMovieIDByDouBanID(doubanID);
                        //if (!movieId.HasValue)
                        //{
                        //    //根据豆瓣ID获取详细信息
                        //    movieId = douBanCollection.CollectionDouBanInfo(doubanID);
                        //}
                        //else
                        //    Console.WriteLine(family.ToString_() + ":\t" + name + "\t已经被收录！");

                        int? movieId = douBanCollection.CollectionDouBanInfo(doubanID);
                        if (movieId.HasValue)
                        {
                            Console.WriteLine("正在采集" + name + "的播放地址...");
                            CollectionMoviePlayer(movieId.Value, vid, name, family);
                        }
                    }
                }
            }
            else
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
        }

        /// <summary>
        /// 采集电影的播放地址
        /// </summary>
        /// <param name="movieID"></param>
        /// <param name="hash"></param>
        public void CollectionMoviePlayer(int movieID, string vid, string name, Family family)
        {
            var url = "https://s.video.qq.com/get_playsource?otype=json&plat=2&type=4&video_type=2&range=1-100000&id=" + vid;
            //发送请求
            var httpResult = http.GetHtml(new HttpItem()
            {
                URL = url,
                Accept = "text/html",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });
            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resHtml = httpResult.Html.Replace("QZOutputJson=", "").Trim().TrimEnd(';');
                var res_obj = resHtml.ParseJSON<Models.QQ.Player.Rootobject>();
                if (res_obj.PlaylistItem!=null)
                {
                    var list = res_obj.PlaylistItem.videoPlayList;
                    if (list!=null)
                    {
                        list.ForEach_(m=> {
                            bool isYg = false;
                            bool isVip = false;
                            int? episodes = family == Family.电视剧 ? m.title.ToInt_() : 0;
                            if (m.markLabelList!=null)
                            {
                                var markObj = m.markLabelList.FirstOrDefault();
                                if (markObj!=null)
                                {
                                    isYg = markObj.primeText == "预告";
                                    isVip = markObj.primeText == "会员";
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(m.id) && !string.IsNullOrWhiteSpace(m.playUrl) && !isYg && (family == Family.电视剧 ? episodes > 0 : true))
                            {
                                int? hasVip = isVip ? 1 : 0;
                                hasVip = hasVip > 0 ? hasVip : null;
                                int playerID = player_bll.SavePlayer(new Domain.Entity.Player_Repository()
                                {
                                    CreateTime = DateTime.Now,
                                    Episodes = (family == Family.电视剧 ? episodes : null),
                                    Guid = Guid.NewGuid().ToString().ToUpper(),
                                    HasVip = hasVip,
                                    MovieID = movieID,
                                    Name = (family == Family.电视剧 ? name : m.title),
                                    Platform = "qq",
                                    PlayerUrl = m.playUrl,
                                    VID = m.id
                                });
                                if (playerID > 0)
                                    Console.WriteLine((family == Family.电视剧 ? name + " 第" + episodes + "集" : m.title) + "\t写入数据库成功！");
                            }
                        });
                    }
                }
            }
            else
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
        }
    }
    
}
