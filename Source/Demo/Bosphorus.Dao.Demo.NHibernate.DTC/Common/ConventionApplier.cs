using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.Demo.NHibernate.DTC.Common
{
    public class ConventionApplier: IConventionApplier
    {
        public void Apply(string sessionAlias, IConventionFinder conventionFinder)
        {
            conventionFinder.Add(new Dao.NHibernate.Extension.Convention.TablePrefix.Convention("DTC"));
        }
    }
}
