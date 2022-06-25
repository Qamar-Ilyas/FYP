using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Charity.Models
{
    public class DonorAddDonee
    {
        [Required(ErrorMessage = "Please Enter The  DAid !")]
        [Display(Name = "DAid")]
        public string DAid { get; set; }
        [Required(ErrorMessage = "Please Enter The  Name !")]
        [Display(Name = "Name")]
        //[StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Name Length Must Be Max 7 & Min 3")]
        public string Name { get; set; }
     
        [Required(ErrorMessage = "Enter The Cnic !")]
        [Display(Name = "Cnic:")]
        public string Cnic { get; set; }
      
        [Required(ErrorMessage = "Enter The Address !")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter The Need !")]
        [Display(Name = "Need:")]
        public string Need { get; set; }
        [Required(ErrorMessage = "Please Enter The  Did !")]
        [Display(Name = "Did")]
        public string Did { get; set; }

    }
}