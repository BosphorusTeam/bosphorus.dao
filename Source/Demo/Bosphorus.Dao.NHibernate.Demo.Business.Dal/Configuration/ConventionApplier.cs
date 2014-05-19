using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration
{
    public class ConventionApplier: AbstractConventionApplier
    {
        protected override void Apply(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<Extension.Convention.UpperCaseTableName.Convention>();
            conventionFinder.Add<Extension.Convention.UpperCaseColumnName.Convention>();
            conventionFinder.Add<Extension.Convention.UpperCaseString.Convention>();
        }
    }
}
