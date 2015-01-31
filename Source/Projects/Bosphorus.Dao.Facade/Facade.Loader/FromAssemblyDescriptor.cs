using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace Bosphorus.Library.Dao.Facade.Facade.Loader
{
    public class FromAssemblyDescriptor
    {
        private readonly Assembly assembly;

        public FromAssemblyDescriptor(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IRegistration IsAppropriate(Type repositoryServiceType)
        {
            return IsAppropriate(repositoryServiceType, null);
        }


        public IRegistration IsAppropriate(Type repositoryServiceType, string endsWith)
        {
            return IsAppropriate(repositoryServiceType, null, null);
        }

        public IRegistration IsAppropriate(Type repositoryServiceType, string inNamespace, string endsWith)
        {
            return AllTypes.FromAssembly(assembly)
                .Where(IsAppropriateDelegate(repositoryServiceType, inNamespace, endsWith))
                .WithService.Select(SelectService(repositoryServiceType))
                .Configure(new ConfigureDelegate(ConfigureRegistration));
        }

        private string GetTypeName(Type type)
        {
            string typeName = type.Name;
            string[] parts = typeName.Split('`');
            return parts[0];
        }

        private Predicate<Type> IsAppropriateDelegate(Type repositoryServiceType, string inNamespace, string endsWith)
        {
            return delegate(Type type)
            {
                string typeName = GetTypeName(type);

                if ((endsWith != null) && (!typeName.EndsWith(endsWith, StringComparison.InvariantCultureIgnoreCase)))
                    return false;

                if ((inNamespace != null) && (!type.Namespace.StartsWith(inNamespace, StringComparison.InvariantCultureIgnoreCase)))
                    return false;

                if (type.IsAbstract)
                    return false;

                if (type.IsGenericType)
                    return false;

                Type[] interfaces = type.GetInterfaces();
                foreach (Type @interface in interfaces)
                {
                    if (!@interface.IsGenericType)
                        continue;

                    if (@interface.GetGenericTypeDefinition().Equals(repositoryServiceType))
                        return true;
                }
                return false;
            };
        }

        private ServiceDescriptor.ServiceSelector SelectService(Type repositoryServiceType)
        {
            return delegate(Type type, Type baseType)
            {
                Type[] interfaces = type.GetInterfaces();
                foreach (Type @interface in interfaces)
                {
                    if (!@interface.IsGenericType)
                        continue;

                    if (!@interface.GetGenericTypeDefinition().Equals(repositoryServiceType))
                        continue;

                    return new Type[] { @interface };
                }
                return null;
            };
        }

        private object ConfigureRegistration(ComponentRegistration registration)
        {
            string typeName = GetTypeName(registration.Implementation);
            registration.Named(typeName);
            return registration;
        }
    }
}
