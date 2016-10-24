using Bosphorus.Dao.Demo.Common.Business;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Bosphorus.Dao.Demo.Configuration.NHibernatee.Mapping
{
    public class AccountOverride: IAutoMappingOverride<Account>
    {
        public void Override(AutoMapping<Account> mapping)
        {
            mapping.References(x => x.Customer).Cascade.None().Not.Nullable();
        }
    }
}
