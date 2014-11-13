using System;
using Bosphorus.Dao.Core.Session.Manager;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public interface ILuceneSessionManagerFactory
    {
        ISessionManager Build(string sessionAlias, Type type);
    }
}
