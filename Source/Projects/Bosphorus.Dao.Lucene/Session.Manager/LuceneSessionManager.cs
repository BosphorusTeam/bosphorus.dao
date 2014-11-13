using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Manager
{
    public class LuceneSessionManager<TModel>: ISessionManager 
        where TModel : new()
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly string sessionAlias;
        private readonly LuceneDataProvider luceneDataProvider;

        public LuceneSessionManager(IServiceRegistry serviceRegistry, string sessionAlias, LuceneDataProvider luceneDataProvider)
        {
            this.serviceRegistry = serviceRegistry;
            this.sessionAlias = sessionAlias;
            this.luceneDataProvider = luceneDataProvider;
        }

        public string SessionAlias
        {
            get { return sessionAlias; }

        }

        public ISession OpenSession()
        {
            ISession<TModel> nativeSession = luceneDataProvider.OpenSession<TModel>();
            ISession session = new LuceneSession<TModel>(nativeSession);
            return session;
        }

        public ISession Current
        {
            get
            {
                var argument = new { SessionAlias = SessionAlias, Type = typeof(TModel) };
                return serviceRegistry.Get<ISession>(argument);
            }
        }


        public void CloseSession(ISession session)
        {
            session.Dispose();
        }
    }
}
