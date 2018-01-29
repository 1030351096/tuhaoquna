using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Domain.Entity;
using TuHaoQuNa.Domain.View;

namespace TuHaoQuNa.Business
{
    public class Player_BLL
    {

        private Database db;

        public Player_BLL(string connectionStringName = "TuHaoQuNa")
        {
            db = new Database(connectionStringName);
        }

        /// <summary>
        /// 插入播放地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Player_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入播放地址,插入前先判断这个地址是否已经存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePlayer(Player_Repository model)
        {
            int? movieID = GetPlayIDByVID(model.VID, model.Platform);
            if (!movieID.HasValue)
                return Insert(model);
            else
                return movieID.Value;
        }

        /// <summary>
        /// 根据播放地址获取ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public int? GetPlayIDByUrl(string url)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Player").Where("PlayerUrl = @0", url));
        }

        /// <summary>
        /// 根据VID获取ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public int? GetPlayIDByVID(string vid, string platform)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Player").Where("[VID] = @0 And [Platform] = @1", vid, platform));
        }

        /// <summary>
        /// 根据DouBanID获取播放地址
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MoviePlayer_Repository> GetPlayer(string doubanID)
        {
            return db.Query<View_MoviePlayer_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }

        /// <summary>
        /// 获取播放信息
        /// </summary>
        /// <param name="playGuid"></param>
        /// <returns></returns>
        public View_MoviePlayer_Repository SinglePlayer(string playGuid)
        {
            return db.SingleOrDefault<View_MoviePlayer_Repository>(Sql.Builder.Where("[PlayerGuid] = @0", playGuid));
        }

    }
}
