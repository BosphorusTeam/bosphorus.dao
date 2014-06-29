namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Coalesce
{
    //http://weblogs.asp.net/ricardoperes/linq-to-nhibernate-extensions
    public static class ObjectExtensions
    {
        public static T Coalesce<T>(this T obj, T fallback) where T : class
        {
            return (obj ?? fallback);
        }
    }
}
