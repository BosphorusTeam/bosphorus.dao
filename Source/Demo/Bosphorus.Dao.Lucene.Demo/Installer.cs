using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene.Demo
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(IDao<>))
                    .ImplementedBy(typeof(LuceneDao<>))
            );
        }
    }
}
