using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader
{
    public class RepositoryTypes
    {
        public static FromAssemblyDescriptor FromAssembly(Assembly assembly)
        {
            return new FromAssemblyDescriptor(assembly);
        }
    }
}
