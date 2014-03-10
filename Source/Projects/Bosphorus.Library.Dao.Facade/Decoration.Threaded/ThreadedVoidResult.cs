using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedVoidResult<TModel>: ThreadedResult
    {
        public ThreadedVoidResult()
        {
        }

        public ThreadedVoidResult(bool setWaitHandle)
            : this()
        {
            if (setWaitHandle)
                OnThreadCompleted();
        }

        internal void OnThreadCompleted()
        {
            waitHandle.Set();
        }
    }
}
