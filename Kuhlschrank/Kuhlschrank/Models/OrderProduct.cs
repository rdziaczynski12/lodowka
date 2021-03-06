﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class OrderProduct
    {
        [Key]
        public long id { set; get; }
        public double quantity { get; set; }

        [Required]
        public virtual Order order { get; set; }
        [Required]
        public virtual Product product { get; set; }
    }
}
