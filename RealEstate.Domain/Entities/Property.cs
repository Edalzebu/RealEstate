using System;

namespace RealEstate.Domain.Entities
{
    public class Property : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual string LandArea { get; set; }
        public virtual string ConstructionArea { get; set; }
        public virtual double Price { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual long DueñoId { get; set; }
        public virtual string NombrePropiedad { get; set; }
        public virtual string PropertyDescription { get; set; }
        public virtual DateTime StartingDate { get; set; }
        public virtual bool Banned { get; set; }
    }
}
