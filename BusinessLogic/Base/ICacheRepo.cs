using Microsoft.Extensions.Caching.Memory;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface ICacheRepo<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll(string key);
        List<T> AddAll(string key, List<T> items);
        T Add(T item);
        void Remove(string key);
        T Update(T item);
    }
}
