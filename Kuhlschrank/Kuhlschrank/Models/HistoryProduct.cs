using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class HistoryProduct
    {
        [Key]
        public long id { set; get; }
        public DateTime date { get; set; }

        [Required]
        public virtual Client client { get; set; }
        [Required]
        public virtual Product product { get; set; }
    }
}
