using Castle.Core;

namespace Bosphorus.Dao.NHibernate.Session
{
    public interface ISessionLifeStyleProvider
    {
        LifestyleType GetLifestyle();
    }
}
