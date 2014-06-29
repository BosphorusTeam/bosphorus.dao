using System;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Generic : AbstractExecutionItemList
    {
        public Generic(IDao<Account> genericDao)
        {
            this.Add("Generic - GetAll", () => genericDao.GetAll());
            this.Add("Generic - GetById", () => genericDao.GetById(Guid.Empty));
            this.Add("Generic - GetByIdSingle", () => genericDao.GetByIdSingle(Guid.Empty));
            this.Add("Generic - GetByQuery", () => genericDao.GetByQuery("select * from XAccount"));
            this.Add("Generic - GetByNamedQuery", () => genericDao.GetByNamedQuery("AccountNamedQuery"));
        }
    }
}
