using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Extension
{
    public class LinqProvider : MethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;

        public LinqProvider(IResultTransformer resultTransformer, IDao<Bank> bankDao) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
        }

        public IQueryable<Bank> Simple()
        {
            IQueryable<Bank> result = from model in bankDao.Query()
                where model.No == "1"
                select model;

            return result;
        }
    }
}
