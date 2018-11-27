using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class ClientFridge
    {
        [Key]
        public int Id { set; get; }
        public virtual Fridge Fridge { get; set; }
        public virtual Client Client { get; set; }
    }
}
