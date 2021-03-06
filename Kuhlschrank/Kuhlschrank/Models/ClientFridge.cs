﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class ClientFridge
    {
        [Key]
        public long id { set; get; }
        [Required]
        public virtual Fridge fridge { get; set; }
        [Required]
        public virtual Client client { get; set; }
    }
}
