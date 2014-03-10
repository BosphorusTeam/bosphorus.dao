using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.Core.Session
{
    public class NullSession: ISession
    {
        public static NullSession Instance = new NullSession();

        public string Name
        {
            get { return "[Null Session]"; }
        }

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            return NullTransaction.Instance;
        }

        public object Clone()
        {
            return new NullSession();
        }

        public void Dispose()
        {
        }
    }
}
