using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.Client;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    static class Program
    {
        //[System.STAThread]
        static void Main()
        {
            DaoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}