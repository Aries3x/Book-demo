using Microsoft.Extensions.Caching.Memory;
using System;

namespace BaseHelper.CacheHelper
{
    public class CoreMemoryCache
    {
        /// <summary>
        /// 注入实例
        /// </summary>
        IMemoryCache _cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache"></param>
        public CoreMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 获取缓存 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            else
            {

                #region 另一种判断方式
                /*
                _cache.TryGetValue(key, out ReturnValue)检索缓存输出Bool;
                用这个也可以直接把 out 输出就行
                */
                #endregion
                return _cache.Get(key);


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timespan"></param>
        /// <returns></returns>
        public bool Add(string key, object value, int timespan = 60)
        {
            if (string.IsNullOrEmpty(key))
            {
                #region ArgumentNullException说明
                /*
                 * 如果不想返回异常信息的话也可以返回 自己定义的
                 * 当参数为空时放生的异常
                 * 和 ArgumentException 作用相同
                 */
                #endregion
                // throw new ArgumentNullException(key);
            }
            else
            {
                MemoryCacheEntryOptions cacheExpirationOptions = new MemoryCacheEntryOptions();
                cacheExpirationOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(timespan);
                cacheExpirationOptions.Priority = CacheItemPriority.Normal;
                //cacheExpirationOptions.RegisterPostEvictionCallback(IDGCacheItemChangedHandler, this);
                //添加
                //类似 System.Web.HttpRuntime.Cache[key] 
                _cache.Set(key, value, cacheExpirationOptions);
            }
            //如果添加成功则验证是否存在返回True 或false
            return Exists(key);
        }

        private void IDGCacheItemChangedHandler(object key, object value, EvictionReason reason, object state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 存在创建不存在获取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrCreate(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            { }
            else
            {
                // public static TItem GetOrCreate<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, TItem> factory);
                _cache.GetOrCreate(key, ENTRY => { return value; });
            }
            //如果添加成功则验证是否存在
            return Exists(key);
        }

        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// 修改时 MemoryCache 没有提供相对相应的方法，先删除后添加
        public bool Modify(string key, object value)
        {
            bool ReturnBool = false;
            if (string.IsNullOrEmpty(key))
            { }
            else
            {
                if (Exists(key))
                {
                    //删除
                    if (!Remove(key))
                    {
                        ReturnBool = Add(key, value);
                    }
                }

            }
            return ReturnBool;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            else
            {
                //删除
                _cache.Remove(key);

                //如果删除成功则验证是否存在返回bool
                return !Exists(key);
            }
        }

        /// <summary>
        /// 验证缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            object ReturnValue;
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            else
            {
                return _cache.TryGetValue(key, out ReturnValue);
            }
        }

        /// <summary>
        /// 回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        /// <param name="state"></param>
        public void AddCallback(object key, object value, EvictionReason reason, object state)
        {
            _cache.Set("CallbackMsg", reason);
        }
    }
}
