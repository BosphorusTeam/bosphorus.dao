using Bosphorus.Common.Api.Enum.Registration;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public class CustomerTypes: IEnumerationRegistration<CustomerType>
    {
        public static readonly CustomerType Bireysel = new CustomerType { Id = 1, Name = "Bireysel" };
        public static readonly CustomerType Kurumsal = new CustomerType { Id = 2, Name = "Kurumsal" };
        public static readonly CustomerType[] Hepsi = {Bireysel, Kurumsal};
    }
}
