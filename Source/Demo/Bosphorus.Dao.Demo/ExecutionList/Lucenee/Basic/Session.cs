using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Lucene.Session;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.Lucenee.Basic
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<StatisticModel> statisticModelDao;
        private readonly IDao<LogModel> logDao;
        private readonly ISession logSession;

        public Session(IWindsorContainer container, IDao<StatisticModel> statisticModelDao, IDao<LogModel> logDao, ISessionProvider sessionProvider) 
            : base(container)
        {
            this.statisticModelDao = statisticModelDao;
            this.logDao = logDao;
            this.logSession = sessionProvider.Open<LuceneSession>(aliasName: "LuceneLog");
        }

        public IEnumerable<StatisticModel> Default()
        {
            IEnumerable<StatisticModel> result = statisticModelDao.Query().Where(x => x.Elapsed.ToString().StartsWith("1"));
            return result;
        }

        public IEnumerable<LogModel> Log()
        {
            IEnumerable<LogModel> result = logDao.GetAll(logSession);
            return result;
        }
    }
}
