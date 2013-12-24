using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.Domain.Entities
{
    public class UserBans : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual long UserId { get; set; }
        public virtual string Administrator { get; set; }
        public virtual DateTime BanDateTime { get; set; }
        public virtual string BanReason { get; set; }
    }
}
