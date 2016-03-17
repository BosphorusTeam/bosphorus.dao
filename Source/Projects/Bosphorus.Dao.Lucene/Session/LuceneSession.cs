using System;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Transaction;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session
{
    public class LuceneSession : ISession
    {
        private readonly LuceneDataProvider adapted;

        public LuceneSession(LuceneDataProvider adapted)
        {
            this.adapted = adapted;
        }

        public object NativeSession => adapted;

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
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
                //adapted = null;
                GC.SuppressFinalize(this);
            }
        }

        ~LuceneSession()
        {
            Dispose(false);
        }
    }
}
