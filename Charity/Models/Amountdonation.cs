using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class Amountdonation
    {
        public int ADonation { get; set; }
        public int Did { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get;set; }
        public string Type { get; set; }
        public int Amount { get; set; }
    }
}