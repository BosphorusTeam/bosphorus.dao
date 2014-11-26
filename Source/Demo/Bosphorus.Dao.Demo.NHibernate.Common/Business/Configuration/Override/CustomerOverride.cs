using Bosphorus.Dao.Demo.Common.Business;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business.Configuration.Override
{
    public class CustomerOverride: IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.HasMany(x => x.Accounts).Cascade.AllDeleteOrphan().Inverse();
            mapping.References(x => x.PrimaryAccount);
            mapping.References(x => x.CustomerType).Cascade.None();
        }
    }
}
