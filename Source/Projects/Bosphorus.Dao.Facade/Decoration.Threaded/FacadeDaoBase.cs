using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Facade.Facade.Base;

namespace Bosphorus.Library.Dao.Facade.Decoration.Threaded
{
    public partial class FacadeDaoBase<TContainerScope> : FacadeBase<TContainerScope>
        where TContainerScope : FacadeBase<TContainerScope>
    {
    }

    public partial class FacadeDaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeBase<TContainerScope, TComponentProvider, TComponent>
        where TComponent : ThreadedDecoratorDao<TModel>
        where TContainerScope : FacadeBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        public static IDao<TModel> CallbackTo(ThreadedDecoratorDao<TModel>.ListReturnCallback callback)
        {
            return CallbackTo((object)callback);
        }

        public static IDao<TModel> CallbackTo<TReturnType>(ThreadedDecoratorDao<TModel>.ListReturnCallback<TReturnType> callback)
        {
            return CallbackTo((object)callback);
        }

        public static IDao<TModel> CallbackTo(ThreadedDecoratorDao<TModel>.ModelReturnCallback callback)
        {
            return CallbackTo((object)callback);
        }

        public static IDao<TModel> CallbackTo(object callback)
        {
            InternalComponent.Callback = callback;
            return InternalComponent;
        }

        public static ThreadedListResult<TModel> GetAll()
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetAll();
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> GetById<TId>(TId id)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetById<TId>(id);
            return threadedResult;
        }

        public static ThreadedListResult<TModel> GetByCriteria(params object[] criterions)
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByCriteria(criterions);
            return threadedResult;
        }

        public static ThreadedListResult<TModel> GetByNamedQuery(string queryName, params object[] parameters)
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByNamedQuery(queryName, parameters);
            return threadedResult;
        }

        public static ThreadedListResult<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            ThreadedListResult<TReturnType> threadedResult = new ThreadedListResult<TReturnType>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByNamedQuery<TReturnType>(queryName, parameters);
            return threadedResult;
        }

        public static ThreadedListResult<TModel> GetByQuery(string queryString, params object[] parameters)
        {
            ThreadedListResult<TModel> threadedResult = new ThreadedListResult<TModel>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByQuery(queryString, parameters);
            return threadedResult;
        }

        public static ThreadedListResult<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            ThreadedListResult<TReturnType> threadedResult = new ThreadedListResult<TReturnType>();
            ThreadedDecoratorDao<TModel>.ListReturnCallback callback = new ThreadedDecoratorDao<TModel>.ListReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.GetByQuery<TReturnType>(queryString, parameters);
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> LoadById(object id)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.LoadById(id);
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> LoadById<TId>(TId id)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.LoadById<TId>(id);
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> Save(TModel entity)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Save(entity);
            return threadedResult;
        }

        public static ThreadedModelsResult<TModel> Save(params TModel[] entityList)
        {
            ThreadedModelsResult<TModel> threadedResult = new ThreadedModelsResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelsReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelsReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Save(entityList);
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> SaveOrUpdate(TModel entity)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.SaveOrUpdate(entity);
            return threadedResult;
        }

        public static ThreadedModelsResult<TModel> SaveOrUpdate(params TModel[] entityList)
        {
            ThreadedModelsResult<TModel> threadedResult = new ThreadedModelsResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelsReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelsReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.SaveOrUpdate(entityList);
            return threadedResult;
        }

        public static ThreadedModelResult<TModel> Update(TModel entity)
        {
            ThreadedModelResult<TModel> threadedResult = new ThreadedModelResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Update(entity);
            return threadedResult;
        }

        public static ThreadedModelsResult<TModel> Update(params TModel[] entityList)
        {
            ThreadedModelsResult<TModel> threadedResult = new ThreadedModelsResult<TModel>();
            ThreadedDecoratorDao<TModel>.ModelsReturnCallback callback = new ThreadedDecoratorDao<TModel>.ModelsReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Update(entityList);
            return threadedResult;
        }

        public static ThreadedVoidResult<TModel> Delete(TModel entity)
        {
            ThreadedVoidResult<TModel> threadedResult = new ThreadedVoidResult<TModel>();
            ThreadedDecoratorDao<TModel>.VoidReturnCallback callback = new ThreadedDecoratorDao<TModel>.VoidReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Delete(entity);
            return threadedResult;
        }

        public static ThreadedVoidResult<TModel> Delete(params TModel[] entityList)
        {
            ThreadedVoidResult<TModel> threadedResult = new ThreadedVoidResult<TModel>();
            ThreadedDecoratorDao<TModel>.VoidReturnCallback callback = new ThreadedDecoratorDao<TModel>.VoidReturnCallback(threadedResult.OnThreadCompleted);
            InternalComponent.Callback = callback;
            InternalComponent.Delete(entityList);
            return threadedResult;
        }
    }
}
