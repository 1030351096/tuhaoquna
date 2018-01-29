using DripOldDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TuHaoQuNa.Business;

namespace TuHaoQuNa.Web.Controllers
{
    [Compress]
    public class HomeController : Controller
    {
        Movie_BLL movie_bll = new Movie_BLL();
        Player_BLL player_bll = new Player_BLL();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public ActionResult Index()
        {
            var pageObj = movie_bll.PageFilm(1, 20, TuHaoQuNa.Domain.Enum.OrderBy.在看人数);
            var list = pageObj==null? null : pageObj.Items
                .Select(m=>new Models.Film {
                    Describe = m.Describe,
                    Family = m.Family,
                    DouBanID = m.DouBanID,
                    Name = m.Name,
                    Poster = m.Poster,
                    Score = m.Score,
                    Year = m.Year
                });
            return View(list);
        }

        [Route("Movie")]
        public ActionResult Movie()
        {
            var pageObj = movie_bll.PageFilm(1, 20, Domain.Enum.OrderBy.影评数量, Domain.Enum.Family.电影);
            var list = pageObj == null ? null : pageObj.Items
                .Select(m => new Models.Film
                {
                    Describe = m.Describe,
                    Family = m.Family,
                    DouBanID = m.DouBanID,
                    Name = m.Name,
                    Poster = m.Poster,
                    Score = m.Score,
                    Year = m.Year
                });
            ViewBag.Title = "电影";
            ViewBag.Family = Domain.Enum.Family.电影.ToInt_();
            return View("Film",list);
        }

        [Route("TvShow")]
        public ActionResult TvShow()
        {
            var pageObj = movie_bll.PageFilm(1, 20, Domain.Enum.OrderBy.影评数量, Domain.Enum.Family.电视剧);
            var list = pageObj == null ? null : pageObj.Items
                .Select(m => new Models.Film
                {
                    Describe = m.Describe,
                    Family = m.Family,
                    DouBanID = m.DouBanID,
                    Name = m.Name,
                    Poster = m.Poster,
                    Score = m.Score,
                    Year = m.Year
                });
            ViewBag.Title = "电影";
            ViewBag.Family = Domain.Enum.Family.电视剧.ToInt_();
            return View("Film", list);
        }

        [Route("Search/{keyword?}")]
        public ActionResult Search(string keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                ViewBag.Keyword = keyword;
                return View();
            }
            else
            {
                var pageObj = movie_bll.PageFilm(1, 20, Domain.Enum.OrderBy.在看人数);
                var list = pageObj == null ? null : pageObj.Items
                    .Select(m => new Models.Film
                    {
                        Describe = m.Describe,
                        Family = m.Family,
                        DouBanID = m.DouBanID,
                        Name = m.Name,
                        Poster = m.Poster,
                        Score = m.Score,
                        Year = m.Year
                    });
                return View(list);
            }
        }

        [Route("Subject/{doubanID}")]
        public ActionResult Subject(string doubanID)
        {
            var filmInfo = movie_bll.GetFilmInfo(doubanID);
            if (filmInfo==null)
            {
                var t_task = new System.Threading.Tasks.Task(() => {
                    new TuHaoQuNa.Reptile.DouBanCollection().CollectionDouBanInfo(doubanID);
                });
                t_task.Start();
                t_task.Wait();
                filmInfo = movie_bll.GetFilmInfo(doubanID);
            }
            ViewBag.Title = filmInfo.Name + " " + filmInfo.OriginalTitle;
            ViewBag.Keywords = filmInfo.Name + "," + filmInfo.OriginalTitle + (string.IsNullOrWhiteSpace(filmInfo.AkaNames)?"": "," + filmInfo.AkaNames.Replace(" / ", ",")) + (string.IsNullOrWhiteSpace(filmInfo.CategoryNames)?"" : ","+ filmInfo.CategoryNames.Replace(" / ", ","));
            ViewBag.Description = filmInfo.Describe;
            return View(new Models.FilmInfo() {
                AkaNames = filmInfo.AkaNames,
                Alt = filmInfo.Alt,
                CategoryNames = filmInfo.CategoryNames,
                Describe = filmInfo.Describe,
                DouBanID = filmInfo.DouBanID,
                Family = filmInfo.Family,
                Name = filmInfo.Name,
                OriginalTitle = filmInfo.OriginalTitle,
                Poster = filmInfo.Poster,
                PubDate = filmInfo.PubDate,
                PubDates = filmInfo.PubDates,
                Score = filmInfo.Score,
                Year = filmInfo.Year,
                CountrieNames = filmInfo.CountrieNames,
                Pictures = string.IsNullOrWhiteSpace(filmInfo.Pictures)?null: filmInfo.Pictures.Split(','),
                LongTimes = filmInfo.LongTimes
            });
        }

        [Route("Player/{guid}")]
        public ActionResult Player(string guid)
        {
            guid = guid.ToUpper();
            return View(player_bll.SinglePlayer(guid));
        }

        [Route("Celebrity/{doubanID}")]
        public ActionResult Celebrity(string doubanID)
        {
            return View();
        }
    }
}