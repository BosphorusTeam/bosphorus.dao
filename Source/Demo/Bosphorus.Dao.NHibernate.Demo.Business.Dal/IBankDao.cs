using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal
{
    public interface IBankDao: IDao<Bank>
    {
        IQueryable<Bank> GetStartsWithByInheritance(ISession session, string name);
    }
}
