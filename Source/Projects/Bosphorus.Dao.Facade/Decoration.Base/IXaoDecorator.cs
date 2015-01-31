using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Base.Model;

namespace Bosphorus.Library.Dao.Facade.Decoration.Base
{
    public interface IXaoDecorator<TModel> : IXao<TModel>
    {
        IXao<TModel> Decorated
        {
            get; 
            set;
        }
    }
}
