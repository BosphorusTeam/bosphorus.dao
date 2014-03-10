using Bosphorus.Dao.Core.Dao.Decoration;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class DaoExtension
    {
        public static IDao<TModel> Cached<TModel>(this IDao<TModel> decorated)
        {
            IDao<TModel> decorator = new CacheDecorator<TModel>(decorated);
            return decorator;
        }

    }
}
