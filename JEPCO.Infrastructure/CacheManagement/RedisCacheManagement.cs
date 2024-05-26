using JEPCO.Application.Interfaces.CacheManagement;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JEPCO.Infrastructure.CacheManagement
{
    public class RedisCacheManagement : ICacheManagement
    {
        private IDatabase cacheDb;
        public RedisCacheManagement()
        {
            var redis = ConnectionMultiplexer.Connect("redisPort");
            cacheDb = redis.GetDatabase();
        }
        /// <summary>
        /// Get Data using key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetData<T>(string cacheKey)
        {
            var value = cacheDb.StringGet(cacheKey);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        /// <summary>
        /// Set Data with Value and Expiration Time of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        public bool SetData<T>(string cacheKey, T value, DateTimeOffset expirationTime)
        {
            var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return cacheDb.StringSet(cacheKey, JsonSerializer.Serialize<T>(value), expirtyTime);
        }

        /// <summary>
        /// Remove Data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object RemoveData(string key)
        {
            var isExist = cacheDb.KeyExists(key);
            if (!isExist)
            {
                return cacheDb.KeyDelete(key);
            }
            return false;
        }

    }
}
