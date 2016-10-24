using System;

namespace Bosphorus.Dao.Demo.Builder
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
