using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;

namespace RealEstate.Web.Models
{
    public class SellPropertyModel
    {
        //Propiedad Sola
        public FileStream Imagen { get; set; }

        [Required(ErrorMessage = "Area del terreno es necesaria")]
        [Display(Name = "Area del terreno")]
      
        public string LandArea { get; set; }

        [Required(ErrorMessage = "Area de construccion es necesaria")]
        [Display(Name = "Area de Construccion")]
        public string ConstructionArea { get; set; }

        [Required(ErrorMessage = "El precio de venta es necesario")]
        [Display(Name = "Precio")]
        public double Price { get; set; }

        [Required(ErrorMessage = "La colonia donde esta localizado")]
        [Display(Name = "Colonia")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Ciudad o pueblo es necesario")]
        [Display(Name = "Ciudad / Pueblo")]
        public string City { get; set; }

        [Required(ErrorMessage = "El pais es necesario")]
        [Display(Name = "Pais")]
        public string Country { get; set; }
        [Display(Name = "Nombre Propiedad (Optional)")]
        public string PropertyName { get; set; }
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Inicio la venta")]
        public DateTime StartingDate { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string PropertyDescription { get; set; }


        //Casa
        
        


    }
}