using System;

namespace Bosphorus.Dao.Common.Instantiator
{
    public interface IInstantiator<out TModel>
    {
        TModel Create();
    }
}
