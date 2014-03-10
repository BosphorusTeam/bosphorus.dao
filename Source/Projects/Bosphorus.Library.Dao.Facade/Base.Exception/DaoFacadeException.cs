using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Bosphorus.Library.Dao.Core.Common;

namespace Bosphorus.Library.Dao.Facade.Base.Exception
{
    public class DaoFacadeException: DaoException
    {
        public DaoFacadeException()
        {
        }

        public DaoFacadeException(string message)
            : base(message)
        {
        }

        protected DaoFacadeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DaoFacadeException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
