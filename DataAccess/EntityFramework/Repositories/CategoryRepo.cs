using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class CategorytRepo : GenericRepository<Category>, ICategoryRepo
    {
        public CategorytRepo(TrendkurduDbContext dbContext) : base(dbContext)
        {

        }
    }
}
