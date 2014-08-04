using System;

namespace Bosphorus.Dao.Common.Instantiator
{
    public interface IInstantiator
    {
        bool IsApplicable(Type type);

        object Create(Type type);
    }
}
