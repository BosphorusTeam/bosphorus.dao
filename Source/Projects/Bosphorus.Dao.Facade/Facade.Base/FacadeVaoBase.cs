using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Vao;
using Bosphorus.Library.Dao.Facade.Facade.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public partial class FacadeVaoBase<TContainerScope> : FacadeXaoBase<TContainerScope> where
        TContainerScope : FacadeVaoBase<TContainerScope>
    {
    }

    public partial class FacadeVaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeXaoBase<TContainerScope, TComponentProvider, TComponent, TModel>
        where TContainerScope : FacadeVaoBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
        where TComponent: IVao<TModel>
    {
    }
}
