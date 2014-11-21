using Castle.Core;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class SessionLifeStyleProvider: AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle()
        {
            return LifestyleType.Thread;
        }
    }
}
