using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class TransientScopeAccessor : IScopeAccessor
    {
        public ILifetimeScope GetScope(CreationContext context)
        {
            return new DefaultLifetimeScope();
        }

        public void Dispose()
        {
        }
    }
}
