using DripOldDriver;
using DripOldDriver.Cache;
using DripOldDriver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuHaoQuNa.Business
{
    public class Config_BLL
    {
        private static volatile Config_BLL config_bll = null;
        private static Database db = null;
        private Config_BLL()
        {
            if (db == null)
                db = new Database("TuHaoQuNa");
        }

        public static Config_BLL Config
        {
            get
            {   
                if (config_bll == null)
                    config_bll = new Config_BLL();
                return config_bll;
            }
        }

        /// <summary>获取</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public T Get<T>(string key)
        {
            return MemoryCache.Cache.Get<T>(key, () => db.SingleOrDefault<T>(Sql.Builder.Select("[Value]").From("dbo.Config").Where("[Key]=@0", key)));
        }
    }
}
