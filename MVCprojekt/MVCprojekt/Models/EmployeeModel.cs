using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class EmployeeModel
    {
        [Key]
        [Display(Name = "Identyfikator użytkownika")]
        [Range(100000, 999999, ErrorMessage = "Podaj prawidłową wartość.")]
        [Required(ErrorMessage = "Musisz podać Identyfikator użytkownika.")]
        public int EmployeeID { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz podać Imię.")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Musisz podać nazwisko.")]
        public string Surname { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Musisz podać Login.")]
        public string Login { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz podać Hasło.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Za krótkie hasło!")]
        public string Password { get; set; }

        public virtual PositionModel Position { get; set; }


        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}