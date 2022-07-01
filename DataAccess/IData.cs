using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public interface IData<T>
    {
        List<T> GetAll();
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate); //Ef için IQueryable mı gerekli olacak
        T GetItemById(int id);
        void Add(T item);
        void Remove(T item);
        T RemoveItemById(int id);
        void Update(T item);

    }
}
