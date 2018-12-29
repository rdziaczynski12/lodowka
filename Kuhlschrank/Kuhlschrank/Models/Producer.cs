using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Producer
    {
        [Key]
        public long id { set; get; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string name { set; get; }
        [Required(ErrorMessage = "NIP jest wymagany")]
        public string NIP { set; get; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        public string code { get; set; }
        [Required(ErrorMessage = "Miejscowość jest wymagana")]
        public string place { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany")]
        public string address { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
