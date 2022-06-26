using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "This field has to be filled")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }

        [Range(0, 1000000)]
        public int Amount { get; set; }

        [Range (0,50000)]
        public double Price { get; set; }

        [Range(0,10.0)]
        public double Rating { get; set; }
    }
}
