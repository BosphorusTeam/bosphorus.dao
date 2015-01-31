using System;
using Castle.Core;

namespace Bosphorus.Dao.Core.Session.LifeStyle
{
    public class DefaultSessionLifeStyleProvider: AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle(Type sessionType, string sessionAlias)
        {
            return LifestyleType.Thread;
        }
    }
}
