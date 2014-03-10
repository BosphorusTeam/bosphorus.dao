using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public interface IThreadedResult
    {
        WaitHandle WaitHandle
        {
            get;
        }
    }
}
