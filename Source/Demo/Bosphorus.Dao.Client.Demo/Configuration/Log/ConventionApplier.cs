using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.Client.Demo.Configuration.Log
{
    public class ConventionApplier: AbstractConventionApplier
    {
        public ConventionApplier()
            : base("LOG")
        {
        }

        protected override void Apply(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<NHibernate.Extension.Convention.UpperCaseTableName.Convention>();
            conventionFinder.Add<NHibernate.Extension.Convention.UpperCaseColumnName.Convention>();
            conventionFinder.Add<NHibernate.Extension.Convention.UpperCaseString.Convention>();
            conventionFinder.Add(new NHibernate.Extension.Convention.TablePrefix.Convention("X"));
        }
    }
}
