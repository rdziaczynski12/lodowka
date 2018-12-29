using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Order
    {
        [Key]
        public long id { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }

        [Required]
        public virtual Client client { get; set; }
        [Required]
        public virtual Fridge fridge { get; set; }
        [Required]
        public virtual Supply supply { get; set; }
        public virtual ICollection<OrderProduct> products { get; set; }

    }
}
