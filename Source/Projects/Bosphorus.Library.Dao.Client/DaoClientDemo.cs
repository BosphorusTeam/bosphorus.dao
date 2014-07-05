using Bosphorus.BootStapper.Runner;

namespace Bosphorus.Dao.Client
{
    public static class DaoClientDemo
    {
        public static void Run()
        {
            Run(Environment.Local, Perspective.Debug);
        }

        public static void Run(Environment environment, Perspective perspective, params string[] args)
        {
            WinFormRunner.Run<ClientForm>(environment, perspective, args);
        }
    }
}
