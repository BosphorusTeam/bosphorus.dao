using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.RI.Dao.NHibernate.Session;

namespace Bosphorus.Library.Dao.RI.Dao
{
    public class DaoFactory
    {
        public static IAccountDao AccountDao()
        {
            return new AccountDao(SessionFactory.CashFlowSession);
        }

        public static IAccountDao TempAccountDao()
        {
            return new AccountDao(SessionFactory.TempSession);
        }

        public static IIncomingActualTransactionDao IncomingActualTransactionDao()
        {
            return new IncomingActualTransactionDao(SessionFactory.CashFlowSession);
        }

        public static IIncomingActualTransactionDao TempIncomingActualTransactionDao()
        {
            return new IncomingActualTransactionDao(SessionFactory.TempSession);
        }
    }
}
