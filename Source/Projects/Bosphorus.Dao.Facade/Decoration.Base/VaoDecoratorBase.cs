using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Vao;

namespace Bosphorus.Library.Dao.Facade.Decoration.Base
{
    public class VaoDecoratorBase<TModel>: XaoDecoratorBase<TModel>, IVaoDecorator<TModel>
    {
        public new IVao<TModel> Decorated
        {
            get { return (IVao<TModel>)base.Decorated; }
            set { base.Decorated = value; }
        }
    }
}
