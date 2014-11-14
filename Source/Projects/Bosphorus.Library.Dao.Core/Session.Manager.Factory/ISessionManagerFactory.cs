using System.Collections;

namespace Bosphorus.Dao.Core.Session.Manager.Factory
{
    public interface ISessionManagerFactory
    {
        ISessionManager Build(IDictionary creationArguments);
    }
}
