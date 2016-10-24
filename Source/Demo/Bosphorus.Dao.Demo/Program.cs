using Bosphorus.Assemble.BootStrapper.Runner.Demo;
using Bosphorus.Common.Application;

namespace Bosphorus.Dao.Demo
{
    static class Program
    {
        static void Main()
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug, typeof(IDemoInstaller));
        }
    }
}