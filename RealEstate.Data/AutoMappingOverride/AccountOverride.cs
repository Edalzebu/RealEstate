using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using RealEstate.Domain.Entities;

namespace RealEstate.Data.AutoMappingOverride
{
    internal class AccountOverride : IAutoMappingOverride<Account>
    {
        public void Override(AutoMapping<Account> mapping)
        {
            /* mapping.HasMany(x => x.Referrals)
                 .Inverse()
                 .Access.CamelCaseField(Prefix.Underscore);*/
        }
    }
}
