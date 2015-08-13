using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session.Provider.Factory.Native;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Manager
{
    public class LuceneSessionManager : ISessionManager<LuceneSession> 
    {
        private readonly ILuceneDataProviderFactory luceneDataProviderFactory;

        public LuceneSessionManager(ILuceneDataProviderFactory luceneDataProviderFactory)
        {
            this.luceneDataProviderFactory = luceneDataProviderFactory;
        }

        public LuceneSession Construct(string aliasName)
        {
            LuceneDataProvider luceneDataProvider = luceneDataProviderFactory.Build(aliasName);
            LuceneSession session = new LuceneSession(luceneDataProvider);
            return session;
        }

        public void Destruct(LuceneSession session)
        {
            LuceneDataProvider innerSession = session.InnerSession;
            innerSession.IndexWriter.Optimize();
            innerSession.Dispose();
        }
    }
}
