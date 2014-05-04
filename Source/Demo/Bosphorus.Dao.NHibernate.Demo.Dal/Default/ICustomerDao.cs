using System.Collections.Generic;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Demo.Model.Default;

namespace Bosphorus.Dao.NHibernate.Demo.Dal.Default
{
    public interface ICustomerDao: IDao<Customer>
    {
        IList<Customer> GetBy(ISession session, string name);
    }
}
