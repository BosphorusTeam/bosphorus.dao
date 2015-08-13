using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Lucene.Dao;

namespace Bosphorus.Dao.Lucene.Session.Dao
{
    public class LuceneSessionDaoRegisterer: ISessionDaoRegisterer
    {
        public void Register(SessionDaoRegistry sessionDaoRegistry)
        {
            sessionDaoRegistry.Register<LuceneSession>(typeof(LuceneDao<>));
        }
    }
}