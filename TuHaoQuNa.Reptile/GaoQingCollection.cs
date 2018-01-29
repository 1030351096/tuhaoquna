using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuHaoQuNa.Domain.Enum;
using DripOldDriver;
using TuHaoQuNa.Business;
using HtmlAgilityPack;
using System.Threading;

namespace TuHaoQuNa.Reptile
{
    public class GaoQingCollection
    {
        HttpHelper http;
        Movie_BLL movie_bll;
        Download_BLL download_bll;
        Subtitle_BLL subtitle_bll;
        DouBanCollection douBanCollection;

        public GaoQingCollection()
        {
            http = new HttpHelper();
            movie_bll = new Movie_BLL();
            download_bll = new Download_BLL();
            subtitle_bll = new Subtitle_BLL();
            douBanCollection = new DouBanCollection();
        }

        /// <summary>
        /// 爬取电影列表
        /// </summary>
        /// <param name="family"></param>
        public void CollectionMovies(Family family)
        {
            //发送请求
            var httpResult = http.GetHtml(new HttpItem()
            {
                URL = (family == Family.电视剧 ? "https://gaoqing.fm/api/listtv?limit=500000&page=" : "https://gaoqing.fm/api/listfilm?limit=500000&page=") + 1,
                Accept = "application/json",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });

            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //将结果处理成实体集合
                var list = httpResult.Html.ParseJSON<List<Models.GaoQing.GaoQing>>().OrderBy(o => o.nd).ToList();
                Console.WriteLine("本次共采集到" + family.ToString_() + ":\t" + list.Count + "条...");
                list.ForEach_(m => {
                    ////判断该豆瓣ID是否已经存在
                    //int? movieId = movie_bll.GetMovieIDByDouBanID(m.subject);
                    //if (!movieId.HasValue)
                    //{
                    //    //根据豆瓣ID获取详细信息
                    //    movieId = douBanCollection.CollectionDouBanInfo(m.subject);
                    //}
                    //else
                    //    Console.WriteLine(family.ToString_() + ":\t" + m.name + "\t已经被收录！");

                    int? movieId = douBanCollection.CollectionDouBanInfo(m.subject);

                    if (movieId.HasValue)
                    {
                        Console.WriteLine("正在采集" + m.name + "的资源...");
                        //获取下载地址
                        CollectionMovieLib(movieId.Value, m.hash, m.name);
                        //new Task(() =>
                        //{
                        //    Console.WriteLine("正在采集" + m.name + "的资源...");
                        //    //获取下载地址
                        //    CollectionMovieLib(movieId.Value, m.hash, m.name);
                        //}).Start();
                    }
                });
            }
            else
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);

        }

        /// <summary>
        /// 爬取电影的资源
        /// </summary>
        /// <param name="movieID"></param>
        /// <param name="hash"></param>
        public void CollectionMovieLib(int movieID, string hash, string name)
        {
            //发送请求
            var httpResult = http.GetHtml(new HttpItem()
            {
                URL = "https://gaoqing.fm/view/"+hash,
                Accept = "text/html",
                ReadWriteTimeout = 1000 * 60,
                Timeout = 1000 * 60
            });
            //判断请求是否成功
            if (httpResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (httpResult.Html.Contains("你的刷新频率太快了，请慢点。"))
                {
                    Console.WriteLine("你的刷新频率太快了，请慢点。");
                    Thread.Sleep(500);
                    CollectionMovieLib(movieID, hash, name);
                }
                else
                {
                    Console.WriteLine("正在采集"+ name + "的下载地址...");
                    AnalysisMovieDownloadHtml(movieID, httpResult.Html);
                    Console.WriteLine("正在采" + name + "的集字幕...");
                    AnalysisMovieSubtitleHtml(movieID, httpResult.Html);
                }
            }
            else
                Console.WriteLine("请求发生错误\tStatusCode:" + httpResult.StatusCode);
        }

        public void AnalysisMovieDownloadHtml(int movieID, string html)
        {
            try
            {
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(html);
                var node = hd.DocumentNode.SelectSingleNode("//table[@id='cili']");
                var info_nodes = node == null ? null : node.SelectNodes("./tr");
                if (info_nodes != null)
                {
                    for (int i = 0; i < (info_nodes.Count > 10 ? info_nodes.Count - 2 : info_nodes.Count); i++)
                    {
                        var item = info_nodes[i];
                        string clear = item.GetAttributeValue("id", "") == null ? null : item.GetAttributeValue("id", "").Trim();
                        switch (clear)
                        {
                            case "原盘REMUX":
                                clear = "Remux";
                                break;
                            case "左右3D":
                                clear = "3D";
                                break;
                            case "3D原盘中字":
                                clear = "3D Bluray";
                                break;
                            case "WEB-DL":
                                clear = "WEB-DL";
                                break;
                            case "上下3D":
                                clear = "3D";
                                break;
                            case "蓝光原盘":
                                clear = "Bluray";
                                break;
                            case "HDTV":
                                clear = "HDTV";
                                break;
                            case "硬字幕版":
                                clear = "HD";
                                break;
                            case "720P":
                                clear = "720P";
                                break;
                            case "原盘中字":
                                clear = "Bluray";
                                break;
                            case "3D原盘":
                                clear = "3D Bluray";
                                break;
                            case "1080P":
                                clear = "1080P";
                                break;
                            case "非高清或错误":
                                clear = "其它";
                                break;
                            default:
                                clear = "其它";
                                break;
                        }
                        var name = item.SelectSingleNode("./td/b") == null ? "" : item.SelectSingleNode("./td/b").InnerText.Trim();
                        string size_str = item.SelectSingleNode("./td/span/span[1]") == null ? null : item.SelectSingleNode("./td/span/span[1]").InnerText.Trim();
                        decimal? size = null;
                        if (!string.IsNullOrWhiteSpace(size_str))
                        {
                            if (size_str.Contains("TB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("TB", "").Trim(), 0) * (1024.0 * 1024.0 * 1024.0));
                            if (size_str.Contains("GB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("GB", "").Trim(), 0) * (1024.0 * 1024.0));
                            if (size_str.Contains("MB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("MB", "").Trim(), 0) * (1024.0));
                            if (size_str.Contains("KB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("KB", "").Trim(), 0));
                            size = size == 0 ? null : size;
                        }
                        //decimal? size = Convert.ToDecimal(string.IsNullOrWhiteSpace(size_str) ? 0 : ((size_str.Contains("GB") ? Utils.StrToDouble(size_str.Replace("GB", "").Trim(), 0) : ((size_str.Contains("MB") ? Utils.StrToDouble(size_str.Replace("MB", "").Trim(), 0) : (size_str.Contains("KB") ? Utils.StrToDouble(size_str.Replace("KB", "").Trim(), 0) : 0)) * 1024.0)) * 1024.0 * 1024.0));
                        var meta = item.SelectSingleNode("./td/span/span[2]") == null ? null : item.SelectSingleNode("./td/span/span[2]").InnerText.Trim();
                        var bthash = item.SelectSingleNode("./td/span/span[3]/a[1]") == null ? null : item.SelectSingleNode("./td/span/span[3]/a[1]").GetAttributeValue("href", "").Trim();
                        var magnet = item.SelectSingleNode("./td/span/span[3]/a[2]") == null ? null : item.SelectSingleNode("./td/span/span[3]/a[2]").GetAttributeValue("href", "").Trim();

                        if (!string.IsNullOrWhiteSpace(magnet) && clear != "其它")
                        {
                            int did = new Download_BLL().SaveDownload(new Domain.Entity.Download_Repository()
                            {
                                CreateTime = DateTime.Now,
                                Clear = clear,
                                Size = size == 0 ? null : size,
                                Guid = Guid.NewGuid().ToString().ToUpper(),
                                Magnet = string.IsNullOrWhiteSpace(magnet) ? null : magnet,
                                Meta = string.IsNullOrWhiteSpace(meta) ? null : meta,
                                MovieID = movieID,
                                Source = "gaoqing",
                                Title = name,
                                BitTorrent = bthash
                            });
                            if (did>0)
                                Console.WriteLine(name+"\t"+ size_str + "\t写入数据库成功!");
                            else
                                Console.WriteLine(name + "\t" + size_str + "\t写入数据库失败!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void AnalysisMovieSubtitleHtml(int movieID, string html)
        {
            try
            {
                HtmlDocument hd = new HtmlDocument();
                hd.LoadHtml(html);
                var node = hd.DocumentNode.SelectSingleNode("//table[@id='subtable']");
                var info_nodes = node == null ? null : node.SelectNodes("./tr");
                //var info_nodes = node.SelectNodes("./tr");
                if (info_nodes != null)
                {
                    for (int i = 0; i < (info_nodes.Count > 10 ? info_nodes.Count - 2 : info_nodes.Count); i++)
                    {
                        var item = info_nodes[i];
                        string clear = item.GetAttributeValue("id", "") == null ? null : item.GetAttributeValue("id", "").Trim();
                        var name = item.SelectSingleNode("./td/span/b") == null ? "" : item.SelectSingleNode("./td/span/b").InnerText.Trim();
                        string size_str = item.SelectSingleNode("./td/span[2]/span[1]") == null ? null : item.SelectSingleNode("./td/span[2]/span[1]").InnerText.Trim();
                        decimal? size = null;
                        if (!string.IsNullOrWhiteSpace(size_str))
                        {
                            if (size_str.Contains("TB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("TB", "").Trim(), 0) * (1024.0 * 1024.0 * 1024.0));
                            if (size_str.Contains("GB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("GB", "").Trim(), 0) * (1024.0 * 1024.0));
                            if (size_str.Contains("MB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("MB", "").Trim(), 0) * (1024.0));
                            if (size_str.Contains("KB"))
                                size = Convert.ToDecimal(Utils.ToDouble_(size_str.Replace("KB", "").Trim(), 0));
                            size = size == 0 ? null : size;
                        }
                        var source = item.SelectSingleNode("./td/span[2]/span[2]") == null ? null : item.SelectSingleNode("./td/span[2]/span[2]").InnerText.Trim();
                        var format_nodes = item.SelectNodes("./td/span[2]/span[@class='label label-danger']");
                        var format_str = "";
                        if (format_nodes != null)
                        {
                            foreach (var m in format_nodes)
                            {
                                var t_format = m.InnerText.Trim();
                                if (!string.IsNullOrWhiteSpace(t_format))
                                {
                                    format_str += t_format + ",";
                                }
                            }
                        }
                        format_str = format_str.TrimEnd(',');

                        var language_node = item.SelectSingleNode("./td/span[2]/span[last()]/span");
                        var language = "";
                        var meat = "";
                        if (language_node != null)
                        {
                            language = language_node.GetAttributeValue("title", "").Trim().Replace(" ", ",");
                            meat = language_node.InnerText.Trim();
                        }

                        var download = "";
                        var download_node = item.SelectSingleNode("./td/span[2]/span[last()]/a");
                        if (download_node != null)
                            download = download_node.GetAttributeValue("href", "");

                        if (!string.IsNullOrWhiteSpace(download))
                        {
                            int sid = new Subtitle_BLL().SaveSubtitle(new Domain.Entity.Subtitle_Repository()
                            {
                                Clear = clear,
                                Size = size == 0 ? null : size,
                                CreateTime = DateTime.Now,
                                Title = name,
                                Format = format_str,
                                Language = string.IsNullOrWhiteSpace(language) ? null : language,
                                Meta = string.IsNullOrWhiteSpace(meat) ? null : meat,
                                Download = string.IsNullOrWhiteSpace(download) ? null : download,
                                Source = string.IsNullOrWhiteSpace(source) ? null : source,
                                Guid = Guid.NewGuid().ToString().ToUpper(),
                                MovieID = movieID
                            });
                            if (sid > 0)
                                Console.WriteLine(name + "\t" + meat + "\t写入数据库成功!");
                            else
                                Console.WriteLine(name + "\t" + meat + "\t写入数据库失败!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
