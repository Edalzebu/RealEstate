using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniDropbox.Web.Models.Properties
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