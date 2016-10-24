using Bosphorus.Common.Api.Container;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public class ContainerHolder
    {
        public static IWindsorContainer Container;

        public class Installer : IBosphorusInstaller
        {
            public void Install(IWindsorContainer instance, IConfigurationStore store)
            {
                Container = instance;
            }
        }
    }
}
