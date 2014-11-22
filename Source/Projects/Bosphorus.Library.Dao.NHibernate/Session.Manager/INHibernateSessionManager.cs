using Bosphorus.Dao.Core.Session.Manager;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public interface INHibernateSessionManager: ISessionManager
    {
        ISessionFactory NativeSessionManager { get; }
    }
}
