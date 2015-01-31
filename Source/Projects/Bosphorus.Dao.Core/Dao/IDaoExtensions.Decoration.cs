using Bosphorus.Dao.Core.Dao.Decoration;
using Bosphorus.Dao.Core.Session;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class IDaoExtensions
    {
        //TODO: Cache sadece bir kere yaratılmalı, her seferinde değil.
        public static IDao<TModel> Cached<TModel>(this IDao<TModel> decorated) 
        {
            IDao<TModel> decorator = new CacheDecorator<TModel>(decorated);
            return decorator;
        }

    }
}
