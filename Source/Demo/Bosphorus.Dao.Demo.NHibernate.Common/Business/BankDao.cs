using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Dao;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business
{
    public class BankDao : NHibernateDao<Bank>, IBankDao
    {
        public IQueryable<Bank> GetStartsWithByInheritance(ISession session, string name)
        {
            IQueryable<Bank> result = Query(session).Where(bank => bank.Name.StartsWith(name));
            return result;
        }
    }
}
