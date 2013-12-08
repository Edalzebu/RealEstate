using System;
using System.Collections.Generic;
using RealEstate.Domain.Entities;

namespace RealEstate.Web.Models
{
    public class AccountProfileModel
    {
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string MemberSince { get; set; }
        public string PropertiesSold { get; set; }
        public string Contact { get; set; }
        public List<long> ListaProperties { get; set; } 
    }
}