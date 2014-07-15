using Bosphorus.Dao.Core.Dao;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public static class Extensions
    {
        public static TModel DeleteReturned<TModel>(this IDao<TModel> dao, TModel model)
        {
            dao.Delete(model);
            return model;
        }

        public static TModel DeleteReturned<TModel>(this IDao dao, TModel model)
        {
            dao.Delete(model);
            return model;
        }
    }
}
