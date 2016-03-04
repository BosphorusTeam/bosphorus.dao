using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly ISession logSession;

        public Session(IWindsorContainer container, IDao<Bank> bankDao, IDao<LogModel> logDao, ISessionProvider sessionProvider) 
            : base(container)
        {
            this.bankDao = bankDao;
            this.logDao = logDao;
            this.logSession = sessionProvider.Open(aliasName: "Log");
        }

        public IEnumerable<Bank> Default()
        {
            IEnumerable<Bank> result = bankDao.Query().Where(x => x.Name.StartsWith("Ci"));
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logDao.GetAll(logSession);
            return result;
        }
    }
}
