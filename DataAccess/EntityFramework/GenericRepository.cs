using Microsoft.EntityFrameworkCore;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly TrendkurduDbContext dbContext;
        public GenericRepository(TrendkurduDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(T item)
        {
                dbContext.Set<T>().Add(item);
                dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
                return dbContext.Set<T>().AsNoTracking().ToList(); // Boşu boşuna veritabanını güncellememek için AsNoTracking metodu kullanılabilir.
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
                return dbContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public T GetItemById(int id)
        {
                return dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T item)
        {
                var entity = GetItemById(item.Id);
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
        }

        public T RemoveItemById(int id)
        {
                var entity = GetItemById(id);
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
                return entity;
        }

        public void Update(T item)
        {
                dbContext.Set<T>().Update(item);
                dbContext.SaveChanges();
        }
    }
}
