using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Core.Session;
using Bosphorus.Library.Dao.Facade.Decoration.Base;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public partial class ThreadedDecoratorDao<TModel> : ThreadedDecoratorXao<TModel>, IDao<TModel>
    {
        private ISession session;
        public delegate void ListReturnCallback<TReturnType>(IList<TReturnType> result);
        public delegate void ModelReturnCallback(TModel result);
        public delegate void ModelsReturnCallback(IEnumerable<TModel> result);
        public delegate void VoidReturnCallback();

        public new IDao<TModel> Decorated
        {
            get { return (IDao<TModel>)base.Decorated; }
            set { base.Decorated = value; }
        }

        public ISession Session
        {
            get
            {
                if (session == null)
                    session = (ISession)Decorated.Session.Clone();
                return session;
            }
            set { session = value; }
        }

        protected override void GetAllOnThread(ListReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            base.GetAllOnThread(callback);
            Decorated.Session = currentSession;
        }

        protected override void GetByCriteriaOnThread(object[] criterions, ListReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            base.GetByCriteriaOnThread(criterions, callback);
            Decorated.Session = currentSession;
        }

        public TModel GetById<TId>(TId id)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByIdOnThread<TId>(id, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void GetByIdOnThread<TId>(TId id, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.GetById<TId>(id));
            Decorated.Session = currentSession;
        }

        public IList<TModel> GetByNamedQuery(string queryName, params object[] parameters)
        {
            ListReturnCallback callback = GetCallback<ListReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByNamedQueryOnThread(queryName, parameters, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void GetByNamedQueryOnThread(string queryName, object[] parameters, ListReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.GetByNamedQuery(queryName, parameters));
            Decorated.Session = currentSession;
        }

        public IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            ListReturnCallback<TReturnType> callback = GetCallback<ListReturnCallback<TReturnType>>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByNamedQueryOnThread<TReturnType>(queryName, parameters, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void GetByNamedQueryOnThread<TReturnType>(string queryName, object[] parameters, ListReturnCallback<TReturnType> callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.GetByNamedQuery<TReturnType>(queryName, parameters));
            Decorated.Session = currentSession;
        }

        public IList<TModel> GetByQuery(string queryString, params object[] parameters)
        {
            ListReturnCallback callback = GetCallback<ListReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByQueryOnThread(queryString, parameters, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void GetByQueryOnThread(string queryString, object[] parameters, ListReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.GetByQuery(queryString, parameters));
            Decorated.Session = currentSession;
        }

        public IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            ListReturnCallback<TReturnType> callback = GetCallback<ListReturnCallback<TReturnType>>();
            ThreadStart threadStart = new ThreadStart(delegate() { GetByQueryOnThread<TReturnType>(queryString, parameters, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void GetByQueryOnThread<TReturnType>(string queryString, object[] parameters, ListReturnCallback<TReturnType> callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.GetByQuery<TReturnType>(queryString, parameters));
            Decorated.Session = currentSession;
        }

        public TModel LoadById(object id)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { LoadByIdOnThread(id, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void LoadByIdOnThread(object id, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.LoadById(id));
            Decorated.Session = currentSession;
        }

        public TModel LoadById<TId>(TId id)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { LoadByIdOnThread<TId>(id, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void LoadByIdOnThread<TId>(TId id, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.LoadById<TId>(id));
            Decorated.Session = currentSession;
        }

        public TModel Save(TModel entity)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { SaveOnThread(entity, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void SaveOnThread(TModel entity, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.Save(entity));
            Decorated.Session = currentSession;
        }

        public IEnumerable<TModel> Save(IEnumerable<TModel> entityList)
        {
            ModelsReturnCallback callback = GetCallback<ModelsReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { SaveOnThread(entityList, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void SaveOnThread(IEnumerable<TModel> entityList, ModelsReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.Save(entityList));
            Decorated.Session = currentSession;
        }

        public TModel SaveOrUpdate(TModel entity)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { SaveOrUpdateOnThread(entity, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void SaveOrUpdateOnThread(TModel entity, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.SaveOrUpdate(entity));
            Decorated.Session = currentSession;
        }

        public IEnumerable<TModel> SaveOrUpdate(IEnumerable<TModel> entityList)
        {
            ModelsReturnCallback callback = GetCallback<ModelsReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { SaveOrUpdateOnThread(entityList, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void SaveOrUpdateOnThread(IEnumerable<TModel> entityList, ModelsReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.SaveOrUpdate(entityList));
            Decorated.Session = currentSession;
        }

        public TModel Update(TModel entity)
        {
            ModelReturnCallback callback = GetCallback<ModelReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { UpdateOnThread(entity, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return default(TModel);
        }

        protected virtual void UpdateOnThread(TModel entity, ModelReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.Update(entity));
            Decorated.Session = currentSession;
        }

        public IEnumerable<TModel> Update(IEnumerable<TModel> entityList)
        {
            ModelsReturnCallback callback = GetCallback<ModelsReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { UpdateOnThread(entityList, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return null;
        }

        protected virtual void UpdateOnThread(IEnumerable<TModel> entityList, ModelsReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            callback(Decorated.Update(entityList));
            Decorated.Session = currentSession;
        }

        public void Delete(TModel entity)
        {
            VoidReturnCallback callback = GetCallback<VoidReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { DeleteOnThread(entity, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        protected virtual void DeleteOnThread(TModel entity, VoidReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            Decorated.Delete(entity);
            callback();
            Decorated.Session = currentSession;
        }

        public void Delete(IEnumerable<TModel> entityList)
        {
            VoidReturnCallback callback = GetCallback<VoidReturnCallback>();
            ThreadStart threadStart = new ThreadStart(delegate() { DeleteOnThread(entityList, callback); });
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        protected virtual void DeleteOnThread(IEnumerable<TModel> entityList, VoidReturnCallback callback)
        {
            ISession currentSession = Decorated.Session;
            Decorated.Session = Session;
            Decorated.Delete(entityList);
            callback();
            Decorated.Session = currentSession;
        }
    }
}
