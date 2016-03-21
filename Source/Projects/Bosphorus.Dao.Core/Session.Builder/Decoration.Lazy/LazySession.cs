using System;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.Core.Session.Builder.Decoration.Lazy
{
    public class LazySession : ISession
    {
        internal Lazy<ISession> Inner { get; }

        public LazySession(Lazy<ISession> inner)
        {
            this.Inner = inner;
        }

        public object NativeSession => Inner.Value.NativeSession;

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            return Inner.Value.NewTransaction(isolationLevel);
        }

        public void Clear()
        {
            if (!Inner.IsValueCreated)
            {
                return;
            }

            Inner.Value.Clear();
        }

        public void Flush()
        {
            if (!Inner.IsValueCreated)
            {
                return;
            }

            Inner.Value.Flush();
        }
    }
}