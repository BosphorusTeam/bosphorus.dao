using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Log
{
    public class ConventionApplier: AbstractConventionApplier
    {
        public ConventionApplier()
            : base("LOG")
        {
        }

        protected override void Apply(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<Dao.NHibernate.Extension.Convention.UpperCaseTableName.Convention>();
            conventionFinder.Add<Dao.NHibernate.Extension.Convention.UpperCaseColumnName.Convention>();
            conventionFinder.Add<Dao.NHibernate.Extension.Convention.UpperCaseString.Convention>();
            conventionFinder.Add(new Dao.NHibernate.Extension.Convention.TablePrefix.Convention("X"));
        }
    }
}
