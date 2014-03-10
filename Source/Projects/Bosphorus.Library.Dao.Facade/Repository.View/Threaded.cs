using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Vao;
using Bosphorus.Library.Dao.Facade.Decoration.Threaded;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class View
        {
            public class Threaded : FacadeVaoBase<Threaded>
            {
            }

            public class Threaded<TModel> : FacadeVaoBase<Threaded, Threaded<TModel>.ComponentProvider, ThreadedDecoratorVao<TModel>, TModel>
            {
                public class ComponentProvider : Bosphorus.Library.Dao.Facade.Facade.Base.IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        IVao<TModel> vao = Live<TModel>.InternalComponent;
                        ThreadedDecoratorVao<TModel> decorator = (ThreadedDecoratorVao<TModel>) Container.Resolve(typeof(ThreadedDecoratorVao<TModel>));
                        decorator.Decorated = vao;

                        return (TComponent)(object)decorator;
                    }
                }
            }
        }
    }
}
