namespace Bosphorus.Dao.NHibernate.Extension.LinQ.CastAs
{
    //http://weblogs.asp.net/ricardoperes/linq-to-nhibernate-extensions
    public static class ObjectExtensions
    {
        public static TTarget CastAs<TTarget>(this object source)
        {
            return ((TTarget)source);
        }
    }
}
