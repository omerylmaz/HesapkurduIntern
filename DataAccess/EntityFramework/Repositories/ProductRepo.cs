using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class ProductRepo : GenericRepository<Product>, IProductRepo
    {
        public ProductRepo()
        {
        }
    }
}
