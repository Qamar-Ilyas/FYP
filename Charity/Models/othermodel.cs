using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Charity.Models
{
    public class othermodel
    {
        [Required(ErrorMessage = "Please Enter The  Odid !")]
        [Display(Name = "Odid")]
        public string Odid { get; set; }

        [Required(ErrorMessage = "Please Enter The  Did !")]
        [Display(Name = "Did")]
        public string Did { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [Required(ErrorMessage = "Enter The Type !")]
        [Display(Name = "Type:")]
        public string Type { get; set; }
        //public Nullable<System.DateTime> Date { get; set; }
        [Required(ErrorMessage = "Enter The Amount !")]
        [Display(Name = "Amount:")]
        public string Amount { get; set; }
    }
}