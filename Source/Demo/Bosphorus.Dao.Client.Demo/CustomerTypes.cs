using Bosphorus.Common.Clr.Enum;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo
{
    public class CustomerTypes: IEnumerationRegistration<CustomerType>
    {
        public static readonly CustomerType Bireysel = new CustomerType { Id = 1, Name = "Bireysel" };
        public static readonly CustomerType Kurumsal = new CustomerType { Id = 2, Name = "Kurumsal" };
        public static readonly CustomerType[] Hepsi = {Bireysel, Kurumsal};
    }
}
