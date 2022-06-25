using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class Add_Donor
    {
        [Required(ErrorMessage = "Please Enter The  Name !")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter The Cnic !")]
        [Display(Name = "Cnic:")]
        public string Cnic { get; set; }
        [Required(ErrorMessage = "Please Enter The ContactNo !")]
        [Display(Name = "ContactNo:")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter The Type !")]
        [Display(Name = "Type:")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please Enter The Address !")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
        
    }
}