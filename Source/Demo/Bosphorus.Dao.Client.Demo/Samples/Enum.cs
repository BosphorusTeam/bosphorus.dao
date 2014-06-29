using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.LinQ.In;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Enum: AbstractExecutionItemList
    {
        public Enum(IDao<Customer> customerDao, IDao<CustomerType> customerTypeDao)
        {
            //customerTypeDao.Insert(new CustomerType() { Name = "Bireysel" });
            CustomerType fromDatabaseCustomerType = customerTypeDao.Query().First(type => type.Name == "Bireysel");
            CustomerType inMemoryCustomerType = new CustomerType {Id = 1};

            Add("Enum - Where (From Database)", () => customerDao.Query().Where(customer => customer.CustomerType == fromDatabaseCustomerType));
            Add("Enum - Where (From Memory)", () => customerDao.Query().Where(customer => customer.CustomerType == inMemoryCustomerType));
            Add("Enum - Where (EnumerationRegistration)", () => customerDao.Query().Where(customer => customer.CustomerType == CustomerTypes.Bireysel));
            Add("Enum - Where In (EnumerationRegistration)", () => customerDao.Query().Where(customer => customer.CustomerType.In(CustomerTypes.Hepsi)));
            Add("Enum - Where Contains (EnumerationRegistration)", () => customerDao.Query().Where(customer => CustomerTypes.Hepsi.Contains(customer.CustomerType)));
        }
    }
}
