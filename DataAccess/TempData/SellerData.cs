using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TempData
{
    public class SellerData
    {
        List<Seller> _sellers;
        public SellerData()
        {
            _sellers = new List<Seller> { new Seller { Id = 1, Name = "tecnokurdu", Rating = 10 }, new Seller { Id = 2, Name = "lipton", Rating=3 }, new Seller { Id = 3, Name = "everything", Rating=5 } };
        }
    }
}
