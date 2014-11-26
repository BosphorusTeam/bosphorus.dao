using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> defaultSessionDao;
        private readonly IDao<LogModel> logSessionDao;
        private readonly INHibernateSessionManagerFactory nHibernateSessionManagerFactory;

        public Session(IResultTransformer resultTransformer, IDao<Bank> defaultSessionDao, IDao<LogModel> logSessionDao, INHibernateSessionManagerFactory nHibernateSessionManagerFactory) 
            : base(resultTransformer)
        {
            this.defaultSessionDao = defaultSessionDao;
            this.logSessionDao = logSessionDao;
            this.nHibernateSessionManagerFactory = nHibernateSessionManagerFactory;
        }

        public IEnumerable<Bank> Default()
        {
            IEnumerable<Bank> result = defaultSessionDao.GetAll();
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logSessionDao.GetAll();
            return result;
        }

        public IQueryable<LogModel> FromParameter()
        {
            ISessionManager sessionManager = nHibernateSessionManagerFactory.Build("LOG");
            IQueryable<LogModel> result = logSessionDao.GetAll(sessionManager.Current);
            return result;
        }
    }
}
