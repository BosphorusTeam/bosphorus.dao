using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class Session : MethodExecutionItemList
    {
        private readonly IDao<Bank> defaultSessionDao;
        private readonly IDao<LogModel> logSessionDao;

        public Session(IResultTransformer resultTransformer, IDao<Bank> defaultSessionDao, IDao<LogModel> logSessionDao) 
            : base(resultTransformer)
        {
            this.defaultSessionDao = defaultSessionDao;
            this.logSessionDao = logSessionDao;
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
            //TODO:
            ISession session = null; //defaultSessionDao.SessionManager.OpenSession();
            IQueryable<Bank> result = defaultSessionDao.GetById(session, 1);
            return result;
        }
    }
}
