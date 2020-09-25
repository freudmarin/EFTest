using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Models.AccountViewModel
{
   
        public class LoginViewModel
        {
            [Display(Name = "UserName")]
            [Required(ErrorMessage = "Ju lutem vendosni username-in")]
            public string Username { get; set; }
        [Display(Name = "Fjalekalim")]
            [Required(ErrorMessage = "Ju lutem vendosni password-in")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }

