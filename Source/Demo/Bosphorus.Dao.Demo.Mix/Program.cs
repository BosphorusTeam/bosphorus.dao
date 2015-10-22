using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Common.Core.Application;
using Bosphorus.Demo.Runner;

namespace Bosphorus.Dao.Demo.Mix
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}
