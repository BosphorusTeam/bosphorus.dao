namespace Bosphorus.Dao.Core.Session
{
    public static class Extensions
    {
        public static TNativeSession GetNativeSession<TNativeSession>(this ISession extended)
        {
            object nativeSession = extended.NativeSession;
            return (TNativeSession) nativeSession;
        }
    }
}
