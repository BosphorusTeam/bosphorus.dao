using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bosphorus.Library.Dao.Facade.Base.Exception;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class UnhandledThreadApartmentState: DaoFacadeException
    {
        private const string EXCEPTION_MESSAGE = "Unhandled Apartment State";

        public UnhandledThreadApartmentState()
            : base(EXCEPTION_MESSAGE)
        {
        }

        public UnhandledThreadApartmentState(ApartmentState apartmentState)
            : base(string.Format("{0}: [ApartmentState: {1}]", EXCEPTION_MESSAGE, apartmentState))
        {
        }
    }
}
