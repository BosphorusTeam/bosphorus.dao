using System;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Domain
{
    public class Live : AbstractRepositoryContainerConfigurator
    {
        public Live(string assemblyName, string @namespace)
            : this(assemblyName, @namespace, "Dao")
        {
        }

        public Live(string assemblyName, string @namespace, string endsWith)
            : base(typeof(IDao<>), typeof(NullDao<>), assemblyName, @namespace, endsWith)
        {
        }
    }
}
