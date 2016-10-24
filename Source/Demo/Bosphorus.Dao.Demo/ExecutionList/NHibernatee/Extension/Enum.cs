using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Builder;
using Bosphorus.Dao.Demo.Common.Business;
using Castle.Windsor;
using FluentNHibernate.Utils;
using NHibernate.Criterion;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Extension
{
    public class Enum: AbstractMethodExecutionItemList
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<CustomerType> customerTypeDao;

        public Enum(IWindsorContainer container, IDao<Customer> customerDao, IDao<CustomerType> customerTypeDao) 
            : base(container)
        {
            this.customerDao = customerDao;
            this.customerTypeDao = customerTypeDao;
        }

        public IQueryable<Customer> Where_FromDatabase()
        {
            CustomerType customerType = CustomerTypeBuilder.FromDatabase().Build();
            IQueryable<Customer> result = customerDao.Query().Where(customer => customer.CustomerType == customerType);
            return result;
        }

        public IQueryable<Customer> Where_FromMemory()
        {
            CustomerType customerType = new CustomerType { Id = 1 };
            IQueryable<Customer> result = customerDao.Query().Where(customer => customer.CustomerType == customerType);
            return result;
        }

        public IQueryable<Customer> Where_EnumerationRegistration()
        {
            IQueryable<Customer> result = customerDao.Query().Where(customer => customer.CustomerType == CustomerTypes.Bireysel);
            return result;
        }

        public IQueryable<Customer> WhereIn_FromDatabase()
        {
            List<CustomerType> customerTypes = customerTypeDao.Query().ToList();
            IQueryable<Customer> result = customerDao.Query().Where(customer => customer.CustomerType.IsIn(customerTypes));
            return result;
        }

        public IQueryable<Customer> WhereIn_EnumerationRegistration()
        {
            IQueryable<Customer> result = customerDao.Query().Where(customer => customer.CustomerType.In(CustomerTypes.Hepsi));
            return result;
        }

        public IQueryable<Customer> WhereContains_EnumerationRegistration()
        {
            IQueryable<Customer> result = customerDao.Query().Where(customer => CustomerTypes.Hepsi.Contains(customer.CustomerType));
            return result;
        }
    }
}
