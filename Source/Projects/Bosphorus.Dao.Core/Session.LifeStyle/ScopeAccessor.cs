using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Bosphorus.Container.Castle.Extra;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class ScopeAccessor: IScopeAccessor
    {
        private readonly ConcurrentDictionary<CreationContext, IScopeAccessor> cache;

        public ScopeAccessor()
        {
            IEqualityComparer<CreationContext> equalityComparer = new Temp();
            cache = new ConcurrentDictionary<CreationContext, IScopeAccessor>(equalityComparer);
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            IScopeAccessor scopeAccessor = cache.GetOrAdd(context, BuildScopeAccessor);
            ILifetimeScope lifetimeScope = scopeAccessor.GetScope(context);

            return lifetimeScope;
        }

        private IScopeAccessor BuildScopeAccessor(CreationContext context)
        {
            var sessionLifeStyleProvider = ServiceRegistry.Get<ISessionLifeStyleProvider>();

            Type sessionType = context.RequestedType;
            string sessionAlias = (string) context.AdditionalArguments["SessionAlias"];
            LifestyleType lifestyleType = sessionLifeStyleProvider.GetLifestyle(sessionType, sessionAlias);

            if (lifestyleType == LifestyleType.Singleton)
            {
                return new SingletonScopeAccessor();
            }

            if (lifestyleType == LifestyleType.PerWebRequest)
            {
                return new WebRequestScopeAccessor();
            }

            if (lifestyleType == LifestyleType.Thread)
            {
                return new ThreadScopeAccessor();
            }

            if (lifestyleType == LifestyleType.Transient)
            {
                return new TransientScopeAccessor();
            }

            return null;
        }

        public void Dispose()
        {
        }
    }

    public class Temp : IEqualityComparer<CreationContext>
    {
        public bool Equals(CreationContext x, CreationContext y)
        {
            bool sessionAliasEquals = x.AdditionalArguments["SessionAlias"] == y.AdditionalArguments["SessionAlias"];
            return sessionAliasEquals;
        }

        public int GetHashCode(CreationContext obj)
        {
            var hashCode = obj.AdditionalArguments["SessionAlias"].GetHashCode();
            return hashCode;
        }
    }
}
