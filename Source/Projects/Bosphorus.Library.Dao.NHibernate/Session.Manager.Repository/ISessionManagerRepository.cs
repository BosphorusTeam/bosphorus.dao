using System;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Repository
{
    public interface ISessionManagerRepository
    {
        INHibernateSessionManager Get(Type modelType);
    }
}
