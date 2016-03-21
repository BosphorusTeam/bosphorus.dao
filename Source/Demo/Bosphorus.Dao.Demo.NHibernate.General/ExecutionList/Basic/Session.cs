using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly ISessionProvider sessionProvider;

        public Session(IWindsorContainer container, IDao<Bank> bankDao, IDao<LogModel> logDao, ISessionProvider sessionProvider) 
            : base(container)
        {
            this.bankDao = bankDao;
            this.logDao = logDao;
            this.sessionProvider = sessionProvider;
        }

        public IEnumerable<Bank> Default()
        {
            IEnumerable<Bank> result = bankDao.Query().Where(x => x.Name.StartsWith("Ci"));
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logDao.GetAll();
            return result;
        }

        public IQueryable<Bank> SessionProvider_Current()
        {
            ISession session = sessionProvider.Current();
            IQueryable<Bank> result = bankDao.GetAll(session);
            return result;
        }

        public IList<Bank> SessionProvider_New()
        {
            ISession session = sessionProvider.Open(sessionScope: SessionScope.Thread);
            IList<Bank> result = bankDao.GetAll(session).ToList();
            session.Flush();
            sessionProvider.Close(sessionScope: SessionScope.Thread);
            return result;
        }
    }
}
