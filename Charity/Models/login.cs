using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class login
    {
        [Required(ErrorMessage = "Please Enter The Email Address !")]
        [Display(Name = "Email Id:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter The Password")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}