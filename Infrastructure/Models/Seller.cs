using Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class Seller : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Range(0, 10.0)]
        public decimal Rating { get; set; }
    }
}