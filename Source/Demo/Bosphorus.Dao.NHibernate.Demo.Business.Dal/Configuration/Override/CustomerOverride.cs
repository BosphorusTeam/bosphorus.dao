using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration.Override
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
