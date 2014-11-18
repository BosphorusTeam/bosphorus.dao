using System;
using System.Linq;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public abstract class AbstractBuilder<TModel, TBuilder> 
        where TModel : new()
        where TBuilder: AbstractBuilder<TModel, TBuilder>, new()
    {
        protected TModel model;
        protected static Lazy<IDao<TModel>> dao = new Lazy<IDao<TModel>>(BuildDao);

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
            NHibernateSession sesion = (NHibernateSession) dao.Value.SessionManager.Current;
            var session = sesion.InnerSession;
            session.Evict(model);

            return (TBuilder) this;
        }

        public TModel Build()
        {
            return model;
        }
    }
}