using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Business
{
    public class ConventionApplier: AbstractConventionApplier
    {
        protected override void Apply(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<Dao.NHibernate.Extension.Convention.UpperCaseTableName.Convention>();
            conventionFinder.Add<Dao.NHibernate.Extension.Convention.UpperCaseColumnName.Convention>();
            //conventionFinder.Add<NHibernate.Extension.Convention.UpperCaseString.Convention>();
            conventionFinder.Add(new Dao.NHibernate.Extension.Convention.TablePrefix.Convention("X"));
            conventionFinder.Add(new Dao.NHibernate.Extension.Convention.Eumeration.Convention());
            conventionFinder.Add(DynamicUpdate.AlwaysTrue());
        }
    }
}
