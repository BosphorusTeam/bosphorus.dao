using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<DefaultLuceneSessionManagerFactory>(),

                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<CacheDecorator>()
                    .IsDefault()
            );

        }
    }
}
