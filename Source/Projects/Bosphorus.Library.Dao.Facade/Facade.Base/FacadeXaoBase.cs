using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Base.Model;
using Bosphorus.Library.Dao.Facade.Facade.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public partial class FacadeXaoBase<TContainerScope>: FacadeBase<TContainerScope>
        where TContainerScope : FacadeXaoBase<TContainerScope>
    {
    }

    public partial class FacadeXaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeBase<TContainerScope, TComponentProvider, TComponent>
        where TComponent : IXao<TModel>
        where TContainerScope : FacadeBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        public static IList<TModel> GetAll()
        {
            return InternalComponent.GetAll();
        }

        public static IList<TModel> GetByCriteria(params object[] criterias)
        {
            return InternalComponent.GetByCriteria(criterias);
        }
    }
}
