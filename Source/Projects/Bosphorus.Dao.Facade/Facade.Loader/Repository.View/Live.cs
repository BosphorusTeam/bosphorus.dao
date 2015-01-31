using System;
using Bosphorus.Library.Dao.Core.Model.Vao;
using Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.View
{
    public class Live: AbstractRepositoryContainerConfigurator
    {
        public Live(string assemblyName, string @namespace)
            : this(assemblyName, @namespace, "Vao")
        {
        }

        public Live(string assemblyName, string @namespace, string endsWith)
            : base(typeof(IVao<>), typeof(NullVao<>), assemblyName, @namespace, endsWith)
        {
        }
    }
}
