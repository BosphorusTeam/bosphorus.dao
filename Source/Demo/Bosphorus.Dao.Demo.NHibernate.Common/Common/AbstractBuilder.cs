using System;
using System.Linq;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Stateful.Session;
using ISession = NHibernate.ISession;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public abstract class AbstractBuilder<TModel, TBuilder> 
        where TModel : new()
        where TBuilder: AbstractBuilder<TModel, TBuilder>, new()
    {
        protected TModel model;
        protected static readonly Lazy<IDao<TModel>> dao = new Lazy<IDao<TModel>>(BuildDao);

        private static IDao<TModel> BuildDao()
        {
            return ContainerHolder.Current.Resolve<IDao<TModel>>();
        }

        protected AbstractBuilder()
        {
            model = new TModel();
        }

        public static TBuilder Empty => new TBuilder();

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
            ISessionProvider sessionProvider = ContainerHolder.Current.Resolve<ISessionProvider>();
            var session = sessionProvider.Current<NHibernateStatefulSession>();
            var nativeSession = session.GetNativeSession<global::NHibernate.ISession>();
            nativeSession.Evict(model);
            return (TBuilder) this;
        }

        public TModel Build()
        {
            return model;
        }
    }
}