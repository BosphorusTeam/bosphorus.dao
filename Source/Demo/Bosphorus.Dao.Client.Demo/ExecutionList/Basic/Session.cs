using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class Session : AbstractExecutionItemList
    {
        public Session(IDao<Bank> defaultSessionDao, IDao<LogModel> logSessionDao)
            : base("Basic - Session")
        {
            this.Add("Default", () => defaultSessionDao.GetAll());
            this.Add("Log", () => logSessionDao.GetAll());
            this.Add("From Parameter", () => defaultSessionDao.GetById(defaultSessionDao.SessionProvider.OpenSession(), 1));
        }
    }
}
