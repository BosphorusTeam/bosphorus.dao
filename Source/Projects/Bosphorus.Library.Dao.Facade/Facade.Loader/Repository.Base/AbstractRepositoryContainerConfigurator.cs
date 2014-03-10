using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Facade.Loader.Castle.Configurator;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader.Repository.Base
{
    public abstract class AbstractRepositoryContainerConfigurator: IContainerConfigurator
    {
        protected readonly string assemblyName;
        private readonly string endsWith;
        protected readonly string @namespace;
        protected readonly Type serviceType;
        protected readonly Type defaultImplimentationType;
        private const string KEY_GENERIC = "Generic";

        protected AbstractRepositoryContainerConfigurator(Type serviceType, Type defaultImplimentationType, string assemblyName, string @namespace, string endsWith)
        {
            this.@namespace = @namespace;
            this.assemblyName = assemblyName;
            this.endsWith = endsWith;
            this.serviceType = serviceType;
            this.defaultImplimentationType = defaultImplimentationType;
        }

        public virtual void Configure(IWindsorContainer container)
        {
            Assembly assembly = Assembly.Load(assemblyName);

            container.Register(
                Component.For(serviceType)
                .Named(KEY_GENERIC)
                .ImplementedBy(defaultImplimentationType)
            );

            container.Register(
                RepositoryTypes.FromAssembly(assembly)
                .IsAppropriate(serviceType, @namespace, endsWith)
            );
        }
    }
}
