using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public double Temperature { get; set; }
        public bool Activated { get; set; }

        public virtual ICollection<ClientFridge> Clients { get; set; }

    }
}
