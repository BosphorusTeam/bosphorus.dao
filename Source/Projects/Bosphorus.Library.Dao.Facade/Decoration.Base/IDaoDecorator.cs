using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;

namespace Bosphorus.Library.Dao.Facade.Decoration.Base
{
    public interface IDaoDecorator<TModel>: IDao<TModel>
    {
    }
}
