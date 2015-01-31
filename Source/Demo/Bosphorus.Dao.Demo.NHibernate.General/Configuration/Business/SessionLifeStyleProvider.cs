using System;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.Core;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Business
{
    public class SessionLifeStyleProvider : AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle(Type sessionType, string sessionAlias)
        {
            return LifestyleType.Singleton;
        }
    }
}
