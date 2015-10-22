using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Comparer
{
    public static class EqualityComparerExtensions
    {
        public static bool IsEqual<TModel>(this TModel extended, TModel model, IEqualityComparer<TModel> equalityComparer)
        {
            bool result = equalityComparer.Equals(extended, model);
            return result;
        }
    }
}
