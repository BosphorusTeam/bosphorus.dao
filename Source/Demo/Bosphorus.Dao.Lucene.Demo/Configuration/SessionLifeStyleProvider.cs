using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.Core;

namespace Bosphorus.Dao.Lucene.Demo.Configuration
{
    public class SessionLifeStyleProvider : AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle()
        {
            return LifestyleType.Singleton;
        }
    }
}
