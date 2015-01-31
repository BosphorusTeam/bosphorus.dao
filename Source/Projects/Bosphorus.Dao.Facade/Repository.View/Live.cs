using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Facade.Facade.Base;
using Bosphorus.Library.Dao.Core.Model.Vao;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class View
        {
            public partial class Live: FacadeVaoBase<Live>
            {
            }

            public partial class Live<TModel> : FacadeVaoBase<Live, Live<TModel>.ComponentProvider, IVao<TModel>, TModel>
            {
                public class ComponentProvider : IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        return (TComponent) Container.Resolve(typeof(TComponent));
                    }
                }
            }
        }
    }
}
