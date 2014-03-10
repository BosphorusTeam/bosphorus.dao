using System;
using Bosphorus.Library.Dao.Facade.Decoration.Threaded;
using Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Base;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Domain
{
    public class Threaded : AbstractRepositoryContainerConfigurator
    {
        public Threaded(string assemblyName, string @namespace)
            : this(assemblyName, @namespace, "Thread")
        {
        }

        public Threaded(string assemblyName, string @namespace, string endsWith)
            : base(typeof(ThreadedDecoratorDao<>), typeof(ThreadedDecoratorDaoDefault<>), assemblyName, @namespace, endsWith)
        {
        }
    }
}
