using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace Bosphorus.Dao.Common.Common
{
    public class CustomActivator : IComponentActivator
    {
        private readonly IComponentActivator componentActivator;

        public CustomActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
        {
            var extraParameter = new {model, kernel, onCreation, onDestruction};
            componentActivator = kernel.Resolve<IComponentActivator>(extraParameter);
        }

        public object Create(CreationContext context, Burden burden)
        {
            object result = componentActivator.Create(context, burden);
            return result;
        }

        public void Destroy(object instance)
        {
            componentActivator.Destroy(instance);
        }
    }
}