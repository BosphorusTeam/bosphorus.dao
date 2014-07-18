using Castle.Core;

namespace Bosphorus.Dao.NHibernate.Session
{
    public abstract class AbstractSessionLifeStyleProvider : ISessionLifeStyleProvider
    {
        public abstract LifestyleType GetLifestyle();
    }
}