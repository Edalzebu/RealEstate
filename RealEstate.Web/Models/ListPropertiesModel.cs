using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models
{
    public class ListPropertiesModel
    {
        public long Id { get; set; }
        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }
        [DataType(DataType.Currency)]
        public double Precio { get; set; }

        public string Nombre { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        [Display(Name = "Vendedor")]
        public string Owner { get; set; }
        [Display(Name = "Comienza la venta")]
        public DateTime StartingDate { get; set; }

    }
}