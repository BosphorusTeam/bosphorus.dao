using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.Client;

namespace Bosphorus.Dao.Lucene.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DaoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}
