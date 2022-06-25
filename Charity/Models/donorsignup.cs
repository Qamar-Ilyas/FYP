using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class donorsignup
    {
        public string Did { get; set; }


        [Required(ErrorMessage = "Please Enter The  Name !")]
        [Display(Name = "Name")]
        //[StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Name Length Must Be Max 7 & Min 3")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter The Email Address !")]
        [Display(Name = "Email Id:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter The Cnic !")]
        [Display(Name = "Cnic:")]
        public string Cnic { get; set; }
        [Required(ErrorMessage = "Enter The ContactNo !")]
        //[DataType(DataType.ContactNo, ErrorMessage = "Please Enter a valid ContactNo")]
        [Display(Name = "ContactNo:")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Enter The Address !")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
        public string Status { get; set; }
        [StringLength(8)]
        [Required(ErrorMessage = "Enter The Password")]
        public string Password { get; set; }
      
        public string Assign { get; set; }
    }
}