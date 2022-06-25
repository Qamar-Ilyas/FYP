using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Charity.Models
{
    public class familymodel
    {
        [Required(ErrorMessage = "Please Enter The  Fid !")]
        [Display(Name = "Fid")]
        public string Fid { get; set; }
        [Required(ErrorMessage = "Please Enter The  Did !")]
        [Display(Name = "Did")]
        public string Did { get; set; }
        [Required(ErrorMessage = "Please Enter The  DAid !")]
        [Display(Name = "DAid")]
        public string DAid { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [Required(ErrorMessage = "Please Enter The  Type !")]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please Enter The  Amount !")]
        [Display(Name = "Amount")]
        public string Amount { get; set; }
    }
}