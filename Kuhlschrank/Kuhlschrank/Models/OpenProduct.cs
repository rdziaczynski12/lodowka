using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class OpenProduct
    {
        [Key]
        public long id { set; get; }
        public double quantity { get; set; }
        public DateTime expirationDate { get; set; }
        public DateTime OpenDate { get; set; }
        public bool returned { get; set; }

        [Required]
        public virtual Fridge fridge { get; set; }
        [Required]
        public virtual Product product { get; set; }
    }
}
