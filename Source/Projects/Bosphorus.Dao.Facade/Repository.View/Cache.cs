using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Facade.Decoration.Base;
using Bosphorus.Library.Dao.Facade.Facade.Base;
using Bosphorus.Library.Dao.Facade.Decoration.Cache;
using Bosphorus.Library.Dao.Core.Model.Vao;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class View
        {
            public partial class Cache : FacadeDaoBase<Cache>
            {
            }

            public partial class Cache<TModel> : FacadeXaoBase<Cache, Cache<TModel>.ComponentProvider, IVaoCacheDecorator<TModel>, TModel>
            {
                public class ComponentProvider : IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        IVao<TModel> dao = Live<TModel>.InternalComponent;
                        IVaoCacheDecorator<TModel> decorator = (IVaoCacheDecorator<TModel>)Container.Resolve(typeof(IVaoCacheDecorator<TModel>));
                        decorator.Decorated = dao;

                        return (TComponent)(object)decorator;
                    }
                }

                public static void Clear()
                {
                    InternalComponent.ClearCache();
                }

                public static void Load()
                {
                    InternalComponent.LoadCache();
                }
            }
        }
    }
}
