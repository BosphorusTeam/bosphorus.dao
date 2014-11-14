using System.Collections.Generic;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Dao
{
    public class LuceneDao<TModel> : AbstractLuceneDao<TModel>, ILuceneDao<TModel>
    {
        public LuceneDao(ISessionManagerFactory sessionManagerFactory) 
            : base(sessionManagerFactory)
        {
        }

        public override TModel Insert(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            TModel result = base.Insert(currentSession, model);
            nativeSession.Commit();
            return result;
        }

        public override IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> result = base.Insert(currentSession, models);
            nativeSession.Commit();
            return result;
        }

        public override void Delete(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, model);
            nativeSession.Commit();
        }

        public override void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, models);
            nativeSession.Commit();
        }
    }
}