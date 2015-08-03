using Bosphorus.Dao.Core.Common;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier
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