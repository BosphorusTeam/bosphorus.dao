using System;
using System.Diagnostics;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Merge
{
    public class GenericMerger
    {
        private readonly IWindsorContainer container;
        private readonly MethodInfo genericMethod;

        public GenericMerger(IWindsorContainer container)
        {
            this.container = container;
            this.genericMethod = Reflection<GenericMerger>.GetMethodInfo(merger => merger.Merge<object>(null, null)).GetGenericMethodDefinition();
        }

        public TModel Merge<TModel>(TModel sourceModel, TModel overrideModel)
        {
            IMerger<TModel> merger = container.Resolve<IMerger<TModel>>();
            TModel result = merger.Merge(sourceModel, overrideModel);
            return result;
        }

        [DebuggerStepThrough]
        public object Merge(Type modelType, object sourceModel, object overrideModel)
        {
            MethodInfo methodInfo = genericMethod.MakeGenericMethod(modelType);
            object target = methodInfo.Invoke(this, new[] { sourceModel, overrideModel });
            return target;
        }
    }

}
