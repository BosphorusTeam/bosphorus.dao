using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class DaoCustomization: AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> genericDao;

        public DaoCustomization(IResultTransformer resultTransformer, IDao<Bank> genericDao) 
            : base(resultTransformer)
        {
            this.genericDao = genericDao;
        }

        public IQueryable<Bank> StartsWith_ByExtension()
        {
            IQueryable<Bank> result = genericDao.GetStartsWithByExtension("Ci");
            return result;
        }
    }
}
