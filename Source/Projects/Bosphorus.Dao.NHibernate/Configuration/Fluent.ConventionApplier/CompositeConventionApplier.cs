using System.Collections.Generic;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier
{
    internal class CompositeConventionApplier : IConventionApplier
    {
        private readonly IList<IConventionApplier> items;

        public CompositeConventionApplier(IList<IConventionApplier> items)
        {
            this.items = items;
        }

        public void Apply(string sessionAlias, IConventionFinder conventionFinder)
        {
            foreach (IConventionApplier item in items)
            {
                item.Apply(sessionAlias, conventionFinder);
            }
        }
    }
}