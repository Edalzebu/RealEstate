using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models
{
    public class AccountInputModel
    {
        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public string BirthDay { get; set; }

        [Required(ErrorMessage = "[Campo Necesario] Con este usuario podras ingresar al sistema")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "[Campo Necesario] Con este correo te podremos contactar.")]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress , ErrorMessage = "Debe ser un correo electronico valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Necesario")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo Necesario")]
        [Display(Name = "Confirma Contraseña")]
        public string ConfirmPassword { get; set; }

        
    }
}