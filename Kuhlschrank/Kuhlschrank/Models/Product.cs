using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Product
    {
        [Key]
        public long id { set; get; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string name { set; get; }
        [Required(ErrorMessage = "Kod jest wymagany")]
        public string code { set; get; }
        public string unit { get; set; }
        public string unitOne { get; set; }
        public string expirationDateOpen { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }

        [Required]
        public virtual Producer producer { get; set; }
        public virtual ICollection<FridgeProduct> fridges { get; set; }
        public virtual ICollection<OpenProduct> openProducts { get; set; }
        public virtual ICollection<HistoryProduct> historyProducts { get; set; }
        public virtual ICollection<RecipeProduct> recipes { get; set; }
        public virtual ICollection<OrderProduct> orders { get; set; }
    }
}
