using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Supply
    {
        [Key]
        public long id { set; get; }
        public string name { set; get; }
        public int time { set; get; }
        public decimal price { set; get; }

        public virtual ICollection<Order> orders { get; set; }
    }
}
