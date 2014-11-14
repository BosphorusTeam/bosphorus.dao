using System.Collections.Generic;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class SessionLifeStyleManager : ILifestyleManager
    {
        private readonly IDictionary<LifestyleType, ILifestyleManager> map;
        private IKernel kernel;

        public SessionLifeStyleManager()
        {
            map = new Dictionary<LifestyleType, ILifestyleManager>();
            map.Add(LifestyleType.Singleton, new SingletonLifestyleManager());
            map.Add(LifestyleType.PerWebRequest, new ScopedLifestyleManager(new WebRequestScopeAccessor()));
            map.Add(LifestyleType.Thread, new ScopedLifestyleManager(new ThreadScopeAccessor()));
        }

        public void Init(IComponentActivator componentActivator, IKernel kernel, ComponentModel model)
        {
            this.kernel = kernel;
            foreach (var lifestyleManager in map.Values)
            {
                lifestyleManager.Init(componentActivator, kernel, model);
            }
        }

        public object Resolve(CreationContext context, IReleasePolicy releasePolicy)
        {
            ILifestyleManager lifeStyleManager = GetLifeStyleManager(kernel);
            object result = lifeStyleManager.Resolve(context, releasePolicy);
            return result;
        }

        public bool Release(object instance)
        {
            ILifestyleManager lifeStyleManager = GetLifeStyleManager(kernel);
            bool result = lifeStyleManager.Release(instance);
            return result;
        }

        private ILifestyleManager GetLifeStyleManager(IKernel kernel)
        {
            ISessionLifeStyleProvider sessionLifeStyleProvider = kernel.Resolve<ISessionLifeStyleProvider>();
            LifestyleType lifestyleType = sessionLifeStyleProvider.GetLifestyle();
            ILifestyleManager lifestyleManager = map[lifestyleType];
            return lifestyleManager;
        }

        public void Dispose()
        {
            foreach (var lifestyleManager in map.Values)
            {
                lifestyleManager.Dispose();
            }
        }
    }
}