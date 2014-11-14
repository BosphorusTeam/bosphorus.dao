using System;
using System.Collections;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public static class LuceneSessionManagerFactoryExtensions
    {
        public static ISessionManager Build(this ISessionManagerFactory extended, Type type)
        {
            IDictionary creationArguments = new Hashtable();
            creationArguments["Type"] = type;

            ISessionManager result = extended.Build(creationArguments);

            return result;
        }
    }
}
