using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class Generic : AbstractExecutionItemList
    {
        public Generic(IDao<Bank> dao)
            : base("Basic - Generic")
        {
            this.Add("GetAll", () => dao.GetAll());
            this.Add("GetById", () => dao.GetById(1));
            this.Add("GetByIdSingle", () => dao.GetByIdSingle(1));
            this.Add("GetByQuery", () => dao.GetByQuery("select * from XBank"));
            this.Add("GetByNamedQuery", () => dao.GetByNamedQuery("BankNamedQueryPositional", new { No = "0092" }));
            this.Add("GetByNamedQueryFromProcedure", () => dao.GetByNamedQuery("BankNamedQueryFromProcedure", new { Parameter1 = "Deneme", Parameter2 = "Deneme2" }));

            
            this.Add("Insert", () => dao.Insert(BankBuilder.Default.Build()));
            this.Add("Update", () => dao.Update(BankBuilder.FromDatabase(1).WithRandomNo().Build()));
            this.Add("Delete", () => dao.DeleteReturned(BankBuilder.FromDatabase(1).Build()));
        }
    }
}
