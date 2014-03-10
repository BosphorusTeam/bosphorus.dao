using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedListResult<TModel>: ThreadedResult
    {
        public ThreadedListResult()
        {
        }

        public ThreadedListResult(IList<TModel> result)
            : this()
        {
            OnThreadCompleted(result);
        }

        internal void OnThreadCompleted(IList<TModel> result)
        {
            OnThreadCompleted((object)result);
        }

        public new IList<TModel> Result
        {
            get { return (IList<TModel>)result; }
        }
    }
}
