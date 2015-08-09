using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly NHibernateStatelessSession statelessSession;

        public Session(IResultTransformer resultTransformer, IDao<Bank> bankDao, IDao<LogModel> logDao, ISessionProvider sessionProvider) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
            this.logDao = logDao;
            this.statelessSession = sessionProvider.Open<NHibernateStatelessSession>();
        }

        public IEnumerable<Bank> Default()
        {
            IEnumerable<Bank> result = bankDao.Query().Where(x => x.Name.StartsWith("Ci"));
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logDao.GetAll(statelessSession);
            return result;
        }
    }
}
