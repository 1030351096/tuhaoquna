﻿using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TuHaoQuNa.Domain.Entity;
using DripOldDriver;
using TuHaoQuNa.Domain.Enum;
using TuHaoQuNa.Domain.View;

namespace TuHaoQuNa.Business
{
    public class Movie_BLL
    {

        private Database db;

        public Movie_BLL(string connectionStringName = "TuHaoQuNa")
        {
            db = new Database(connectionStringName);
        }

        /// <summary>
        /// 带事物插入电影完整信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns>电影ID</returns>
        public int? ThingInsertMovie(Movie model)
        {
            int? movieID = null;
            if (db.InTransaction(() =>
            {
                //写入基本信息
                movieID = InsertMovieBasic(new MovieBasic_Repository()
                {
                    CreateTime = DateTime.Now,
                    DouBanID = model.DouBanID,
                    Describe = model.Describe,
                    Family = model.Family.ToInt_(),
                    Name = model.Name,
                    Poster = model.Poster,
                    Year = model.Year,
                    Score = model.Score
                });
                //写入详细信息
                if (!InsertMovieDetail(new MovieDetail_Repository()
                {
                    Alt = model.Alt,
                    DouBanSite = model.DouBanSite,
                    ScheduleUrl = model.ScheduleUrl,
                    CreateTime = DateTime.Now,
                    MobileUrl = model.MobileUrl,
                    MovieID = movieID.Value,
                    OriginalTitle = model.OriginalTitle,
                    PubDate = model.PubDate,
                    ShareUrl = model.ShareUrl,
                    WebSite = model.WebSite
                }))
                    throw new Exception("写入MovieDetail_Repository失败!");
                //写入动态数据
                if (!InsertMovieDynamic(new MovieDynamic_Repository()
                {
                    CollectCount = model.CollectCount,
                    CommentsCount = model.CommentsCount,
                    CreateTime = DateTime.Now,
                    DoCount = model.DoCount,
                    MovieID = movieID.Value,
                    RatingsCount = model.RatingsCount,
                    ReviewsCount = model.ReviewsCount,
                    WishCount = model.WishCount
                }))
                    throw new Exception("写入MovieDynamic_Repository失败!");
                if (model.Family == Domain.Enum.Family.电视剧)
                    //写入电视剧集数季数数据
                    if (!InsertMovieSerial(new MovieSerial_Repository()
                    {
                        CreateTime = DateTime.Now,
                        CurrentSeason = model.CurrentSeason,
                        SeasonsCount = model.SeasonsCount,
                        EpisodesCount = model.EpisodesCount,
                        MovieID = movieID.Value
                    }))
                        throw new Exception("写入MovieSerial_Repository失败!");
                //清空上映时间的关系
                ClearRelationPubDate(movieID.Value);
                if (model.PubDatas != null)
                    model.PubDatas.ForEach_(p =>
                    {
                        int? pubId = GetPubDateID(p.PubDate, p.PubPlace);
                        if (!pubId.HasValue)
                            pubId = InsertMoviePubDate(new MoviePubDate_Repository()
                            {
                                CreateTime = DateTime.Now,
                                PubDate = p.PubDate,
                                PubPlace = p.PubPlace
                            });
                        if (!InsertRelationPubDate(new Relation_PubDate_Repository()
                        {
                            MovieID = movieID.Value,
                            PubID = pubId.Value
                        }))
                            throw new Exception("写入Relation_PubDate_Repository失败!");
                    });
                //清空电影又名
                ClearMovieAka(movieID.Value);
                if (model.Aka != null)
                    model.Aka.ForEach_(a => 
                    {
                        if (!InsertMovieAka(new MovieAka_Repository()
                        {
                            MovieID = movieID.Value,
                            Name = a
                        }))
                            throw new Exception("写入MovieAka_Repository失败!");
                    });
                //清空片长
                ClearDuration(movieID.Value);
                if (model.Durations != null)
                    model.Durations.ForEach_(a =>
                    {
                        if (!InsertDuration(new Duration_Repository()
                        {
                            MovieID = movieID.Value,
                            LongTime = a.LongTime,
                            Plan = a.Plan
                        }))
                            throw new Exception("写入Duration_Repository失败!");
                    });
                //清空剧照
                ClearMoviePhoto(movieID.Value);
                if (model.Pictures != null)
                    model.Pictures.ForEach_(p=> 
                    {
                        if (!InsertMoviePhoto(new MoviePhoto_Repository()
                        {
                            MovieID = movieID.Value,
                            Picture = p
                        }))
                            throw new Exception("写入MoviePhoto_Repository失败!");
                    });
                //清空标签的关系
                ClearRelationTag(movieID.Value);
                if (model.Tags != null)
                    model.Tags.ForEach_(t => 
                    {
                        int? tagId = GetTagID(t);
                        if (!tagId.HasValue)
                            tagId = InsertMovieTag(new MovieTag_Repository()
                            {
                                CreateTime = DateTime.Now,
                                Name = t
                            });
                        if (!InsertRelationTag(new Relation_Tag_Repository()
                        {
                            MovieID = movieID.Value,
                            TagID = tagId.Value
                        }))
                            throw new Exception("写入Relation_Tag_Repository失败!");
                    });
                //清空类型的关系
                ClearRelationCategory(movieID.Value);
                if (model.Categorys != null)
                    model.Categorys.ForEach_(c=> 
                    {
                        int? categoryId = GetCategoryID(c);
                        if (!categoryId.HasValue)
                            categoryId = InsertCategory(new Category_Repository()
                            {
                                Name = c
                            });
                        if (!InsertRelationCategory(new Relation_Category_Repository()
                        {
                            CategoryID = categoryId.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Category_Repository失败!");
                    });
                //清空制片国家地区的关系
                ClearRelationCountrie(movieID.Value);
                if (model.Countries != null)
                    model.Countries.ForEach_(c=> 
                    {
                        int? countrieId = GetCountrieID(c);
                        if (!countrieId.HasValue)
                            countrieId = InsertCountrie(new Countrie_Repository()
                            {
                                Name = c
                            });
                        if (!InsertRelationCountrie(new Relation_Countrie_Repository()
                        {
                            CountrieID = countrieId.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Countrie_Repository失败!");
                    });
                //清空编剧的关系
                ClearRelationScreenwriter(movieID.Value);
                if (model.Screenwriters != null)
                    model.Screenwriters.ForEach_(s=> 
                    {
                        int? cid = GetCelebrityID(s.DouBanID);
                        if (!cid.HasValue)
                            cid = InsertCelebrity(new Celebrity_Repository()
                            {
                                Alt = s.Alt,
                                Avatar = s.Avatar,
                                CreateTime = DateTime.Now,
                                DouBanID = s.DouBanID,
                                Name = s.Name
                            });
                        if (!InsertRelationScreenwriter(new Relation_Screenwriter_Repository()
                        {
                            CelebrityID = cid.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Screenwriter_Repository失败!");
                    });
                //清空导演的关系
                ClearRelationDirector(movieID.Value);
                if (model.Directors != null)
                    model.Directors.ForEach_(d =>
                    {
                        int? cid = GetCelebrityID(d.DouBanID);
                        if (!cid.HasValue)
                            cid = InsertCelebrity(new Celebrity_Repository()
                            {
                                Alt = d.Alt,
                                Avatar = d.Avatar,
                                CreateTime = DateTime.Now,
                                DouBanID = d.DouBanID,
                                Name = d.Name
                            });
                        if (!InsertRelationDirector(new Relation_Director_Repository()
                        {
                            CelebrityID = cid.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Director_Repository失败!");
                    });
                //清空演员的关系
                ClearRelationPerformer(movieID.Value);
                if (model.Performers != null)
                    model.Performers.ForEach_(p =>
                    {
                        int? cid = GetCelebrityID(p.DouBanID);
                        if (!cid.HasValue)
                            cid = InsertCelebrity(new Celebrity_Repository()
                            {
                                Alt = p.Alt,
                                Avatar = p.Avatar,
                                CreateTime = DateTime.Now,
                                DouBanID = p.DouBanID,
                                Name = p.Name
                            });
                        if (!InsertRelationPerformer(new Relation_Performer_Repository()
                        {
                            CelebrityID = cid.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Performer_Repository失败!");
                    });
                //清空语言的关系
                ClearRelationLanguage(movieID.Value);
                if (model.Languages != null)
                    model.Languages.ForEach_(l=> 
                    {
                        int? lid = GetLanguageID(l);
                        if (!lid.HasValue)
                            lid = InsertLanguage(new Language_Repository()
                            {
                                Name = l
                            });
                        if (!InsertRelationLanguage(new Relation_Language_Repository()
                        {
                            LanguageID = lid.Value,
                            MovieID = movieID.Value
                        }))
                            throw new Exception("写入Relation_Language_Repository失败!");
                    });
                //清空预告片
                ClearMoviePreview(movieID.Value, PreviewType.预告片);
                if (model.Trailers != null)
                    model.Trailers.ForEach_(t=> 
                    {
                        if (!InsertMoviePreview(new MoviePreview_Repository()
                        {
                            MovieID = movieID.Value,
                            CreateTime = DateTime.Now,
                            Photo = t.Photo,
                            PreviewType = PreviewType.预告片.ToInt_(),
                            Title = t.Title,
                            UID = t.UID,
                            Video = t.Video
                        }))
                            throw new Exception("写入MoviePreview_Repository失败!");
                    });
                //清空花絮
                ClearMoviePreview(movieID.Value, PreviewType.花絮);
                if (model.Trailers != null)
                    model.Trailers.ForEach_(t =>
                    {
                        if (!InsertMoviePreview(new MoviePreview_Repository()
                        {
                            MovieID = movieID.Value,
                            CreateTime = DateTime.Now,
                            Photo = t.Photo,
                            PreviewType = PreviewType.花絮.ToInt_(),
                            Title = t.Title,
                            UID = t.UID,
                            Video = t.Video
                        }))
                            throw new Exception("写入MoviePreview_Repository失败!");
                    });
                //清空片段
                ClearMoviePreview(movieID.Value, PreviewType.片段);
                if (model.Trailers != null)
                    model.Trailers.ForEach_(t =>
                    {
                        if (!InsertMoviePreview(new MoviePreview_Repository()
                        {
                            MovieID = movieID.Value,
                            CreateTime = DateTime.Now,
                            Photo = t.Photo,
                            PreviewType = PreviewType.片段.ToInt_(),
                            Title = t.Title,
                            UID = t.UID,
                            Video = t.Video
                        }))
                            throw new Exception("写入MoviePreview_Repository失败!");
                    });

            }))
                return movieID;
            else
                return null;
        }

        /// <summary>
        /// 更新电影完整信息
        /// </summary>
        /// <param name="model"></param>
        public void ThingUpdateMovie(Movie model)
        {
            db.InTransaction(() => {
                //更新基本信息
                db.Execute("UPDATE dbo.MovieBasic Set " +
                    "[LastTime] = @1," +
                    "[Describe] = @2," +
                    "[Poster] = @3," +
                    "[Score] = @4" +
                    " Where [ID] = @0",
                    model.ID,
                    DateTime.Now,
                    model.Describe,
                    model.Poster,
                    model.Score
                    );

                //更新详细信息
                db.Execute("UPDATE dbo.MovieDetail Set " +
                    "[LastTime] = @1," +
                    "[PubDate] = @2" +
                    " Where [MovieID] = @0",
                    model.ID,
                    DateTime.Now,
                    model.PubDate
                    );
                //更新动态数据
                db.Execute("UPDATE dbo.MovieDynamic Set " +
                    "[LastTime] = @1," +
                    "[CollectCount] = @2," +
                    "[CommentsCount] = @3," +
                    "[DoCount] = @4," +
                    "[RatingsCount] = @5," +
                    "[ReviewsCount] = @6," +
                    "[WishCount] = @7" +
                    " Where [MovieID] = @0",
                    model.ID,
                    DateTime.Now,
                    model.CollectCount,
                    model.CommentsCount,
                    model.DoCount,
                    model.RatingsCount,
                    model.ReviewsCount,
                    model.WishCount
                    );
                if (model.Family == Domain.Enum.Family.电视剧)
                    //更新电视剧集数季数数据
                    db.Execute("UPDATE dbo.MovieSerial Set " +
                        "[LastTime] = @1," +
                        "[CurrentSeason] = @2," +
                        "[SeasonsCount] = @3," +
                        "[EpisodesCount] = @4" +
                        " Where [MovieID] = @0",
                        model.ID,
                        DateTime.Now,
                        model.CurrentSeason,
                        model.SeasonsCount,
                        model.EpisodesCount
                        );
                ////清空上映时间的关系
                //ClearRelationPubDate(model.ID);
                //if (model.PubDatas != null)
                //    model.PubDatas.ForEach_(p =>
                //    {
                //        int? pubId = GetPubDateID(p.PubDate, p.PubPlace);
                //        if (!pubId.HasValue)
                //            pubId = InsertMoviePubDate(new MoviePubDate_Repository()
                //            {
                //                CreateTime = DateTime.Now,
                //                PubDate = p.PubDate,
                //                PubPlace = p.PubPlace
                //            });
                //        if (!InsertRelationPubDate(new Relation_PubDate_Repository()
                //        {
                //            MovieID = model.ID,
                //            PubID = pubId.Value
                //        }))
                //            throw new Exception("写入Relation_PubDate_Repository失败!");
                //    });
                ////清空电影又名
                //ClearMovieAka(model.ID);
                //if (model.Aka != null)
                //    model.Aka.ForEach_(a =>
                //    {
                //        if (!InsertMovieAka(new MovieAka_Repository()
                //        {
                //            MovieID = model.ID,
                //            Name = a
                //        }))
                //            throw new Exception("写入MovieAka_Repository失败!");
                //    });
                ////清空片长
                //ClearDuration(model.ID);
                //if (model.Durations != null)
                //    model.Durations.ForEach_(a =>
                //    {
                //        if (!InsertDuration(new Duration_Repository()
                //        {
                //            MovieID = model.ID,
                //            LongTime = a.LongTime,
                //            Plan = a.Plan
                //        }))
                //            throw new Exception("写入Duration_Repository失败!");
                //    });
                ////清空剧照
                //ClearMoviePhoto(model.ID);
                //if (model.Pictures != null)
                //    model.Pictures.ForEach_(p =>
                //    {
                //        if (!InsertMoviePhoto(new MoviePhoto_Repository()
                //        {
                //            MovieID = model.ID,
                //            Picture = p
                //        }))
                //            throw new Exception("写入MoviePhoto_Repository失败!");
                //    });
                ////清空标签的关系
                //ClearRelationTag(model.ID);
                //if (model.Tags != null)
                //    model.Tags.ForEach_(t =>
                //    {
                //        int? tagId = GetTagID(t);
                //        if (!tagId.HasValue)
                //            tagId = InsertMovieTag(new MovieTag_Repository()
                //            {
                //                CreateTime = DateTime.Now,
                //                Name = t
                //            });
                //        if (!InsertRelationTag(new Relation_Tag_Repository()
                //        {
                //            MovieID = model.ID,
                //            TagID = tagId.Value
                //        }))
                //            throw new Exception("写入Relation_Tag_Repository失败!");
                //    });
                ////清空类型的关系
                //ClearRelationCategory(model.ID);
                //if (model.Categorys != null)
                //    model.Categorys.ForEach_(c =>
                //    {
                //        int? categoryId = GetCategoryID(c);
                //        if (!categoryId.HasValue)
                //            categoryId = InsertCategory(new Category_Repository()
                //            {
                //                Name = c
                //            });
                //        if (!InsertRelationCategory(new Relation_Category_Repository()
                //        {
                //            CategoryID = categoryId.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Category_Repository失败!");
                //    });
                ////清空制片国家地区的关系
                //ClearRelationCountrie(model.ID);
                //if (model.Countries != null)
                //    model.Countries.ForEach_(c =>
                //    {
                //        int? countrieId = GetCountrieID(c);
                //        if (!countrieId.HasValue)
                //            countrieId = InsertCountrie(new Countrie_Repository()
                //            {
                //                Name = c
                //            });
                //        if (!InsertRelationCountrie(new Relation_Countrie_Repository()
                //        {
                //            CountrieID = countrieId.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Countrie_Repository失败!");
                //    });
                ////清空编剧的关系
                //ClearRelationScreenwriter(model.ID);
                //if (model.Screenwriters != null)
                //    model.Screenwriters.ForEach_(s =>
                //    {
                //        int? cid = GetCelebrityID(s.DouBanID);
                //        if (!cid.HasValue)
                //            cid = InsertCelebrity(new Celebrity_Repository()
                //            {
                //                Alt = s.Alt,
                //                Avatar = s.Avatar,
                //                CreateTime = DateTime.Now,
                //                DouBanID = s.DouBanID,
                //                Name = s.Name
                //            });
                //        if (!InsertRelationScreenwriter(new Relation_Screenwriter_Repository()
                //        {
                //            CelebrityID = cid.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Screenwriter_Repository失败!");
                //    });
                ////清空导演的关系
                //ClearRelationDirector(model.ID);
                //if (model.Directors != null)
                //    model.Directors.ForEach_(d =>
                //    {
                //        int? cid = GetCelebrityID(d.DouBanID);
                //        if (!cid.HasValue)
                //            cid = InsertCelebrity(new Celebrity_Repository()
                //            {
                //                Alt = d.Alt,
                //                Avatar = d.Avatar,
                //                CreateTime = DateTime.Now,
                //                DouBanID = d.DouBanID,
                //                Name = d.Name
                //            });
                //        if (!InsertRelationDirector(new Relation_Director_Repository()
                //        {
                //            CelebrityID = cid.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Director_Repository失败!");
                //    });
                ////清空演员的关系
                //ClearRelationPerformer(model.ID);
                //if (model.Performers != null)
                //    model.Performers.ForEach_(p =>
                //    {
                //        int? cid = GetCelebrityID(p.DouBanID);
                //        if (!cid.HasValue)
                //            cid = InsertCelebrity(new Celebrity_Repository()
                //            {
                //                Alt = p.Alt,
                //                Avatar = p.Avatar,
                //                CreateTime = DateTime.Now,
                //                DouBanID = p.DouBanID,
                //                Name = p.Name
                //            });
                //        if (!InsertRelationPerformer(new Relation_Performer_Repository()
                //        {
                //            CelebrityID = cid.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Performer_Repository失败!");
                //    });
                ////清空语言的关系
                //ClearRelationLanguage(model.ID);
                //if (model.Languages != null)
                //    model.Languages.ForEach_(l =>
                //    {
                //        int? lid = GetLanguageID(l);
                //        if (!lid.HasValue)
                //            lid = InsertLanguage(new Language_Repository()
                //            {
                //                Name = l
                //            });
                //        if (!InsertRelationLanguage(new Relation_Language_Repository()
                //        {
                //            LanguageID = lid.Value,
                //            MovieID = model.ID
                //        }))
                //            throw new Exception("写入Relation_Language_Repository失败!");
                //    });
                ////清空预告片
                //ClearMoviePreview(model.ID, PreviewType.预告片);
                //if (model.Trailers != null)
                //    model.Trailers.ForEach_(t =>
                //    {
                //        if (!InsertMoviePreview(new MoviePreview_Repository()
                //        {
                //            MovieID = model.ID,
                //            CreateTime = DateTime.Now,
                //            Photo = t.Photo,
                //            PreviewType = PreviewType.预告片.ToInt_(),
                //            Title = t.Title,
                //            UID = t.UID,
                //            Video = t.Video
                //        }))
                //            throw new Exception("写入MoviePreview_Repository失败!");
                //    });
                ////清空花絮
                //ClearMoviePreview(model.ID, PreviewType.花絮);
                //if (model.Trailers != null)
                //    model.Trailers.ForEach_(t =>
                //    {
                //        if (!InsertMoviePreview(new MoviePreview_Repository()
                //        {
                //            MovieID = model.ID,
                //            CreateTime = DateTime.Now,
                //            Photo = t.Photo,
                //            PreviewType = PreviewType.花絮.ToInt_(),
                //            Title = t.Title,
                //            UID = t.UID,
                //            Video = t.Video
                //        }))
                //            throw new Exception("写入MoviePreview_Repository失败!");
                //    });
                ////清空片段
                //ClearMoviePreview(model.ID, PreviewType.片段);
                //if (model.Trailers != null)
                //    model.Trailers.ForEach_(t =>
                //    {
                //        if (!InsertMoviePreview(new MoviePreview_Repository()
                //        {
                //            MovieID = model.ID,
                //            CreateTime = DateTime.Now,
                //            Photo = t.Photo,
                //            PreviewType = PreviewType.片段.ToInt_(),
                //            Title = t.Title,
                //            UID = t.UID,
                //            Video = t.Video
                //        }))
                //            throw new Exception("写入MoviePreview_Repository失败!");
                //    });
            });
        }

        #region 基础Insert
        /// <summary>
        /// 插入电影
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMovieBasic(MovieBasic_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入电影详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMovieDetail(MovieDetail_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入电影动态数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMovieDynamic(MovieDynamic_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入电视剧集数季数数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMovieSerial(MovieSerial_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入电影上映时间数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMoviePubDate(MoviePubDate_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入上映时间的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationPubDate(Relation_PubDate_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入电影又名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMovieAka(MovieAka_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入电影片长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertDuration(Duration_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入剧照
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMoviePhoto(MoviePhoto_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入标签
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertMovieTag(MovieTag_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入标签的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationTag(Relation_Tag_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertCategory(Category_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入类型的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationCategory(Relation_Category_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入制片国家地区
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertCountrie(Countrie_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入制片国家地区的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationCountrie(Relation_Countrie_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入影人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertCelebrity(Celebrity_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入编剧的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationScreenwriter(Relation_Screenwriter_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入演员的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationPerformer(Relation_Performer_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入导演的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationDirector(Relation_Director_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入语言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertLanguage(Language_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入语言的关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertRelationLanguage(Relation_Language_Repository model)
        {
            return db.Add(model);
        }

        /// <summary>
        /// 插入预览
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMoviePreview(MoviePreview_Repository model)
        {
            return db.Add(model);
        }
        #endregion

        #region 清空Clear
        /// <summary>
        /// 根据电影ID清空上映时间的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationPubDate(int movieID)
        {
            return db.Delete("dbo.Relation_PubDate", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空标签的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationTag(int movieID)
        {
            return db.Delete("dbo.Relation_Tag", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空类型的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationCategory(int movieID)
        {
            return db.Delete("dbo.Relation_Category", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空国家地区的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationCountrie(int movieID)
        {
            return db.Delete("dbo.Relation_Countrie", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空编剧的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationScreenwriter(int movieID)
        {
            return db.Delete("dbo.Relation_Screenwriter", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空演员的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationPerformer(int movieID)
        {
            return db.Delete("dbo.Relation_Performer", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空导演的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationDirector(int movieID)
        {
            return db.Delete("dbo.Relation_Director", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空语言的关系
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearRelationLanguage(int movieID)
        {
            return db.Delete("dbo.Relation_Language", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空又名
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearMovieAka(int movieID)
        {
            return db.Delete("dbo.MovieAka", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空片长
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearDuration(int movieID)
        {
            return db.Delete("dbo.Duration", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID清空剧照
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearMoviePhoto(int movieID)
        {
            return db.Delete("dbo.MoviePhoto", "MovieID", movieID) >= 0;
        }

        /// <summary>
        /// 根据电影ID与类型清空预览
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public bool ClearMoviePreview(int movieID, PreviewType previewType)
        {
            return db.Delete<MoviePreview_Repository>(Sql.Builder.Where("MovieID = @0 And PreviewType = @1", movieID, (int)previewType)) >= 0;
        }
        #endregion

        #region 获取ID
        /// <summary>
        /// 根据DouBanID获取电影ID
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public int? GetMovieIDByDouBanID(string doubanID)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.MovieBasic").Where("DouBanID = @0", doubanID));
        }

        /// <summary>
        /// 获取上映时间ID
        /// </summary>
        /// <param name="pubDate">上映时间</param>
        /// <param name="pubPlace">上映ID</param>
        /// <returns>上映时间ID</returns>
        public int? GetPubDateID(DateTime pubDate, string pubPlace)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.MoviePubDate").Where("PubDate = @0 And PubPlace = @1", pubDate, pubPlace));
        }

        /// <summary>
        /// 获取标签ID
        /// </summary>
        /// <param name="tag">标签</param>
        /// <returns>标签ID</returns>
        public int? GetTagID(string tag)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.MovieTag").Where("[Name] = @0", tag));
        }

        /// <summary>
        /// 获取类型ID
        /// </summary>
        /// <param name="categoryName">类型</param>
        /// <returns>类型ID</returns>
        public int? GetCategoryID(string categoryName)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Category").Where("[Name] = @0", categoryName));
        }

        /// <summary>
        /// 获取制片国家地区ID
        /// </summary>
        /// <param name="countrieName"></param>
        /// <returns>制片国家地区ID</returns>
        public int? GetCountrieID(string countrieName)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Countrie").Where("[Name] = @0", countrieName));
        }

        /// <summary>
        /// 获取影人ID
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns>影人ID</returns>
        public int? GetCelebrityID(string doubanID)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Celebrity").Where("[DouBanID] = @0", doubanID));
        }

        /// <summary>
        /// 获取语言ID
        /// </summary>
        /// <param name="language"></param>
        /// <returns>语言ID</returns>
        public int? GetLanguageID(string language)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Language").Where("[Name] = @0", language));
        }

        #endregion


        #region 业务查询
        /// <summary>
        /// 分页获取影片列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="family">电影还电视剧</param>
        /// <param name="genre">类型</param>
        /// <param name="country">国家</param>
        /// <param name="year">年份</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public Page<MovieBasic_Repository> PageFilm(long page, long pageSize, OrderBy orderby, Family? family = null, string genre = null, string country = null, string year= null, string state = null)
        {
            //构建查询列
            var sql = Sql.Builder.Select("dbo.MovieBasic.*, " +
                "dbo.MovieDetail.PubDate, " +
                "dbo.MovieDynamic.ReviewsCount, " +
                "dbo.MovieDynamic.WishCount, " +
                "dbo.MovieDynamic.CollectCount, " +
                "dbo.MovieDynamic.DoCount, " +
                "dbo.MovieDynamic.CommentsCount, " +
                "dbo.MovieDynamic.RatingsCount")
                .From("dbo.MovieBasic")
                .LeftJoin("dbo.MovieDetail").On("dbo.MovieBasic.ID = dbo.MovieDetail.MovieID")
                .LeftJoin("dbo.MovieDynamic").On("dbo.MovieBasic.ID = dbo.MovieDynamic.MovieID");

            //构建查询条件
            if (family.HasValue)
                sql.Where("Family = @0", family.Value.ToInt_());
            if (!string.IsNullOrWhiteSpace(year))
            {
                int? t_year = year.ToIntOrNull_();
                if (t_year.HasValue)
                    sql.Where("[Year] = @0", t_year);
                else
                {
                    switch (year)
                    {

                        case "00年代":
                            sql.Where("[Year] >= @0", 2000).Where("[Year] < @0", 2010);
                            break;
                        case "90年代":
                            sql.Where("[Year] >= @0", 1990).Where("[Year] < @0", 2000);
                            break;
                        case "80年代":
                            sql.Where("[Year] >= @0", 1980).Where("[Year] < @0", 1990);
                            break;
                        case "70年代":
                            sql.Where("[Year] >= @0", 1970).Where("[Year] < @0", 1980);
                            break;
                        case "更早":
                            sql.Where("[Year] < @0", 1970);
                            break;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(genre))
                sql.Where("dbo.MovieBasic.ID in " +
                    "(Select MovieID From Relation_Category Where CategoryID in (" +
                    "Select ID From Category Where [Genre] = @0"
                    + ") Group By MovieID)",genre);
            if (!string.IsNullOrWhiteSpace(country))
                sql.Where("dbo.MovieBasic.ID in (" +
                          "Select MovieID From Relation_Countrie Where CountrieID in (" +
                          "Select ID From Countrie Where [Country] = @0" +
                          ") Group By MovieID" +
                          ")", country);
            
            //构建排序规则
            switch (orderby)
            {
                case OrderBy.影评数量:
                    sql.OrderBy("ReviewsCount Desc");
                    break;
                case OrderBy.想看人数:
                    sql.OrderBy("WishCount Desc");
                    break;
                case OrderBy.看过人数:
                    sql.OrderBy("CollectCount Desc");
                    break;
                case OrderBy.在看人数:
                    sql.OrderBy("DoCount Desc");
                    break;
                case OrderBy.短评数量:
                    sql.OrderBy("CommentsCount Desc");
                    break;
                case OrderBy.评分人数:
                    sql.OrderBy("RatingsCount Desc");
                    break;
                case OrderBy.豆瓣评分:
                    sql.OrderBy("Score Desc");
                    break;
                case OrderBy.上映时间:
                    sql.OrderBy("PubDate Desc");
                    break;
                case OrderBy.更新时间:
                    sql.OrderBy("dbo.MovieBasic.CreateTime Desc");
                    break;
            }
            return db.Page<MovieBasic_Repository>(page, pageSize, sql);
        }

        ///// <summary>
        ///// 分页搜索影片
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="keyword"></param>
        ///// <param name="orderby"></param>
        ///// <returns></returns>
        //public Page<MovieBasic_Repository> PageSearchFilm(long page, long pageSize, string keyword, OrderBy orderby)
        //{
        //    //构建查询列
        //    var sql = Sql.Builder.Select("dbo.MovieBasic.*, " +
        //        "dbo.MovieDetail.PubDate, " +
        //        "dbo.MovieDynamic.ReviewsCount, " +
        //        "dbo.MovieDynamic.WishCount, " +
        //        "dbo.MovieDynamic.CollectCount, " +
        //        "dbo.MovieDynamic.DoCount, " +
        //        "dbo.MovieDynamic.CommentsCount, " +
        //        "dbo.MovieDynamic.RatingsCount")
        //        .From("dbo.MovieBasic")
        //        .LeftJoin("dbo.MovieDetail").On("dbo.MovieBasic.ID = dbo.MovieDetail.MovieID")
        //        .LeftJoin("dbo.MovieDynamic").On("dbo.MovieBasic.ID = dbo.MovieDynamic.MovieID");

        //    //构建查询条件
        //    if (!string.IsNullOrWhiteSpace(keyword))
        //        sql.Where("dbo.MovieBasic.DouBanID = @0" +
        //            " Or dbo.MovieBasic.Name like @0+'%'" +
        //            " Or dbo.MovieDetail.OriginalTitle like @0+'%'" +
        //            " Or dbo.MovieBasic.ID in (Select MovieID From dbo.Relation_Tag Where TagID in (Select ID From dbo.MovieTag Where [Name] = @0) Group By MovieID)" +
        //            " Or dbo.MovieBasic.ID in (Select MovieID From dbo.MovieAka Where [Name] like @0+'%' Group By MovieID)"
        //            //" Or dbo.MovieBasic.ID in (Select MovieID From dbo.Relation_Director Where CelebrityID in (Select ID From dbo.Celebrity Where [Name] like '%'+@0+'%') Group By MovieID)" +
        //            //" Or dbo.MovieBasic.ID in (Select MovieID From dbo.Relation_Screenwriter Where CelebrityID in (Select ID From dbo.Celebrity Where [Name] like '%'+@0+'%') Group By MovieID)" +
        //            //" Or dbo.MovieBasic.ID in (Select MovieID From dbo.Relation_Performer Where CelebrityID in (Select ID From dbo.Celebrity Where [Name] like '%'+@0+'%') Group By MovieID)",
        //            ,keyword);

        //    //构建排序规则
        //    switch (orderby)
        //    {
        //        case OrderBy.影评数量:
        //            sql.OrderBy("ReviewsCount Desc");
        //            break;
        //        case OrderBy.想看人数:
        //            sql.OrderBy("WishCount Desc");
        //            break;
        //        case OrderBy.看过人数:
        //            sql.OrderBy("CollectCount Desc");
        //            break;
        //        case OrderBy.在看人数:
        //            sql.OrderBy("DoCount Desc");
        //            break;
        //        case OrderBy.短评数量:
        //            sql.OrderBy("CommentsCount Desc");
        //            break;
        //        case OrderBy.评分人数:
        //            sql.OrderBy("RatingsCount Desc");
        //            break;
        //        case OrderBy.豆瓣评分:
        //            sql.OrderBy("Score Desc");
        //            break;
        //        case OrderBy.上映时间:
        //            sql.OrderBy("PubDate Desc");
        //            break;
        //        case OrderBy.更新时间:
        //            sql.OrderBy("dbo.MovieBasic.CreateTime Desc");
        //            break;
        //    }

        //    return db.Page<MovieBasic_Repository>(page, pageSize, sql);
        //}

        /// <summary>
        /// 根据DouBanID获取条目信息
        /// </summary>
        /// <param name="douBanID"></param>
        /// <returns></returns>
        public View_FilmInfo_Repository GetFilmInfo(string douBanID)
        {
            return db.SingleOrDefault<View_FilmInfo_Repository>(Sql.Builder.Where("[DouBanID] = @0", douBanID));
        }

        /// <summary>
        /// 根据DouBanID获取预告
        /// </summary>
        /// <param name="doubanID"></param>
        /// <param name="previewtype"></param>
        /// <returns></returns>
        public IEnumerable<View_MoviePreview_Repository> GetPreview(string doubanID, Domain.Enum.PreviewType previewtype)
        {
            return db.Query<View_MoviePreview_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID).Where("[PreviewType] = @0", previewtype.ToInt_()));
        }

        /// <summary>
        /// 根据DouBanID获取导演
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MovieDirector_Repository> GetDirector(string doubanID)
        {
            return db.Query<View_MovieDirector_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }

        /// <summary>
        /// 根据DouBanID获取编剧
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MovieScreenwriter_Repository> GetScreenwriter(string doubanID)
        {
            return db.Query<View_MovieScreenwriter_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }

        /// <summary>
        /// 根据DouBanID获取演员
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MoviePerformer_Repository> GetPerformer(string doubanID)
        {
            return db.Query<View_MoviePerformer_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }
        #endregion

        

    }
}
