using System;
using Bosphorus.Dao.Core.Session.Builder.Decoration.Lazy;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;

namespace Bosphorus.Dao.Core.Session.Builder
{
    public class MyActivator: DefaultComponentActivator
    {
        public MyActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction) :
            base(model, kernel, onCreation, onDestruction)
        {
        }

        protected override object InternalCreate(CreationContext context)
        {
            object result = base.InternalCreate(context);
            return result;
        }

        protected override void InternalDestroy(object instance)
        {
            base.InternalDestroy(instance);
        }
    }
}