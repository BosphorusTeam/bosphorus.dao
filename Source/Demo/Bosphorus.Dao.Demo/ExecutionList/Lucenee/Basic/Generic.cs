using System;
using System.Collections.Generic;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.Lucenee.Basic
{
    public class Generic : AbstractMethodExecutionItemList
    {
        private readonly IDao<StatisticModel> statisticModelDao;
        private readonly IDao<LogModel> logModelDao;

        public Generic(IWindsorContainer container, IDao<StatisticModel> statisticModelDao, IDao<LogModel> logModelDao) 
            : base(container)
        {
            this.statisticModelDao = statisticModelDao;
            this.logModelDao = logModelDao;
        }

        public StatisticModel Insert_StatisticModel()
        {
            var model = new StatisticModel();
            model.Id = 1;
            model.Elapsed = 100;

            var result = statisticModelDao.Insert(model);
            return result;
        }

        public IEnumerable<StatisticModel> Insert_10_000_StatisticModel()
        {
            int count = 10000;
            IList<StatisticModel> statisticModelList = new List<StatisticModel>(count);
            for (int i = 0; i < count; i++)
            {
                StatisticModel statisticModel = new StatisticModel();
                statisticModel.Id = i;
                statisticModel.Elapsed = i;

                statisticModelList.Add(statisticModel);
            }

            IEnumerable<StatisticModel> result = statisticModelDao.Insert(statisticModelList);
            return result;
        }

        public LogModel Insert_Log()
        {
            var model = new LogModel();
            model.Id = Guid.NewGuid();
            model.Message = "Deneme";

            var result = logModelDao.Insert(model);
            return result;
        }

    }

}
