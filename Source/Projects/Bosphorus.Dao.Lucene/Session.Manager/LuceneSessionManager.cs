using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Manager
{
    public class LuceneSessionManager<TModel> : AbstractSessionManager<LuceneSession<TModel>>, ILuceneSessionManager
        where TModel : new()
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly LuceneDataProvider luceneDataProvider;

        public LuceneSessionManager(IServiceRegistry serviceRegistry, LuceneDataProvider luceneDataProvider) 
            : base(serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
            this.luceneDataProvider = luceneDataProvider;
        }

        public override ISession OpenSession()
        {
            ISession<TModel> nativeSession = luceneDataProvider.OpenSession<TModel>();
            ISession session = new LuceneSession<TModel>(nativeSession);
            return session;
        }

        protected override object BuildSessionManagerCreationArguments()
        {
            var creationArguments = new { Type = typeof(TModel) };
            return creationArguments;
        }

        public override void CloseSession(ISession session)
        {
            session.Dispose();
        }
    }
}
