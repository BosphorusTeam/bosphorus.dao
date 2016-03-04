using System;
using System.Linq;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Stateful.Session;

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
            ISessionProvider sessionProvider = ContainerHolder.Current.Resolve<ISessionProvider>();
            sessionProvider.Current<NHibernateStatefulSession>().InnerSession.Evict(model);
            return (TBuilder) this;
        }

        public TModel Build()
        {
            return model;
        }
    }
}