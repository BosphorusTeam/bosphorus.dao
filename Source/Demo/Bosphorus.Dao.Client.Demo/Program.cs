using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Container.Castle.Registry;
using Castle.Core.Internal;

namespace Bosphorus.Dao.Client.Demo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
            DaoClientDemo.Run();
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.RequestingAssembly != null)
            {
                return args.RequestingAssembly;
            }

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            string[] strings = args.Name.Split(',');
            Assembly foundAssembly = assemblies.FirstOrDefault(assembly => assembly.GetName().Name == strings[0]);
            return foundAssembly;
        }

    }
}