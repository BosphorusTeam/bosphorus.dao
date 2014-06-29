using Bosphorus.Common.Clr.Enum;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo
{
    public class CustomerTypes: IEnumerationRegistration<CustomerType>
    {
        public static CustomerType Bireysel = new CustomerType { Id = 1, Name = "Bireysel" };
        public static CustomerType Kurumsal = new CustomerType { Id = 2, Name = "Kurumsal" };
        public static CustomerType[] Hepsi = {Bireysel, Kurumsal};
    }
}
