using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Lucene.Net.Linq;
using Lucene.Net.Linq.Mapping;

namespace Bosphorus.Dao.Lucene.Session.Manager
{
    public class LuceneSessionManager<TModel> : AbstractSessionManager<LuceneSession<TModel>>, ILuceneSessionManager
        where TModel : new()
    {
        private readonly LuceneDataProvider luceneDataProvider;
        private readonly IDocumentMapper<TModel> documentMapper;

        public LuceneSessionManager(IServiceRegistry serviceRegistry,  LuceneDataProvider luceneDataProvider) 
            : base(serviceRegistry)
        {
            this.luceneDataProvider = luceneDataProvider;
            //ILuceneMap<TModel> luceneMap = serviceRegistry.Get<ILuceneMap<TModel>>();
            //documentMapper = luceneMap.ToDocumentMapper();
            documentMapper = new ReflectionDocumentMapper<TModel>(luceneDataProvider.LuceneVersion);
        }

        public override ISession OpenSession()
        {
            ISession<TModel> nativeSession = luceneDataProvider.OpenSession(documentMapper);
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
