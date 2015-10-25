using System.Collections.Generic;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Implementation;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Selector;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Merger.Core.Decoration.Cache;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Merge
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IMerger<>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(IMerger<>))
                    .ImplementedBy(typeof(PrimitiveMerger<>), GenericService.AllArgs.IsStruct),

                Component
                    .For(typeof(IMerger<>))
                    .ImplementedBy(typeof(ListMerger<>), GenericImplementationArgs.Transformed.ListTrimmed, GenericService.AllArgs.IsList),

                Component
                    .For(typeof(IMerger<>))
                    .ImplementedBy(typeof(DefaultMerger<>)),

                Component
                    .For<PerCallContextCache>()
                    .LifeStyle.Singleton.Start(),

                Component
                    .For(typeof(IMerger<>))
                    .ImplementedBy(typeof(CacheDecorator<>))
                    .IsDefault(),

                Component
                    .For<GenericMerger>()
            );
        }
    }
}
