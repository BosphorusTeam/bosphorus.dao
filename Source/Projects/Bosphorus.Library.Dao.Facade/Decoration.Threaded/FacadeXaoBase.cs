using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Facade.Facade.Base;
using Bosphorus.Library.Dao.Core.Base.Model;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public partial class FacadeXaoBase<TContainerScope>: FacadeBase<TContainerScope>
        where TContainerScope : FacadeBase<TContainerScope>
    {
    }

    public partial class FacadeXaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeBase<TContainerScope, TComponentProvider, TComponent>
        where TComponent : ThreadedDecoratorXao<TModel>
        where TContainerScope : FacadeBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        public static IXao<TModel> CallbackTo(ThreadedDecoratorXao<TModel>.ListReturnCallback callback)
        {
            return CallbackTo((object)callback);
        }

        public static IXao<TModel> CallbackTo(object callback)
        {
            InternalComponent.Callback = callback;
            return InternalComponent;
        }

        public static ThreadedListResult<TModel> GetAll()
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorXao<TModel>.ListReturnCallback callback = new ThreadedDecoratorXao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetAll();
            return threadedResult;
        }

        public static ThreadedListResult<TModel> GetByCriteria(params object[] criterions)
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorXao<TModel>.ListReturnCallback callback = new ThreadedDecoratorXao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByCriteria(criterions);
            return threadedResult;
        }
    }
}
