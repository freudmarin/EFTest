using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Models.AccountViewModel
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Ju lutem vendosni email-in ")]
        [EmailAddress(ErrorMessage = "Emaili nuk eshte ne formatin e duhur")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ju lutem vendosni emrin")]
        [Display(Name = "Emri")]
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ju lutem vendosni mbiemrin")]
        [Display(Name = "Mbiemri")]
        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }


        [Display(Name = "Username")]
        [Required(ErrorMessage = "Ju lutem vendosni useranme-in")]
        [MinLength(2), MaxLength(50)]
        public string Username { get; set; }


        [Required(ErrorMessage = "Ju lutem vendosni fjalekalimin")]
        [StringLength(100, ErrorMessage = "Fjalekalimi duhet te kete minimalisht 2 karaktere.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ju lutem rivendosni fjalekalimin")]
        [StringLength(100, ErrorMessage = "Fjalekalimi duhet te kete minimalisht 2 karaktere.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Konfirmoni fjalekalimin")]
        [Compare("Password",ErrorMessage ="nuk keni vendosur te njejtin fjalekalim")]
        public string ConfirmPassword { get; set; }
    }
}
