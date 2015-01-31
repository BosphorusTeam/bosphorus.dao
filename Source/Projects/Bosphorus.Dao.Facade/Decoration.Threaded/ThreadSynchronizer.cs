using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public static class ThreadSynchronizer
    {
        public static void Synchronize(params IThreadedResult[] threadResults)
        {
            ThreadSynchronizer.Synchronize((object[])threadResults);
        }

        public static void Synchronize(params object[] threadResults)
        {
            WaitHandle[] waitHandles = new WaitHandle[threadResults.Length];
            for (int i = 0; i < threadResults.Length; i++)
            {
                waitHandles[i] = ((IThreadedResult)threadResults[i]).WaitHandle;
            }

            ApartmentState apartmentState = Thread.CurrentThread.GetApartmentState();
            if (apartmentState == ApartmentState.MTA)
            {
                WaitHandle.WaitAll(waitHandles);
                return;
            }

            if (apartmentState == ApartmentState.STA)
            {
                foreach (WaitHandle myWaitHandle in waitHandles)
                {
                    WaitHandle.WaitAny(new WaitHandle[] { myWaitHandle });
                }
                return;
            }

            throw new UnhandledThreadApartmentState(apartmentState);
        }
    }
}
