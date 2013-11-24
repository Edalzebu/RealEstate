using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models
{
    public class SellHouseModel
    {
        [Display(Name = "Habitaciones")]
        public long Bedrooms { get; set; }

        [Display(Name = "Tiene piscina?")]
        public bool Pool { get; set; }

        [Display(Name = "Tiene garage?")]
        public bool Garage { get; set; }

        [Display(Name = "Capacidad garage (Autos)")]
        public long CarsSpace { get; set; }

        [Display(Name = "Salas")]
        public long LivingRooms { get; set; }

        [Display(Name = "Numero de pisos")]
        public long NumberofFloors { get; set; }
    }
}