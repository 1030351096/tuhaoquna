using DripOldDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuHaoQuNa.Business;
using TuHaoQuNa.Domain.Enum;

namespace TuHaoQuNa.Reptile
{
    public class iQiYiCollection
    {
        HttpHelper http;
        Movie_BLL movie_bll;
        Player_BLL player_bll;
        DouBanCollection douBanCollection;

        private readonly object SyncObject = new object();

        public iQiYiCollection()
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
            int pageSize = 800;
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
                        URL = "http://search.video.iqiyi.com/o?type=list&pos=1&if=html5&site=iqiyi&mode=4&ctgName=" + family.ToString_() + "&pageSize=" + pageSize + "&market_release_date_level=" + year + "&pageNum=" + page,
                        Accept = "application/json",
                        ReadWriteTimeout = 1000 * 60,
                        Timeout = 1000 * 60
                    });

                    //判断请求是否成功
                    if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //将结果处理成实体集合
                        if (!httpResult.Html.Contains("search result is empty"))
                        {
                            var res_obj = httpResult.Html.ParseJSON<Models.iQiYi.Rootobject>();
                            if (res_obj.code == "A00000")
                            {
                                //加载数据成功
                                Console.WriteLine("本次共采集到" + family.ToString_() + ":\t" + res_obj.data.docinfos.Length + "条...");

                                res_obj.data.docinfos.ForEach_(m => {
                                    if (m.albumDocInfo != null)
                                        if (m.albumDocInfo.video_lib_meta != null)
                                            if (m.albumDocInfo.video_lib_meta.douban_id.HasValue)
                                            {
                                                //判断该豆瓣ID是否已经存在
                                                //int? movieId = movie_bll.GetMovieIDByDouBanID(m.albumDocInfo.video_lib_meta.douban_id.Value.ToString());
                                                //if (!movieId.HasValue)
                                                //{
                                                //    //根据豆瓣ID获取详细信息
                                                //    movieId = douBanCollection.CollectionDouBanInfo(m.albumDocInfo.video_lib_meta.douban_id.Value.ToString());
                                                //}
                                                //else
                                                //    Console.WriteLine(family.ToString_() + ":\t" + m.albumDocInfo.albumTitle + "\t已经被收录！");

                                                int? movieId = douBanCollection.CollectionDouBanInfo(m.albumDocInfo.video_lib_meta.douban_id.Value.ToString());

                                                if (movieId.HasValue && !string.IsNullOrWhiteSpace(m.albumDocInfo.albumId))
                                                {
                                                    Console.WriteLine("正在采集" + m.albumDocInfo.albumTitle + "的播放地址...");
                                                    //获取下载地址
                                                    CollectionMoviePlayer(movieId.Value, m.albumDocInfo.albumId, family);
                                                }
                                            }

                                });
                                //最大页码
                                maxPage = (res_obj.data.result_num.ToInt_() / pageSize) + ((res_obj.data.result_num.ToInt_() % pageSize) > 0 ? 1 : 0);
                            }
                            else
                                Console.WriteLine("加载数据失败\tcode:" + res_obj.code);
                        }
                    }
                    else
                        Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
                }

            }
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
                //初始化参数
                int pageSize = 120;
                int maxPage = 10;
                for (int page = 1; page <= maxPage; page++)
                {
                    int result_num = 0;
                    //发送请求
                    var httpResult = new HttpHelper().GetHtml(new HttpItem()
                    {
                        URL = "http://mixer.video.iqiyi.com/jp/mixin/videos/avlist?page=" + page + "&size=" + pageSize + "&albumId=" + hash,
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
                                        Episodes = family == Family.电影 ? null: m.order,
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
