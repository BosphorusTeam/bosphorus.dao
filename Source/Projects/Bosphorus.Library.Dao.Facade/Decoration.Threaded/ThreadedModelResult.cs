using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedModelResult<TModel>: ThreadedResult
    {
        public ThreadedModelResult()
        {
        }

        public ThreadedModelResult(TModel result)
            : this()
        {
            OnThreadCompleted(result);
        }

        internal void OnThreadCompleted(TModel result)
        {
            OnThreadCompleted((object)result);
        }

        public new TModel Result
        {
            get { return (TModel)result; }
        }
    }
}
