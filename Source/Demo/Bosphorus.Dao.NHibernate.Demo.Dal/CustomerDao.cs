using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate.Linq;

namespace Bosphorus.Dao.NHibernate.Demo.Dal
{
    public class CustomerDao: NHibernateDao<Customer>, ICustomerDao
    {
        public CustomerDao(ISessionProviderFactory sessionProviderFactory)
            : base(sessionProviderFactory)
        {
        }

        public IList<Customer> GetBy(ISession session, string name)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(session);
            IQueryable<Customer> customers = from customer in nativeSession.Query<Customer>()
                                             where customer.Name == name
                                             select customer;

            List<Customer> customerList = customers.ToList();
            return customerList;
        }
    }
}
