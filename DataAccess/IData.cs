using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IData<T>
    {
        List<T> GetAll();
        T GetItemById(int id);
        void Add(T item);
        void Remove(T item);
        void RemoveItemById(int id);
        void Update(T item);

    }
}
