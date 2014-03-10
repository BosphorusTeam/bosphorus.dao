using System;
using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedModelsResult<TModel> : ThreadedResult
    {
        public ThreadedModelsResult()
        {
        }

        public ThreadedModelsResult(params TModel[] result)
            : this()
        {
            OnThreadCompleted(result);
        }

        internal void OnThreadCompleted(TModel[] result)
        {
            OnThreadCompleted((object)result);
        }

        public new TModel[] Result
        {
            get { return (TModel[])result; }
        }
    }
}
