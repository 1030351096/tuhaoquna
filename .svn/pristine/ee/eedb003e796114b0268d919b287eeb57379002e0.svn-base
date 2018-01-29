using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuHaoQuNa.Core.Caching
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {

        public static T Get<T>(this IMemoryCacheManager cacheManager, string key, Func<T> acquire, int cacheTime = 60)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }

        public static T Get<T>(this IHttpRuntimeCacheManager cacheManager, string key, Func<T> acquire, int cacheTime = 60)
        {
            if (cacheManager.Get<T>(key)!=null)
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }
    }
}
