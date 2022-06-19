using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
    }
}
