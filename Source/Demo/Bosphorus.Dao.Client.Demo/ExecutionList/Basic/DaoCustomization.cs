using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class DaoCustomization: AbstractExecutionItemList
    {
        public DaoCustomization(IDao<Bank> genericDao, IBankDao customizedDao)
            : base("Basic - DaoCustomization")
        {
            Add("Starts With (Extension)", () => genericDao.GetStartsWithByExtension("Ci"));
            Add("Starts With (Inheritace)", () => customizedDao.GetStartsWithByInheritance(customizedDao.SessionManager.OpenSession(), "Ci"));
        }
    }
}
