using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Vao;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedDecoratorVao<TModel> : ThreadedDecoratorXao<TModel>, IVao<TModel>
    {
    }
}
