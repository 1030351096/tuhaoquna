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
    public class YouKuCollection
    {

        HttpHelper http;
        Movie_BLL movie_bll;
        Player_BLL player_bll;
        DouBanCollection douBanCollection;

        public YouKuCollection()
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
            int nowYear = DateTime.Now.Year;
            int startYear = 1900;

            //累加年份加载数据
            for (int year = startYear; year <= nowYear; year++)
            {
                int maxPage = 10;

                for (int page = 1; page <= maxPage; page++)
                {
                    //发送请求
                    var httpResult = http.GetHtml(new HttpItem()
                    {
                        URL = "http://list.youku.com/category/show/c_" + (family == Family.电影 ? "96" : "97") + "_r_" + year + "_u_1_s_6_d_1_p_" + page + ".html",
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
                        var liNodes = hd.DocumentNode.SelectNodes("//li[@class='yk-col4 mr1']");
                        if (liNodes != null)
                            liNodes.ForEach_(li =>
                            {
                                //获取电影地址的a标签
                                var aNode = li.SelectSingleNode("./div[@class='yk-pack pack-film']/div[@class='p-thumb']/a");
                                if (aNode != null)
                                {
                                    var name = aNode.GetAttributeValue("title", "").Trim();
                                    var href = aNode.GetAttributeValue("href", "").Trim();
                                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(href))
                                    {
                                        Console.WriteLine("正在获取" + family.ToString_() + name + "的详细信息...");
                                        href = "http:" + href;
                                        GoPlayerUrl(href, name, family);
                                    }
                                }
                            });

                        //解析最大页码
                        var pageNodes = hd.DocumentNode.SelectNodes("//ul[@class='yk-pages']/li");
                        maxPage = pageNodes==null?0:pageNodes[pageNodes.Count-2].InnerText.ToInt_();
                    }
                    else
                        Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
                }

            }
        }

        /// <summary>
        /// 跳转到电影播放地址
        /// </summary>
        /// <param name="url"></param>
        void GoPlayerUrl(string url, string name, Family family)
        {
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

                //获取详情页地址
                var aNode = hd.DocumentNode.SelectSingleNode("//a[@class='desc-link']");
                if (aNode!=null)
                {
                    var infoUrl = aNode.GetAttributeValue("href", "").Trim();
                    if (!string.IsNullOrWhiteSpace(infoUrl))
                    {
                        infoUrl = "http:" + infoUrl;
                        GetMovieInfo(infoUrl, name, family);
                    }
                }
                
            }
            else
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
        }

        /// <summary>
        /// 获取影片详情
        /// </summary>
        /// <param name="url"></param>
        void GetMovieInfo(string url, string name, Family family)
        {
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
                //处理json
                if (httpResult.Html.Contains("var PageConfig = "))
                {
                    var json = httpResult.Html.GetSubstr_("var PageConfig = ", ";");
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var info = json.ParseJSON<Models.YouKu.Rootobject>();
                        if (info != null)
                        {
                            if (!string.IsNullOrWhiteSpace(info.doubanId))
                            {
                                ////判断该豆瓣ID是否已经存在
                                //int? movieId = movie_bll.GetMovieIDByDouBanID(info.doubanId.ToString());
                                //if (!movieId.HasValue)
                                //{
                                //    //根据豆瓣ID获取详细信息
                                //    movieId = douBanCollection.CollectionDouBanInfo(info.doubanId.ToString());
                                //}
                                //else
                                //    Console.WriteLine(family.ToString_() + ":\t" + name + "\t已经被收录！");

                                int? movieId = douBanCollection.CollectionDouBanInfo(info.doubanId.ToString());

                                if (movieId.HasValue)
                                {
                                    Console.WriteLine("正在采集" + name + "的播放地址...");
                                    //获取下载地址
                                    CollectionMoviePlayer(movieId.Value, info.showid, family);
                                }
                            }
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
        public void CollectionMoviePlayer(int movieID, string hash, Family family)
        {
            try
            {
                ////http://list.youku.com/show/episode?id=310138&stage=reload_41&callback=w&_=w
                //初始化参数
                int pageSize = 40;
                int maxPage = 1;
                for (int page = 1; page <= maxPage; page++)
                {
                    int result_num = 0;
                    //发送请求
                    var httpResult = new HttpHelper().GetHtml(new HttpItem()
                    {
                        URL = "http://list.youku.com/show/episode?callback=w&_=w&id="+hash+"&stage=reload_"+((page-1)*pageSize)+1,
                        Accept = "application/json",
                        ReadWriteTimeout = 1000 * 60,
                        Timeout = 1000 * 60
                    });

                    //判断请求是否成功
                    if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //将结果处理成实体集合
                        var resHtml = httpResult.Html.Replace("var tvInfoJs=", "").Trim().TrimEnd(';');
                        var res_obj = resHtml.ParseJSON<Models.iQiYi.Palyer.Rootobject>();
                        if (res_obj.mixinVideos != null)
                        {
                            //加载数据成功
                            res_obj.mixinVideos.ForEach_(m => {
                                if (m.contentType.ToInt_() == 1)
                                {
                                    //将数据写入数据库
                                    int playerID = new Player_BLL().SavePlayer(new Domain.Entity.Player_Repository()
                                    {
                                        Guid = Guid.NewGuid().ToString().ToUpper(),
                                        Name = m.albumName,
                                        CreateTime = DateTime.Now,
                                        Description = string.IsNullOrWhiteSpace(m.description) ? null : m.description,
                                        Episodes = family == Family.电影 ? null : m.order,
                                        HasVip = m.isPurchase,
                                        MovieID = movieID,
                                        Platform = "iqiyi",
                                        PlayerUrl = m.url,
                                        VID = m.vid
                                    });
                                    if (movieID > 0)
                                        Console.WriteLine(m.name + "\t写入数据库成功！");

                                }

                            });
                        }
                        //最大页码
                        maxPage = (res_obj.total.ToInt_() / pageSize) + ((res_obj.total.ToInt_() % pageSize) > 0 ? 1 : 0);
                    }
                    else
                        Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
                    maxPage = (result_num / pageSize) + ((result_num % pageSize) > 0 ? 1 : 0);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
    
}
