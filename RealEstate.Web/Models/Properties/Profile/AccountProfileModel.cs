using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniDropbox.Domain.Entities;

namespace MiniDropbox.Web.Models.Properties.Profile
{
    public class AccountProfileModel
    {
        public string ImageUrl { get; set; }
        public string MemberSince { get; set; }
        public string PropertiesSold { get; set; }
        public string Contact { get; set; }
        public List<Property> ListaProperties { get; set; } 
    }
}