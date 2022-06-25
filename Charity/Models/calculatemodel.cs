using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Charity.Models
{
    public class calculatemodel
    {
        [Required(ErrorMessage = "Please GoldValue !")]
        [Display(Name = "GoldValue:")]
        public int GoldValue { get; set; }
        [Required(ErrorMessage = "Please SilverValue !")]
        [Display(Name = "SilverValue:")]
        public int SilverValue { get; set; }
        [Required(ErrorMessage = "CashHand !")]
        [Display(Name = "CashHand:")]
        public int CashHand { get; set; }
        [Required(ErrorMessage = "Please BussinessAccount !")]
        [Display(Name = "BussinessAccount:")]
        public int BussinessAccounts { get; set; }
        [Required(ErrorMessage = "Please others !")]
        [Display(Name = "others:")]
        public int Others { get; set; }
        [Required(ErrorMessage = "YourZakat !")]
        [Display(Name = "YourZakat:")]
        public double YourZakat { get; set; }
    }
}