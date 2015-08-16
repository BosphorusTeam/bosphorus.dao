using System;
using Bosphorus.Common.Core.Application;
using Bosphorus.Dao.Client;
using Environment = Bosphorus.Common.Core.Application.Environment;

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
