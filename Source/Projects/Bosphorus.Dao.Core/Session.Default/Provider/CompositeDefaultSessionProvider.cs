using System.Collections.Generic;
using Bosphorus.Dao.Core.Dao;

namespace Bosphorus.Dao.Core.Session.Default.Provider
{
    class CompositeDefaultSessionProvider: IDefaultSessionProvider
    {
        private readonly IList<IDefaultSessionProvider> items;

        public CompositeDefaultSessionProvider(IList<IDefaultSessionProvider> items)
        {
            this.items = items;
        }

        public bool isApplicable<TCurrentModel>(IDao<TCurrentModel> dao)
        {
            throw new System.NotImplementedException();
        }

        public ISession Get<TModel>(IDao<TModel> dao, string sessionAlias)
        {
            foreach (IDefaultSessionProvider item in items)
            {
                ISession session = item.Get(dao, sessionAlias);
                if (session == null)
                {
                    continue;;
                }

                return session;
            }

            //TODO: Throw exceptipn
            return null;
        }
    }

}