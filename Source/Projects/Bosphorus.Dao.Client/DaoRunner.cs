using Bosphorus.BootStapper.Runner.WinForn;
using Bosphorus.Common.Core.Application;

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
