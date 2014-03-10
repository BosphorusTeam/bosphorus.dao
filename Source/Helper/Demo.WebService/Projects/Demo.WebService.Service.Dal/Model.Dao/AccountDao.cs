using System;
using System.Collections.Generic;
using System.Text;
using Demo.WebService.Core.Model.Domain;
using Bosphorus.Library.Dao.Core.Model.Dao;

namespace Demo.WebService.Service.Dal.Model.Dao
{
    public class AccountDao : BaseDao<Account>
    {
        protected override object GetIndex(Account entity)
        {
            return entity.Guid;
        }

        public IList<Account> GetByBla(int no, string name)
        {
            Account account = new Account();
            account.No = no;
            account.Name = name;

            return new Account[] { account };
        }
    }
}
