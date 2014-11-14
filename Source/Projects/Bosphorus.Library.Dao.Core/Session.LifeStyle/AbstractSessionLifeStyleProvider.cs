using Castle.Core;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public abstract class AbstractSessionLifeStyleProvider : ISessionLifeStyleProvider
    {
        public abstract LifestyleType GetLifestyle();
    }
}