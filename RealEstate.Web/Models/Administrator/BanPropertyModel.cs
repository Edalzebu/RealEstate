using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models.Administrator
{
    public class BanPropertyModel
    {
        public long id { get; set; }
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Display(Name = "Pais")]
        public string Country { get; set; }
        [Display(Name = "Colonia")]
        public string Suburb { get; set; }
        [Display(Name = "Dueño")]
        public string Owner { get; set; }
        [Display(Name = "Razon de la prohibicion")]
        [DataType(DataType.MultilineText)]
        public string BanReason { get; set; }
    }
}