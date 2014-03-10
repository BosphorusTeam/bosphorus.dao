using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Facade.Base.Exception;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class IncompitableDelegateException : DaoFacadeException
    {
        private const string EXCEPTION_MESSAGE = "Callback delegate is not compatible";

        public IncompitableDelegateException()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public IncompitableDelegateException(Type callbackType, Type expectedCallbackType)
            : base(string.Format("{0}: [Callback: {1}, Expected Callback: {2}]", EXCEPTION_MESSAGE, callbackType, expectedCallbackType))
        {
        }
    }
}
