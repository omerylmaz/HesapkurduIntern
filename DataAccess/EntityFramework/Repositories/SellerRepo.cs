using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class SellerRepo:GenericRepository<Seller>, ISellerRepo
    {
        public SellerRepo(TrendkurduDbContext dbContext) : base(dbContext)
        {
        }
    }
}
