using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.NHibernate.Model;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Bosphorus.Library.Dao.RI.Entities;
using Bosphorus.Library.Dao.RI.Dao.NHibernate.Session;
using NHibernate;
using Bosphorus.Library.Dao.NHibernate.Model.Dao;
using Bosphorus.Library.Dao.NHibernate.Model.Session;

namespace Bosphorus.Library.Dao.RI.Dao
{
    public class IncomingActualTransactionDao : AbstractNHibernateDao<IncomingActualTransaction>, IIncomingActualTransactionDao
    {
        public IncomingActualTransactionDao(NHibernateSessionAdapter session)
            : base(session)
        {
        }
    }

    public interface IIncomingActualTransactionDao : IDao<IncomingActualTransaction>
    {
    }
}
