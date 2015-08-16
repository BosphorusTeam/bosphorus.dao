﻿using Bosphorus.Dao.Core.Dao.Decoration.Cache;
using Bosphorus.Dao.Core.Session;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class Decorations
    {
        //TODO: Cache sadece bir kere yaratılmalı, her seferinde değil.
        public static IDao<TModel> Cached<TModel>(this IDao<TModel> decorated) 
        {
            IDao<TModel> decorator = new CacheDecorator<TModel>(decorated);
            return decorator;
        }

    }
}
