using System;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Default.Provider;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.Lucene.Dao;

namespace Bosphorus.Dao.Lucene.Session.Default
{
    public class LuceneDefaultSessionProvider: IDefaultSessionProvider
    {
        private readonly IServiceRegistry serviceRegistry;

        public LuceneDefaultSessionProvider(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public ISession Get<TModel>(IDao<TModel> dao, string sessionAlias)
        {
            Type daoType = dao.GetType();
            Type baseParameterizedType = typeof (ILuceneDao<TModel>);
            bool isAssignableFrom = baseParameterizedType.IsAssignableFrom(daoType);
            if (!isAssignableFrom)
            {
                return null;
            }

            ISessionProviderFactory<LuceneSession<TModel>> sessionProviderFactory = serviceRegistry.Get<ISessionProviderFactory<LuceneSession<TModel>>>();
            ISessionProvider<LuceneSession<TModel>> sessionProvider = sessionProviderFactory.Build(sessionAlias);
            LuceneSession<TModel> luceneSession = sessionProvider.Current();
            return luceneSession;
        }
    }
}
