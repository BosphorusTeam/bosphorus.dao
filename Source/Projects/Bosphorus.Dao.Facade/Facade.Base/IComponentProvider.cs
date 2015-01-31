using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public interface IComponentProvider
    {
        TComponent GetComponent<TComponent>();
    }
}
