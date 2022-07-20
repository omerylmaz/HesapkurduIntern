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
        public void Add(T item)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                dbContext.Set<T>().Add(item);
                dbContext.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                return dbContext.Set<T>().AsNoTracking().ToList(); // Boşu boşuna veritabanını güncellememek için AsNoTracking metodu kullanılabilir.
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                return dbContext.Set<T>().Where(predicate).AsNoTracking();
            }
        }

        public T GetItemById(int id)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                return dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
        }

        public void Remove(T item)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                var entity = GetItemById(item.Id);
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public T RemoveItemById(int id)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                var entity = GetItemById(id);
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
                return entity;
            }
        }

        public void Update(T item)
        {
            using (TrendkurduDbContext dbContext = new TrendkurduDbContext())
            {
                dbContext.Set<T>().Update(item);
                dbContext.SaveChanges();
            }
        }
    }
}
