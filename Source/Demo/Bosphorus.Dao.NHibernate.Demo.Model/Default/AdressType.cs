using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.Dao.NHibernate.Demo.Model.Default
{
    public class AdressType: Enumeration, IEnumerationRegistration<AdressType>
    {
        public static AdressType Home = new AdressType {Id = 1, Name = "Home"};
        public static AdressType Work = new AdressType { Id = 2, Name = "Work" };
    }
}
