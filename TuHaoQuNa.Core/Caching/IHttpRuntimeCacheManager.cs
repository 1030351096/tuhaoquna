using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace TuHaoQuNa.Core.Caching
{
    public interface IHttpRuntimeCacheManager
    {
        /// <summary>
        /// 本地缓存获取
        /// </summary>
        /// <param name="name">key</param>
        /// <returns></returns>
        T Get<T>(string name);

        /// <summary>
        /// 本地缓存移除
        /// </summary>
        /// <param name="name">key</param>
        void Remove(string name);

        /// <summary>
        /// 本地缓存写入（默认缓存20min）
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        void Set(string name, object value);

        /// <summary>
        /// 本地缓存判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// 本地缓存写入（默认缓存20min）,依赖项
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        /// <param name="cacheDependency">依赖项</param>
        void Set(string name, object value, CacheDependency cacheDependency);

        /// <summary>
        /// 本地缓存写入
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        /// <param name="minutes">缓存分钟</param>
        void Set(string name, object value, int minutes);

        /// <summary>
        /// 本地缓存写入，包括分钟，是否绝对过期及缓存过期的回调
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="value">value</param>
        /// <param name="minutes"缓存分钟></param>
        /// <param name="isAbsoluteExpiration">是否绝对过期</param>
        /// <param name="onRemoveCallback">缓存过期回调</param>
        void Set(string name, object value, int minutes, bool isAbsoluteExpiration, CacheItemRemovedCallback onRemoveCallback);
    }
}
