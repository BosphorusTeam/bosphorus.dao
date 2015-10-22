using System;
using Bosphorus.Common.Core.Application;
using Bosphorus.Demo.Runner;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    static class Program
    {
        static void Main()
        {
            DemoRunner.Run(Environment.Local, Perspective.Debug);
        }
    }
}