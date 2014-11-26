using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.Core;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Business
{
    public class SessionLifeStyleProvider : AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle()
        {
            return LifestyleType.Singleton;
        }
    }
}
