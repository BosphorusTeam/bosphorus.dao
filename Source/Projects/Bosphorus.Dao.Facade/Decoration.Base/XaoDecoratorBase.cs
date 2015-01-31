using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Base.Model;

namespace Bosphorus.Library.Dao.Facade.Decoration.Base
{
    public class XaoDecoratorBase<TModel> : IXaoDecorator<TModel>
    {
        private IXao<TModel> decorated;

        public IXao<TModel> Decorated
        {
            get { return decorated; }
            set { decorated = value; }
        }

        public virtual IList<TModel> GetAll()
        {
            return Decorated.GetAll();
        }

        public virtual IList<TModel> GetByCriteria(params object[] criterions)
        {
            return Decorated.GetByCriteria(criterions);
        }
    }
}
