using System;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class NonGeneric : AbstractExecutionItemList
    {
        public NonGeneric(IDao nonGenericDao)
        {
            nonGenericDao.GetById<Account, Guid>(Guid.Empty);


            this.Add("NonGeneric - GetAll", () => nonGenericDao.GetAll<Account>());
            this.Add("NonGeneric - GetById", () => nonGenericDao.GetById<Account, Guid>(Guid.Empty));
            this.Add("NonGeneric - GetByIdSingle", () => nonGenericDao.GetByIdSingle<Account, Guid>(Guid.Empty));
            this.Add("NonGeneric - GetByQuery", () => nonGenericDao.GetByQuery<Account>("select * from XAccount"));
            this.Add("NonGeneric - GetByNamedQuery", () => nonGenericDao.GetByNamedQuery<Account>("AccountNamedQuery"));

        }
    }
}
