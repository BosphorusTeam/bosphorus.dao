using System;
using System.Linq;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public abstract class AbstractBuilder<TModel, TBuilder> 
        where TModel : new()
        where TBuilder: AbstractBuilder<TModel, TBuilder>, new()
    {
        protected TModel model;
        protected static readonly Lazy<IDao<TModel>> dao = new Lazy<IDao<TModel>>(BuildDao);
        protected static readonly Lazy<NHibernateStatefulSession> session = new Lazy<NHibernateStatefulSession>(GetSession);

        private static NHibernateStatefulSession GetSession()
        {
            return IoC.staticContainer.Resolve<NHibernateStatefulSession>();
        }

        private static IDao<TModel> BuildDao()
        {
            return IoC.staticContainer.Resolve<IDao<TModel>>();
        }

        protected static ISessionProvider BuildSessionProvider()
        {
            return IoC.staticContainer.Resolve<ISessionProvider>();
        }

        public AbstractBuilder()
        {
            model = new TModel();
        }

        public static TBuilder Empty
        {
            get { return new TBuilder(); }
        }

        public static TBuilder FromDatabase()
        {
            ISessionProvider sessionProvider = BuildSessionProvider();
            Console.WriteLine("Reading object from database to session ----------");
            ISession session = sessionProvider.Open<NHibernateStatefulSession>(SessionAlias.Default, SessionScope.Application);
            TModel model = dao.Value.Query(session).First();
            sessionProvider.Close<NHibernateStatefulSession>(SessionAlias.Default, SessionScope.Application);
            Console.WriteLine("Reading object from database to session ----------");

            TBuilder builder = new TBuilder();
            builder.model = model;
            return builder;
        }

        public TBuilder Evict()
        {
            session.Value.InnerSession.Evict(model);
            return (TBuilder) this;
        }

        public TModel Build()
        {
            return model;
        }
    }
}