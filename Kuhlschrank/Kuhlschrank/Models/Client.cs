using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Client
    {
        [Key]
        public long id { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string lastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        public string code { get; set; }
        [Required(ErrorMessage = "Miejscowość jest wymagana")]
        public string place { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany")]
        public string address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "E-mail jest wymagany")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Login jest wymagany")]
        public string login { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Hasło musi składać się z min 8 znaków")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public virtual ICollection<ClientFridge> fridges { get; set; }
    }
}
