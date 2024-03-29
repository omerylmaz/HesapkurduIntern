﻿using Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }

        [Range(0, 1000000)]
        public int Amount { get; set; }

        [Range (0,50000)]
        public decimal Price { get; set; }

        [Range(0,10.0)]
        public decimal Rating { get; set; }
    }
}
