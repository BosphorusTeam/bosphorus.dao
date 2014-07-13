using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Hbm : AbstractExecutionItemList
    {
        public Hbm(IDao<IMPORTCARGOINFOSERVICE> legancyDao)
            : base("Hbm")
        {
            this.Add("Custom Query", () => legancyDao.GetCustomQuery1());
        }
    }
}
