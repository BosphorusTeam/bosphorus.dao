using System.Linq;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.In
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T @value, params T[] values)
        {
            return values.Contains(@value);
        }

        public static bool In<T>(this T @value, IQueryable<T> values)
        {
            return values.Contains(@value);
        }

        public static bool NotIn<T>(this T @value, params T[] values)
        {
            return !values.Contains(@value);
        }

        public static bool NotIn<T>(this T @value, IQueryable<T> values)
        {
            return !values.Contains(@value);
        }
    }
}
