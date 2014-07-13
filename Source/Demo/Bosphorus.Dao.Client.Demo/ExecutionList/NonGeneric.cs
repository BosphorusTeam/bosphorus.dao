using System;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class NonGeneric : AbstractExecutionItemList
    {
        public NonGeneric(IDao nonGenericDao)
            : base("NonGeneric")
        {
            nonGenericDao.GetById<Account, int>(1);

            this.Add("GetAll", () => nonGenericDao.GetAll<Account>());
            this.Add("GetById", () => nonGenericDao.GetById<Account, Guid>(Guid.Empty));
            this.Add("GetByIdSingle", () => nonGenericDao.GetByIdSingle<Account, Guid>(Guid.Empty));
            this.Add("GetByQuery", () => nonGenericDao.GetByQuery<Account>("select * from XAccount"));
            this.Add("GetByNamedQuery", () => nonGenericDao.GetByNamedQuery<Account>("AccountNamedQuery"));

        }
    }
}
