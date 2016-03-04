using Castle.Windsor;

namespace Bosphorus.Dao.Core.Common
{
    public class ContainerHolder
    {
        public static IWindsorContainer Current { get; private set; }

        public ContainerHolder(IWindsorContainer container)
        {
            Current = container;
        }
    }
}
