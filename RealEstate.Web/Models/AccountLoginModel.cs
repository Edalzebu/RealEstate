namespace RealEstate.Web.Models
{
    public class AccountLoginModel
    {
        public string Password { get; set; }

        public string Email { get; set; }


        public bool RememberMe { get; set; }
    }
}