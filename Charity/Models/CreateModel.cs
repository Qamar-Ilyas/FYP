using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class CreateModel
    {

        public string Uid { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Email { get; set; }

        public string Cnic { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Paasword { get; set; }
    }
}