using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal
{
    public class BankDao : NHibernateDao<Bank>, IBankDao
    {
        public BankDao(ISessionManagerFactory sessionManagerFactory)
            : base(sessionManagerFactory)
        {
        }

        public IQueryable<Bank> GetStartsWithByInheritance(ISession session, string name)
        {
            IQueryable<Bank> result = Query(session).Where(bank => bank.Name.StartsWith(name));
            return result;
        }
    }
}
