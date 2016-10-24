namespace Bosphorus.Dao.Core.Session.Repository
{
    public enum SessionScope
    {
        Null,
        HostBounded,
        Call,
        Application,
        Thread
    }
}