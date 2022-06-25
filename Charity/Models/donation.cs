using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class donation
    {
        [Required(ErrorMessage = "Please Da !")]
        [Display(Name = "Da:")]
        public int Da { get; set; }
        [Required(ErrorMessage = "Amount of Saqda !")]
        [Display(Name = "Amount of Saqda:")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Amounts of Zakat !")]
        [Display(Name = "Amounts of Zakat:")]
        public double Amounts { get; set; }

    }
}