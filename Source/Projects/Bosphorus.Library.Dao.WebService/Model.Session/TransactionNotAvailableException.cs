using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.WebService.Base.Exception;

namespace Bosphorus.Library.Dao.WebService.Model.Session
{
    class TransactionNotAvailableException: WebServiceException
    {
        private const string EXCEPTION_MESSAGE = "Transaction is not available for web service dao";

        public TransactionNotAvailableException()
            : base(EXCEPTION_MESSAGE)
        {
        }
    }
}
