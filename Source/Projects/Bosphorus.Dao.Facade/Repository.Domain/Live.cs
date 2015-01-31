using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Facade.Facade.Base;

namespace Bosphorus.Library.Facades
{
    public partial class Repository
    {
        public partial class Domain
        {
            public class Live : FacadeDaoBase<Live>
            {
            }

            public class Live<TModel> : FacadeDaoBase<Live, Live<TModel>.ComponentProvider, IDao<TModel>, TModel>
            {
                public class ComponentProvider : IComponentProvider
                {
                    public TComponent GetComponent<TComponent>()
                    {
                        return (TComponent)Container.Resolve(typeof(TComponent));
                    }
                }
            }
        }
    }
}
