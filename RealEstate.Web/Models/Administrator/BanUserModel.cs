using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Web.Models.Administrator
{
    public class BanUserModel
    {
        [HiddenInput(DisplayValue = true)]
        public long id { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string FirstName { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string LastName { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string Email { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string UserName { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string MemberSince { get; set; }
        
        public string BanReason { get; set; }

    }
}