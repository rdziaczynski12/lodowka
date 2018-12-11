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
        public long id { get; set; }
        [Required(ErrorMessage = "Numer seryjny jest wymagany.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numer seryjny musi składać się z 10 znaków!")]
        public string serialNumber { get; set; }
        [Range(-50.0, 100.0, ErrorMessage = "Podana wartość temperatury jest błędna!")]
        public float temperature { get; set; }
        public bool activated { get; set; }

        public virtual ICollection<ClientFridge> clients { get; set; }

    }
}
