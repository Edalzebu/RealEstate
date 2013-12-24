using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.Domain.Entities
{
    public class PropertyBans : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual long PropertyId { get; set; }
        public virtual string BanReason { get; set; }
        public virtual string Administrator { get; set; }
        public virtual DateTime BanDate { get; set; }

    }
}
