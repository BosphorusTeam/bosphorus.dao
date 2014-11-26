using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business
{
    public interface IBankDao: IDao<Bank>
    {
        IQueryable<Bank> GetStartsWithByInheritance(ISession session, string name);
    }
}
