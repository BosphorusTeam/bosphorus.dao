using System;
using Bosphorus.Container.Castle.Fluent.Decoration;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Bosphorus.Dao.Lucene.Session.Provider.Factory.Native;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof (ILuceneDao<>))
                    .ImplementedBy(typeof (LuceneDao<>))
                    .NamedAutomatically("LuceneDao"),

                Component
                    .For(typeof (ISessionProviderFactory<>))
                    .ImplementedBy(typeof(LuceneSessionProviderFactory<>), new ImplementationMatchingStrategy(), new ServiceStrategy())
                    .NamedAutomatically("LuceneSessionProviderFactory"),

                allLoadedTypes
                    .BasedOn(typeof(ILuceneMap<>))
                    .WithService
                    .AllInterfaces(),

                //TODO: Cache decoartor of LuceneSessionProviderFactory<> must be...
                allLoadedTypes
                    .BasedOn<ILuceneDataProviderFactory>()
                    .WithService
                    .FromInterface(),

                Decorator
                    .Of<ILuceneDataProviderFactory>()
                    .Is<CacheDecorator>()
            );

        }

        private class ServiceStrategy : IGenericServiceStrategy
        {
            private readonly Type luceneSessionType;

            public ServiceStrategy()
            {
                luceneSessionType = typeof(LuceneSession<>);
            }

            public bool Supports(Type service, ComponentModel component)
            {
                //LuceneSession<>
                Type sessionType = service.GetGenericArguments()[0];

                if (!sessionType.IsGenericType)
                {
                    return false;
                }

                Type genericTypeDefinition = sessionType.GetGenericTypeDefinition();
                if (genericTypeDefinition != luceneSessionType)
                {
                    return false;
                }

                return true;
            }
        }

        private class ImplementationMatchingStrategy : IGenericImplementationMatchingStrategy
        {
            public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
            {
                //LuceneSession<Foo>
                Type sessionType = context.GenericArguments[0];
                Type modelType = sessionType.GetGenericArguments()[0];
                return new[] { modelType };
            }
        }

    }
}
