using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedResult: IThreadedResult
    {
        protected object result;
        protected ManualResetEvent waitHandle;

        public ThreadedResult()
        {
            waitHandle = new ManualResetEvent(false);
        }

        internal void OnThreadCompleted(object result)
        {
            this.result = result;
            waitHandle.Set();
        }

        public WaitHandle WaitHandle
        {
            get { return waitHandle; }
        }
	
        public object Result
        {
            get { return result; }
        }
	
    }
}
