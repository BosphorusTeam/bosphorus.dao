using Castle.Core;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public interface ISessionLifeStyleProvider
    {
        LifestyleType GetLifestyle();
    }
}
