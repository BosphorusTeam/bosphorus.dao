using System;
using System.Collections;
using Bosphorus.Dao.Core.Session.Manager;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public static class LuceneSessionManagerFactoryExtensions
    {
        public static ISessionManager Build(this ILuceneSessionManagerFactory extended, IDictionary sessionCreationArguments)
        {
            Type type = (Type)sessionCreationArguments["Type"];
            ISessionManager result = extended.Build(type);

            return result;
        }
    }
}
