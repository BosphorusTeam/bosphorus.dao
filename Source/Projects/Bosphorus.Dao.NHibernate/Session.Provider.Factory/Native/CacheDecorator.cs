using System.Collections.Concurrent;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native
{
    internal class CacheDecorator : INHibernateSessionFactoryBuilder
    {
        private readonly INHibernateSessionFactoryBuilder decorated;
        private readonly ConcurrentDictionary<string, ISessionFactory> aliasSessionFactoryDictionary;

        public CacheDecorator(INHibernateSessionFactoryBuilder decorated)
        {
            this.decorated = decorated;
            this.aliasSessionFactoryDictionary = new ConcurrentDictionary<string, ISessionFactory>();
        }

        public ISessionFactory Build(string sessionAlias)
        {
            ISessionFactory result = aliasSessionFactoryDictionary.GetOrAdd(sessionAlias, BuildSessionFactory);
            return result;
        }

        private ISessionFactory BuildSessionFactory(string sessionAlias)
        {
            ISessionFactory sessionFactory = decorated.Build(sessionAlias);
            return sessionFactory;
        }
    }
}