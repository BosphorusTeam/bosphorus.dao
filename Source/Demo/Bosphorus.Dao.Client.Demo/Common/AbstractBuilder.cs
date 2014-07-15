using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Dao;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public abstract class AbstractBuilder<TModel, TBuilder> 
        where TModel : new()
        where TBuilder: AbstractBuilder<TModel, TBuilder>, new()
    {
        protected TModel model;

        public AbstractBuilder()
        {
            model = new TModel();
        }

        public static TBuilder New
        {
            get { return new TBuilder(); }
        }

        public static TBuilder FromDatabase(int id)
        {
            TModel model = ServiceRegistry.Get<IDao<TModel>>().GetByIdSingle(id);
            TBuilder builder = new TBuilder();
            builder.model = model;
            return builder;
        }

        public TModel Build()
        {
            return model;
        }
    }
}