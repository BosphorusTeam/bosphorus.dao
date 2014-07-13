using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Runner;

namespace Bosphorus.Dao.Client
{
    public static class DaoRunner
    {
        public static void Run(Environment environment, Perspective perspective, params string[] args)
        {
            WinFormRunner.Run<ClientForm>(environment, perspective, args);
        }
    }
}
