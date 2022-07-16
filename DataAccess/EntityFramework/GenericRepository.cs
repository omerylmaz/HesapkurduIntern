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
        private readonly TrendkurduDbContext _dbContext;
        public GenericRepository(TrendkurduDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList(); // Boşu boşuna veritabanını güncellememek için AsNoTracking metodu kullanılabilir.
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public T GetItemById(int id)
        {
            return _dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T item)
        {
            var entity = GetItemById(item.Id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T RemoveItemById(int id)
        {
            var entity = GetItemById(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return entity; 
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            _dbContext.SaveChanges();
        }
    }
}
