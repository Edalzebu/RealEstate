using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Web.Models.Administrator
{
    public class APropertiesListModel
    {
        [HiddenInput(DisplayValue = true)]
        public long id { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string City { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string Country { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string Suburb { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string Owner { get; set; }
        
    }
}