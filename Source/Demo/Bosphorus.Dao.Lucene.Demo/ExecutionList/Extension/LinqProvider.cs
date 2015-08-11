using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Extension
{
    public class LinqProvider : AbstractMethodExecutionItemList
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
                where model.Name.StartsWith("Citi")
                select model;

            return result.Take(100);
        }
    }
}
