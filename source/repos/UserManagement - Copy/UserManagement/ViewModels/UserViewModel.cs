using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.ViewModels
{
    public class UserViewModel 
    {
       public string Id { get; set; }
       [Required(ErrorMessage="Duhet te vendosni username-in")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Duhet te vendosni passwordin-in")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Duhet te vendosni emrin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Duhet te vendosni email-in")]
        public string Email { get; set; }
    }
}