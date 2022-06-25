using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Charity.Models
{
    public class organizatiomodel
    {
        [Required(ErrorMessage = "Please Enter The  OrganizationName !")]
        [Display(Name = "OrganizationName")]
        //[StringLength(maximumLength: 7, MinimumLength = 3, ErrorMessage = "Name Length Must Be Max 7 & Min 3")]
        public string OrganizationName { get; set; }
     
        [Required(ErrorMessage = "Enter The ContactNo !")]
        [Display(Name = "ContactNo:")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Enter The Type !")]
        [Display(Name = "Type:")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Enter The Address !")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
    }
}