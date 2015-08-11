using System;
using Bosphorus.Container.Castle.Fluent;
using Bosphorus.Container.Castle.Fluent.Decoration;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.Lucene.Session.Provider.Factory.Native;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof (ILuceneDao<>))
                    .ImplementedBy(typeof (LuceneDao<>))
                    .NamedUnique(),

                /*
                Component
                    .For(typeof (ISessionProviderFactory<>))
                    .ImplementedBy(typeof(LuceneSessionProviderFactory<>), new ImplementationMatchingStrategy(), new ServiceStrategy())
                    .NamedAutomatically("LuceneSessionProviderFactory"),
                */

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

    }
}
