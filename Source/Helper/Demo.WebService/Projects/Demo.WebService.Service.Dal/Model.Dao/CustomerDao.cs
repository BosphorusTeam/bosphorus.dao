using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Demo.WebService.Core.Model.Domain;

namespace Demo.WebService.Service.Dal.Model.Dao
{
    public class CustomerDao : BaseDao<Customer>
    {
        protected override object GetIndex(Customer entity)
        {
            return entity.No;
        }
    }
}
