using System;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Generic : AbstractExecutionItemList
    {
        public Generic(IDao<Account> genericDao)
            : base("Generic")
        {
            this.Add("GetAll", () => genericDao.GetAll());
            this.Add("GetById", () => genericDao.GetById(Guid.Empty));
            this.Add("GetByIdSingle", () => genericDao.GetByIdSingle(Guid.Empty));
            this.Add("GetByQuery", () => genericDao.GetByQuery("select * from XAccount"));
            this.Add("GetByNamedQuery", () => genericDao.GetByNamedQuery("AccountNamedQuery"));
        }
    }
}
