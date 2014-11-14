using Bosphorus.Dao.Core.Session.LifeStyle;
using Bosphorus.Dao.NHibernate.Session;
using Castle.Core;

namespace Bosphorus.Dao.Client.Demo.Configuration.Business
{
    public class SessionLifeStyleProvider : AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle()
        {
            return LifestyleType.Singleton;
        }
    }
}
