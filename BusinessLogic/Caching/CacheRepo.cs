using BusinessLogic.Base;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BusinessLogic.Caching
{ // Burada override mı edilmesi gerekirdi
    public class CacheRepo<T> : ICacheRepo<T> where T : BaseEntity // bunu yaparak generic yapıda proplara erişebiliyorum
    {
        IMemoryCache _memoryCache;
        IDistributedCache _distributedCache;
        MemoryCacheEntryOptions _memoryOptions;
        DistributedCacheEntryOptions _distributedOptions;
        string entityName;
        public CacheRepo(IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            entityName = typeof(T).Name;
            _memoryOptions = new MemoryCacheEntryOptions();
            _distributedOptions = new DistributedCacheEntryOptions();
            _memoryOptions.AbsoluteExpiration = DateTime.Now.AddSeconds(30);
            _memoryOptions.SlidingExpiration = TimeSpan.FromSeconds(5);
            _distributedOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
            _distributedOptions.SlidingExpiration = TimeSpan.FromMinutes(1);
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        public T Add(T item)
        {
            _memoryCache.Set(item.Id, item, _memoryOptions);

            string data = JsonConvert.SerializeObject(item);
            _distributedCache.SetString($"{entityName}:{item.Id}", data);

            return item;
        }
        public List<T> AddAll(string key, List<T> items)
        {
            _memoryCache.Set(key, items, _memoryOptions);
            string data = JsonConvert.SerializeObject(items);
            _distributedCache.SetString($"{entityName}:{key}", data);
            return items;
        }

        public T Get(int id)
        {

            var memoryItem = _memoryCache.Get(id);
            if (memoryItem == null)
            {
                var distributedItem = _distributedCache.GetString($"{entityName}:{id}");
                if (distributedItem != null)
                {
                    var data = JsonConvert.DeserializeObject<T>(distributedItem);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (T)_memoryCache.Get(id);

            }
        }

        public List<T> GetAll(string key)
        {
            bool isCached = _memoryCache.TryGetValue(key, out List<T> cachedData);
            if (isCached)
            {
                return cachedData;
            }
            else
            {
                string cachedItems = _distributedCache.GetString($"{entityName}:{key}");

                if (cachedItems == null)
                {
                    return null;
                }
                List<T> items = JsonConvert.DeserializeObject<List<T>>(cachedItems);
                return items;
            }
        }

        public void Remove(string key)
        {

            _memoryCache.Remove(int.Parse(key));

            _distributedCache.Remove($"{entityName}:{key}");
        }

        public bool TryGetValue(object key, out object value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public T Update(T item)
        {
            bool isCached = TryGetValue(item.Id, out object value);
            if (isCached)
            {
                value = item;
                Remove(item.Id.ToString());
                Add(item);
            }

            var data = _distributedCache.GetString($"{entityName}:{item.Id}");
            if (data != null)
            {
                _distributedCache.Remove($"{entityName}:{item.Id}");
                _distributedCache.SetString($"{entityName}:{item.Id}", data);
                return item;
            }
            return null;

        }
    }
}
