using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public static class Randomize
    {
        public static string String()
        {
            string name = "Random " + DateTime.Now.Second / 10;
            return name;
        }

        public static string Integer()
        {
            throw new NotImplementedException();
        }
    }
}
