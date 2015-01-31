namespace Bosphorus.Dao.Core.Session.Provider.Factory
{
    public interface ISessionProviderFactory<TSession> 
        where TSession : ISession
    {
        ISessionProvider<TSession> Build(string sessionAlias);
    }
}
