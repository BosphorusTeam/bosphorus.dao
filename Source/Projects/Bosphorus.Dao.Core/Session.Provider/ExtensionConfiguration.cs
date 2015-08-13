using System;
using Bosphorus.Configuration.Core;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public class ExtensionConfiguration: AbstractConfiguration
    {
        public ExtensionConfiguration(IParameterProvider parameterProvider) 
            : base(typeof(Extension).FullName, parameterProvider)
        {
        }

        public Type DefaultSessionType => GetValue<Type>("DefaultSessionType");

        public SessionScope DefaultSessionScope => SessionScope.Application;
    }
}
