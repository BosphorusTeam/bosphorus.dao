using System;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Transaction;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session
{
    public class LuceneSession<TModel> : ISession
    {
        private ISession<TModel> adapted;

        public LuceneSession(ISession<TModel> adapted)
        {
            this.adapted = adapted;
        }

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public ISession<TModel> InnerSession
        {
            get { return adapted; }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                adapted.Dispose();
                adapted = null;
                GC.SuppressFinalize(this);
            }
        }

        ~LuceneSession()
        {
            Dispose(false);
        }
    }
}
