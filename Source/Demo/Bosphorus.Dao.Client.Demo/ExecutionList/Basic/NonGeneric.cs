using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class NonGeneric : AbstractExecutionItemList
    {
        public NonGeneric(IDao nonGenericDao)
            : base("Basic - NonGeneric")
        {
            this.Add("GetAll", () => nonGenericDao.GetAll<Bank>());
            this.Add("GetById", () => nonGenericDao.GetById<Bank, int>(1));
            this.Add("GetByIdSingle", () => nonGenericDao.GetByIdSingle<Bank, int>(1));
            this.Add("GetByQuery", () => nonGenericDao.GetByQuery<Bank>("select * from XBank"));
            //FIXME: Hatalı çalışıyor
            this.Add("GetByNamedQuery", () => nonGenericDao.GetByNamedQuery<Bank>("BankNamedQuery"));

            this.Add("Insert", () => nonGenericDao.Insert(BankBuilder.Default.Build()));
            this.Add("Update", () => nonGenericDao.Update(BankBuilder.FromDatabase(1).WithRandomNo().Build()));
            this.Add("Delete", () => nonGenericDao.DeleteReturned(BankBuilder.FromDatabase(1).Build()));
        }
    }
}
