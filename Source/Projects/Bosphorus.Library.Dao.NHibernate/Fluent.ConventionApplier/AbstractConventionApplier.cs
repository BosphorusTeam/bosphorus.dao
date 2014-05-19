using Bosphorus.Dao.NHibernate.Common;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Fluent.ConventionApplier
{
    public abstract class AbstractConventionApplier : IConventionApplier
    {
        private readonly string sessionAlias;

        protected AbstractConventionApplier()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractConventionApplier(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
        }

        public void Apply(string sessionAlias, IConventionFinder conventionFinder)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return;
            }

            Apply(conventionFinder);
        }

        protected abstract void Apply(IConventionFinder conventionFinder);
    }
}