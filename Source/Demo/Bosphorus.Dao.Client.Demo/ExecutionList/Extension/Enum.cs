using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bosphorus.Common.Clr.Enum;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.LinQ.In;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Extension
{
    public class Enum: AbstractExecutionItemList
    {
        public Enum(IDao<Customer> customerDao, IDao<CustomerType> customerTypeDao)
            : base("Enum")
        {
            Add("Where (From Database)", () => customerDao.Query().Where(customer => customer.CustomerType == GetCustomerTypefromDatabase(customerTypeDao)));
            Add("Where (From Memory)", () => customerDao.Query().Where(customer => customer.CustomerType == GetCustomerTypeInMemory()));
            Add("Where (EnumerationRegistration)", () => customerDao.Query().Where(customer => customer.CustomerType == CustomerTypes.Bireysel));
            Add("Where In (From Database)", () => customerDao.Query().Where(customer => customer.CustomerType.In(GetCustomerTypesFromDatabase(customerTypeDao))));
            Add("Where In (EnumerationRegistration)", () => customerDao.Query().Where(customer => customer.CustomerType.In(CustomerTypes.Hepsi)));
            Add("Where Contains (EnumerationRegistration)", () => customerDao.Query().Where(customer => CustomerTypes.Hepsi.Contains(customer.CustomerType)));
        }

        private Enumeration<int> GetCustomerTypeInMemory()
        {
            CustomerType result = new CustomerType { Id = 1 };
            return result;
        }

        private Enumeration<int> GetCustomerTypefromDatabase(IDao<CustomerType> customerTypeDao)
        {
            customerTypeDao.Insert(new CustomerType() { Name = "Bireysel" });
            CustomerType result = customerTypeDao.Query().First(type => type.Name == "Bireysel");
            return result;
        }

        private IEnumerable<CustomerType> GetCustomerTypesFromDatabase(IDao<CustomerType> customerTypeDao)
        {
            IQueryable<CustomerType> customerTypes = customerTypeDao.Query();
            return customerTypes;
        }
    }
}
