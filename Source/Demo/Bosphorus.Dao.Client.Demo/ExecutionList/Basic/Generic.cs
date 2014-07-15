using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class Generic : AbstractExecutionItemList
    {
        public Generic(IDao<Bank> genericDao)
            : base("Basic - Generic")
        {
            this.Add("GetAll", () => genericDao.GetAll());
            this.Add("GetById", () => genericDao.GetById(1));
            this.Add("GetByIdSingle", () => genericDao.GetByIdSingle(1));
            this.Add("GetByQuery", () => genericDao.GetByQuery("select * from XBank"));
            //FIXME: Hatalı çalışıyor
            this.Add("GetByNamedQuery", () => genericDao.GetByNamedQuery("BankNamedQuery"));

            this.Add("Insert", () => genericDao.Insert(BankBuilder.Default.Build()));
            this.Add("Update", () => genericDao.Update(BankBuilder.FromDatabase(1).WithRandomNo().Build()));
            this.Add("Delete", () => genericDao.DeleteReturned(BankBuilder.FromDatabase(1).Build()));
        }
    }
}
