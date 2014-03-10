using System;
using System.Collections.Generic;
using System.Text;
using Demo.WebService.Core.Model.Domain;
using Bosphorus.Library.Dao.Core.Model.Dao;

namespace Demo.WebService.Service.Dal.Model.Dao
{
    public class BankDao : BaseDao<Bank>
    {
        protected override object GetIndex(Bank entity)
        {
            return entity.No;
        }
    }
}
