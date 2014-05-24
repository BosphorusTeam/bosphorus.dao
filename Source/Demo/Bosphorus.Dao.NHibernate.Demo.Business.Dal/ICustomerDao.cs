using System.Collections.Generic;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal
{
    public interface ICustomerDao: IDao<Customer>
    {
        IList<Customer> GetBy(ISession session, string name);
    }
}
