using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuHaoQuNa.Domain.Entity;
using TuHaoQuNa.Domain.View;

namespace TuHaoQuNa.Business
{
    public class Download_BLL
    {

        private Database db;

        public Download_BLL(string connectionStringName = "TuHaoQuNa")
        {
            db = new Database(connectionStringName);
        }

        /// <summary>
        /// 插入下载地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(Download_Repository model)
        {
            return db.Add<int>(model);
        }

        /// <summary>
        /// 插入下载地址,插入前先判断这个地址是否已经存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveDownload(Download_Repository model)
        {
            int? movieID = GetDownloadIDByMagnet(model.Magnet);
            if (!movieID.HasValue)
                return Insert(model);
            else
                return movieID.Value;
        }

        /// <summary>
        /// 根据磁力地址获取ID
        /// </summary>
        /// <param name="magnet"></param>
        /// <returns></returns>
        public int? GetDownloadIDByMagnet(string magnet)
        {
            return db.ExecuteScalar<int?>(Sql.Builder.Select("ID").From("dbo.Download").Where("Magnet = @0", magnet));
        }

        /// <summary>
        /// 根据DouBanID获取下载地址
        /// </summary>
        /// <param name="doubanID"></param>
        /// <returns></returns>
        public IEnumerable<View_MovieDownload_Repository> GetDownload(string doubanID)
        {
            return db.Query<View_MovieDownload_Repository>(Sql.Builder.Where("[DouBanID] = @0", doubanID));
        }
    }
}
