﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DripOldDriver;
using TuHaoQuNa.Business;
using TuHaoQuNa.WebApi.Models;
using TuHaoQuNa.WebApi.Models.Input;
using static TuHaoQuNa.WebApi.Models.Output.OutputParameter;
using TuHaoQuNa.WebApi.Attribute;

namespace TuHaoQuNa.WebApi.Controllers
{
    /// <summary>
    /// 影片相关
    /// </summary>
    public class FilmController : ApiController
    {

        Movie_BLL movie_bll = new Movie_BLL();
        Download_BLL download_bll = new Download_BLL();
        Player_BLL player_bll = new Player_BLL();
        Subtitle_BLL subtitle_bll = new Subtitle_BLL();

        /// <summary>
        /// 获取热门影片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetHotFilm")]
        public ApiResult GetHotFilm(PageParamsDto data)
        {
            var pageObj = movie_bll.PageFilm(data.page, data.pageSize, Domain.Enum.OrderBy.在看人数);
            return new ApiResult() {
                StatusCode = HttpStatusCode.OK,
                Data = new {
                    list = pageObj.Items.Select(m=>new Film {
                        Describe = m.Describe,
                        Family = m.Family,
                        DouBanID = m.DouBanID,
                        Name = m.Name,
                        Poster = m.Poster,
                        Score = m.Score,
                        Year = m.Year
                    }),
                    page = pageObj.CurrentPage,
                    pageSize = pageObj.ItemsPerPage,
                    totalPage = pageObj.TotalPages
                }
            };
        }

        /// <summary>
        /// 获取影片列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetFilm")]
        public ApiResult GetFilm(PageFilmParamsDto data)
        {
            data.year = data.year == "不限" ? "" : data.year;
            data.genre = data.genre == "不限" ? "" : data.genre;
            data.country = data.country == "不限" ? "" : data.country;
            data.state = data.state == "不限" ? "" : data.state;
            var pageObj = movie_bll.PageFilm(data.page, data.pageSize, data.orderby, data.family, data.genre, data.country, data.year,data.state);
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new
                {
                    list = pageObj.Items.Select(m => new Film
                    {
                        Describe = m.Describe,
                        Family = m.Family,
                        DouBanID = m.DouBanID,
                        Name = m.Name,
                        Poster = m.Poster,
                        Score = m.Score,
                        Year = m.Year
                    }),
                    page = pageObj.CurrentPage,
                    pageSize = pageObj.ItemsPerPage,
                    totalPage = pageObj.TotalPages
                }
            };
        }

        /// <summary>
        /// 获取预告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetPreview")]
        public ApiResult GetPreview(PreviewParamsDto data)
        {
            var result = movie_bll.GetPreview(data.doubanID.ToUpper(), data.previewtype);

            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = result.Select(s => new MoviePreview {
                    Photo = s.Photo,
                    Title = s.Title,
                    Video = s.Video
                }).ToList()
            };
        }

        /// <summary>
        /// 获取资源数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetResourceQuantity")]
        public ApiResult GetResourceQuantity(ResourceQuantityParamsDto data)
        {
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new {
                    Director = movie_bll.GetDirector(data.doubanID.ToUpper()).Count(),
                    Screenwriter = movie_bll.GetScreenwriter(data.doubanID.ToUpper()).Count(),
                    Performer = movie_bll.GetPerformer(data.doubanID.ToUpper()).Count(),
                    Download = download_bll.GetDownload(data.doubanID.ToUpper()).Count(),
                    Subtitle = subtitle_bll.GetSubtitle(data.doubanID.ToUpper()).Count(),
                    Player = player_bll.GetPlayer(data.doubanID.ToUpper()).Count()
                }
            };
        }

        /// <summary>
        /// 获取影人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetCelebrity")]
        public ApiResult GetCelebrity(ResourceQuantityParamsDto data)
        {
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = new
                {
                    Director = movie_bll.GetDirector(data.doubanID.ToUpper()),
                    Screenwriter = movie_bll.GetScreenwriter(data.doubanID.ToUpper()),
                    Performer = movie_bll.GetPerformer(data.doubanID.ToUpper())
                }
            };
        }

        /// <summary>
        /// 获取下载地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetDownload")]
        public ApiResult GetDownload(ResourceQuantityParamsDto data)
        {
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = download_bll.GetDownload(data.doubanID.ToUpper()).GroupBy(g=>g.Clear).Select(s=>new { Clear = s.Key, List = s }).OrderBy(o=>o.Clear)
            };
        }

        /// <summary>
        /// 获取字幕
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetSubtitle")]
        public ApiResult GetSubtitle(ResourceQuantityParamsDto data)
        {
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = subtitle_bll.GetSubtitle(data.doubanID.ToUpper())
            };
        }

        /// <summary>
        /// 获取播放地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("api/GetPlayer")]
        public ApiResult GetPlayer(ResourceQuantityParamsDto data)
        {
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = player_bll.GetPlayer(data.doubanID.ToUpper()).OrderBy(p => p.Episodes)
                                    .GroupBy(g => g.Platform)
                                    .Select(s => new
                                    {
                                        Platform = s.Key,
                                        List = s.GroupBy(g => g.Name)
                                        .Select(e => new
                                        {
                                            Name = e.Key,
                                            Episodes = e.Select(l => new
                                            {
                                                Description = l.Description,
                                                Guid = l.PlayerGuid,
                                                Episodes = l.Episodes
                                            }).OrderBy(o=>o.Episodes)
                                        }).OrderBy(o => o.Name)
                                    })
            };
        }
    }
}