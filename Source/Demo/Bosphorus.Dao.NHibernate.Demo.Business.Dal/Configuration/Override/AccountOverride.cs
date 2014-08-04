using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration.Override
{
    public class AccountOverride: IAutoMappingOverride<Account>
    {
        public void Override(AutoMapping<Account> mapping)
        {
            mapping.References(x => x.Customer).Cascade.None().Not.Nullable();
        }
    }
}
