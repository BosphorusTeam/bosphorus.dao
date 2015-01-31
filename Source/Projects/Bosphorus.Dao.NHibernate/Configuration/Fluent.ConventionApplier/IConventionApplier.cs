using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier
{
    public interface IConventionApplier
    {
        void Apply(string sessionAlias, IConventionFinder conventionFinder);
    }
}
