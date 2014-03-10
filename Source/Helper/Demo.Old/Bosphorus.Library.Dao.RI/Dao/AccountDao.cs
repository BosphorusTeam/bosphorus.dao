using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.NHibernate.Model;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Bosphorus.Library.Dao.RI.Entities;
using Bosphorus.Library.Dao.RI.Dao.NHibernate.Session;
using Bosphorus.Library.Dao.NHibernate.Model.Dao;
using Bosphorus.Library.Dao.NHibernate.Model.Session;

namespace Bosphorus.Library.Dao.RI.Dao
{
    public class AccountDao : AbstractNHibernateDao<Account>, IAccountDao
    {
        public AccountDao(NHibernateSessionAdapter session)
            : base(session)
        {
        }
    }

    public interface IAccountDao : IDao<Account>
    {
    }
}
