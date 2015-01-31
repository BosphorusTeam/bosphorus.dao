using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class SingletonScopeAccessor : IScopeAccessor
    {
        private readonly ILifetimeScope lifetimeScope;

        public SingletonScopeAccessor()
        {
            lifetimeScope = new DefaultLifetimeScope();
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            return lifetimeScope;
        }

        public void Dispose()
        {
        }
    }
}
