using Microsoft.Extensions.Caching.Memory;
using Models.Base;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface ICacheRepo<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll(string key);
        List<T> AddAll(string key, List<T> items, int expireInSeconds, CacheTypes cacheType);
        T Add(T item, int expireInSeconds, CacheTypes cacheTypes);
        void Remove(string key);
        //T Update(T item);
    }
}
