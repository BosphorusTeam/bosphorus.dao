using System;
using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.Client;
using Environment = Bosphorus.BootStapper.Common.Environment;

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
