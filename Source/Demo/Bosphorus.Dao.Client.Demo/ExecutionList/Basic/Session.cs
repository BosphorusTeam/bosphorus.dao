using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
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

        public IQueryable<Bank> FromParameter()
        {
            ISessionManager sessionManager = nHibernateSessionManagerFactory.Build("LOG");
            IQueryable<Bank> result = defaultSessionDao.GetById(sessionManager.Current, 1);
            return result;
        }
    }
}
