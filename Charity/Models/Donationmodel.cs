using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class Donationmodel
    {
        [Required(ErrorMessage = "Please Enter The  Name !")]
        [Display(Name = "Name")]
        //[StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Name Length Must Be Max 7 & Min 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter The Cnic !")]
        [Display(Name = "Cnic:")]
        public string Cnic { get; set; }
        [Required(ErrorMessage = "Enter The Type !")]
        [Display(Name = "Type:")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Enter The Amount !")]
        [Display(Name = "Amount:")]
        public string Amount { get; set; }
    }
}