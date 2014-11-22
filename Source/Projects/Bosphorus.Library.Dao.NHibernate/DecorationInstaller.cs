using Bosphorus.Container.Castle.Fluent.Decoration;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate
{
    public class DecorationInstaller: AbstractWindsorInstaller, IDecoratorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Decorator
                    .Of<INHibernateSessionManagerFactory>()
                    .Is<CacheDecorator>()
                    .Is<RegistrationDecorator>()
            );
        }
    }
}
