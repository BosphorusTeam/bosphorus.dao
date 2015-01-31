using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly ISessionProvider<NHibernateStatelessSession> logSessionProvider;

        public Session(IResultTransformer resultTransformer, IDao<Bank> bankDao, IDao<LogModel> logDao, ISessionProviderFactory<NHibernateStatelessSession> sessionProviderFactory) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
            this.logDao = logDao;
            logSessionProvider = sessionProviderFactory.Build("LOG");
        }

        public IEnumerable<Bank> Default()
        {
            //IEnumerable<Bank> result = bankDao.GetAll();
            IEnumerable<Bank> result = bankDao.Query().Where(x => x.Name.StartsWith("Ci"));
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logDao.GetAll();
            return result;
        }

        public IQueryable<LogModel> FromParameter()
        {
            IQueryable<LogModel> result = logDao.GetAll(logSessionProvider.Current());
            return result;
        }
    }
}
