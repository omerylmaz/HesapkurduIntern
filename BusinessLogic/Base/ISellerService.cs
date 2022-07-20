using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface ISellerService
    {
        List<Seller> GetAllSellers();
        public IEnumerable<Seller> GetSellersByRating(decimal rating);
        Seller GetSellerById(int id);
        void AddSeller(Seller seller);
        void RemoveSeller(Seller seller);
        Seller RemoveSellerById(int id);
        void Update(Seller seller);
    }
}
