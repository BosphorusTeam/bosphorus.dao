using Bosphorus.BootStapper.Common;

namespace Bosphorus.Dao.Client.Demo
{
    static class Program
    {
        [System.STAThread]
        static void Main()
        {
            DaoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}