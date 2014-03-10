using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Base.Exception;
using System.Runtime.Serialization;

namespace Bosphorus.Library.Dao.WebService.Base.Exception
{
    public class WebServiceException: DaoException
    {
        public WebServiceException()
        {
        }

        public WebServiceException(string message)
            : base(message)
        {
        }

        protected WebServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public WebServiceException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
