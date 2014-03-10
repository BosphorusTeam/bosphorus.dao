using System;
using Bosphorus.Library.Dao.Facade.Decoration.Cache;
using Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.View
{
    public class Cache : AbstractRepositoryContainerConfigurator
    {
        public Cache(string assemblyName, string @namespace)
            : this(assemblyName, @namespace, "Cache")
        {
        }

        public Cache(string assemblyName, string @namespace, string endsWith)
            : base(typeof(IVaoCacheDecorator<>), typeof(DefaultVaoCacheDecorator<>), assemblyName, @namespace, endsWith)
        {
        }
    }
}
