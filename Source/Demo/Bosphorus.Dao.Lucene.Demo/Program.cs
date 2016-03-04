using Bosphorus.Assemble.BootStrapper.Runner.Demo;
using Bosphorus.Common.Application;
using Bosphorus.Dao.Demo.Common;

namespace Bosphorus.Dao.Lucene.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug, typeof(IDemoInstaller));
        }
    }
}
