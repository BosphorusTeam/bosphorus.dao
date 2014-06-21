using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Demo.DTC.Common
{
    public class ConventionApplier: IConventionApplier
    {
        public void Apply(string sessionAlias, IConventionFinder conventionFinder)
        {
            conventionFinder.Add(new Extension.Convention.TablePrefix.Convention("DTC"));
        }
    }
}
