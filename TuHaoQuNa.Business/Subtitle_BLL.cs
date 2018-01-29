using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Domain.Entity;
using TuHaoQuNa.Domain.View;

namespace TuHaoQuNa.Business
{
    public class Subtitle_BLL
    {
        private Database db;

        public Subtitle_BLL(string connectionStringName = "TuHaoQuNa")
        {
            db = new Database(connectionStringName);
        }

        /// <summary>
        /// 插入字幕
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Subtitle_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入字幕,插入前先判断这个地址是否已经存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveSubtitle(Subtitle_Repository model)
        {
            int? movieID = GetSubtitleIDByUrl(model.Download);
            if (!movieID.HasValue)
                return Insert(model);
            else
                return movieID.Value;
        }

        /// <summary>
        /// 根据字幕地址获取ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public int? GetSubtitleIDByUrl(string url)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Subtitle").Where("Download = @0", url));
        }

        /// <summary>
        /// 根据DouBanID获取字幕
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MovieSubtitle_Repository> GetSubtitle(string doubanID)
        {
            return db.Query<View_MovieSubtitle_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }
    }
}
