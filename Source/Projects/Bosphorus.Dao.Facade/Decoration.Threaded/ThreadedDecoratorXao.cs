using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Facade.Decoration.Base;
using Bosphorus.Library.Dao.Core.Base.Model;
using System.Threading;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public class ThreadedDecoratorXao<TModel>: XaoDecoratorBase<TModel>
    {
        private object callback;
        public delegate void ListReturnCallback(IList<TModel> result);

        public object Callback
        {
            set { callback = value; }
        }

        protected TCallback GetCallback<TCallback>()
        {
            if (!(callback is TCallback))
                throw new IncompitableDelegateException(callback.GetType(), typeof(TCallback));

            return (TCallback)callback;
        }

        public override IList<TModel> GetAll()
        {
            ListReturnCallback callback = GetCallback<ListReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetAllOnThread(callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();
            return null;
        }

        protected virtual void GetAllOnThread(ListReturnCallback callback)
        {
            callback(Decorated.GetAll());
        }

        public override IList<TModel> GetByCriteria(params object[] criterions)
        {
            ListReturnCallback callback = GetCallback<ListReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByCriteriaOnThread(criterions, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();
            return null;
        }

        protected virtual void GetByCriteriaOnThread(object[] criterions, ListReturnCallback callback)
        {
            callback(Decorated.GetByCriteria(criterions));
        }
    }
}
