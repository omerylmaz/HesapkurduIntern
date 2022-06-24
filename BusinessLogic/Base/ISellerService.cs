using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface ISellerService
    {
        List<Seller> GetAllSellers();
        Seller GetSeller(int id);
        void AddSeller(Seller seller);
        void RemoveSeller(Seller seller);
        void RemoveSellerItemById(int id);
        void Update(Seller seller);
    }
}
