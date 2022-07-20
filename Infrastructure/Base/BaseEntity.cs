﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Base
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
