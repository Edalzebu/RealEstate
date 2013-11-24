using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniDropbox.Web.Models.Properties.SellProperty
{
    public class PropertyProfileModel
    {
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string Price { get; set; }
        public string City { get; set; }
        public string Country { get; set;}
        public string Suburb { get; set; }
        public string LandArea { get; set; }
        public string ConstructionArea { get; set; }
        public string ImageUrl { get; set; }

    }
}