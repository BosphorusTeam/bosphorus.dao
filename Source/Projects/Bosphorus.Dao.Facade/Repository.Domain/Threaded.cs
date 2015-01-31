using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Facade.Decoration.Threaded;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class Domain
        {
            public partial class Threaded : FacadeDaoBase<Threaded>
            {
            }

            public partial class Threaded<TModel> : FacadeDaoBase<Threaded, Threaded<TModel>.ComponentProvider, ThreadedDecoratorDao<TModel>, TModel>
            {
                public class ComponentProvider : Bosphorus.Library.Dao.Facade.Facade.Base.IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        IDao<TModel> dao = Live<TModel>.InternalComponent;
                        ThreadedDecoratorDao<TModel> decorator = (ThreadedDecoratorDao<TModel>) Container.Resolve(typeof(ThreadedDecoratorDao<TModel>));
                        decorator.Decorated = dao;

                        return (TComponent)(object)decorator;
                    }
                }
            }
        }
    }
}
