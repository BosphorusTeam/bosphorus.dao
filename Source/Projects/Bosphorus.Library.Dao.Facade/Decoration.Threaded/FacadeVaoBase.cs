using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class FacadeVaoBase<TContainerScope> : FacadeXaoBase<TContainerScope>
        where TContainerScope : Bosphorus.Library.Dao.Facade.Facade.Base.FacadeBase<TContainerScope>
    {
    }

    public class FacadeVaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeXaoBase<TContainerScope, TComponentProvider, TComponent, TModel>
        where TComponent : ThreadedDecoratorVao<TModel>
        where TContainerScope : Bosphorus.Library.Dao.Facade.Facade.Base.FacadeBase<TContainerScope>
        where TComponentProvider : Bosphorus.Library.Dao.Facade.Facade.Base.IComponentProvider, new()
    {
    }
}
