using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.Client;

namespace Bosphorus.Dao.Demo.Mix
{
    class Program
    {
        static void Main(string[] args)
        {
            DaoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}
