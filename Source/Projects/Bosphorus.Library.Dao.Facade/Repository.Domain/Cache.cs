using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Facade.Facade.Base;
using Bosphorus.Library.Dao.Facade.Decoration.Cache;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class Domain
        {
            public partial class Cache : FacadeDaoBase<Cache>
            {
            }

            public partial class Cache<TModel> : FacadeXaoBase<Cache, Cache<TModel>.ComponentProvider, IDaoCacheDecorator<TModel>, TModel>
            {
                public class ComponentProvider : IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        IDao<TModel> dao = Live<TModel>.InternalComponent;
                        IDaoCacheDecorator<TModel> decorator = (IDaoCacheDecorator<TModel>)Container.Resolve(typeof(IDaoCacheDecorator<TModel>));
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

                public static TModel LoadById(object id)
                {
                    return InternalComponent.LoadById(id);
                }

                public static TModel LoadById<TId>(TId id)
                {
                    return InternalComponent.LoadById<TId>(id);
                }
            }
        }
    }
}
