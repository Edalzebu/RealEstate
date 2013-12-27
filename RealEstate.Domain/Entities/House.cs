using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.Domain.Entities
{
    public class House : Property
    {
        public virtual long PropertyId { get; set; }
        public virtual int Floors { get; set; }
        public virtual bool Pool { get; set; }
        public virtual int Bedrooms { get; set; }
        public virtual int GarageFor { get; set; }
        public virtual int LivingRooms { get; set; }
        public virtual int Kitchens { get; set; }
    }
}
