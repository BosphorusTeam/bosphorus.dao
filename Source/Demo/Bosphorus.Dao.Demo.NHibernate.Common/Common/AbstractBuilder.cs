using System;
using System.Linq;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Dao;
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
            return ServiceRegistry.Get<NHibernateStatefulSession>();
        }

        private static IDao<TModel> BuildDao()
        {
            return ServiceRegistry.Get<IDao<TModel>>();
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
            Console.WriteLine("Reading object from database to session ----------");
            TModel model = dao.Value.Query().First();
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