using Bosphorus.Assemble.BootStrapper.Runner.Demo;
using Bosphorus.Common.Application;
using Bosphorus.Dao.Demo.Common;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    static class Program
    {
        static void Main()
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug, typeof(IDemoInstaller));
        }
    }
}