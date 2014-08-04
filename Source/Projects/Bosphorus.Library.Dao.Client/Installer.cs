using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Client
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IResultTransformer>()
                    .ImplementedBy<ChainedResultTransformer>()
                    .IsDefault(),

                allLoadedTypes
                    .BasedOn<IExecutionItemList>()
                    .WithService
                    .FirstInterface(),

                Component
                    .For<IExecutionItemList>()
                    .ImplementedBy<CompositeEceutionItemList>()
                    .IsDefault()
            );
        }
    }
}
