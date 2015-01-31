using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Core.Session;
using Bosphorus.Library.Dao.Facade.Facade.Base;
using Bosphorus.Library.Dao.Core.Base.Model;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public partial class FacadeDaoBase<TContainerScope> : FacadeXaoBase<TContainerScope> where
        TContainerScope : FacadeDaoBase<TContainerScope>
    {
        private static IDao<object> InternalComponent
        {
            get { return (IDao<object>) Container.Resolve(typeof(IDao<object>)); }
        }

        public static ISession GetSession()
        {
            return (ISession) Container.Resolve(typeof(ISession));
        }

        public static ISession GetSession(string sessionName)
        {
            return (ISession) Container.Resolve(typeof(ISession), sessionName);
        }

        public static IList<object> GetAll()
        {
            return InternalComponent.GetAll();
        }

        public static object GetById<TId>(TId id)
        {
            return InternalComponent.GetById<TId>(id);
        }

        public static IList<object> GetByCriteria(params object[] criterions)
        {
            return InternalComponent.GetByCriteria(criterions);
        }

        public static IList<object> GetByNamedQuery(string queryName, params object[] parameters)
        {
            return InternalComponent.GetByNamedQuery(queryName, parameters);
        }

        public static IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            return InternalComponent.GetByNamedQuery<TReturnType>(queryName, parameters);
        }

        public static IList<object> GetByQuery(string queryString, params object[] parameters)
        {
            return InternalComponent.GetByQuery(queryString, parameters);
        }

        public static IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            return InternalComponent.GetByQuery<TReturnType>(queryString, parameters);
        }

        public static object LoadById(object id)
        {
            return InternalComponent.LoadById(id);
        }

        public static object LoadById<TId>(TId id)
        {
            return InternalComponent.LoadById<TId>(id);
        }

        public static object Save(object entity)
        {
            return InternalComponent.Save(entity);
        }

        public static object[] Save(params object[] entities)
        {
            Save((IEnumerable<object>)entities);
            return entities;
        }

        public static IEnumerable<object> Save(IEnumerable<object> entityList)
        {
            return InternalComponent.Save(entityList);
        }

        public static object SaveOrUpdate(object entity)
        {
            return InternalComponent.SaveOrUpdate(entity);
        }

        public static object[] SaveOrUpdate(params object[] entities)
        {
            SaveOrUpdate((IEnumerable<object>)entities);
            return entities;
        }

        public static IEnumerable<object> SaveOrUpdate(IEnumerable<object> entityList)
        {
            return InternalComponent.SaveOrUpdate(entityList);
        }

        public static object Update(object entity)
        {
            return InternalComponent.Update(entity);
        }

        public static object[] Update(params object[] entities)
        {
            Update((IEnumerable<object>)entities);
            return entities;
        }

        public static IEnumerable<object> Update(IEnumerable<object> entityList)
        {
            return InternalComponent.Update(entityList);
        }

        public static void Delete(object entity)
        {
            InternalComponent.Delete(entity);
        }

        public static void Delete(params object[] entities)
        {
            InternalComponent.Delete((IEnumerable<object>)entities);
        }

        public static void Delete(IEnumerable<object> entityList)
        {
            InternalComponent.Delete(entityList);
        }
    }

    public partial class FacadeDaoBase<TContainerScope, TComponentProvider, TComponent, TModel> : FacadeXaoBase<TContainerScope, TComponentProvider, TComponent, TModel>
        where TComponent : IDao<TModel>
        where TContainerScope : FacadeDaoBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        public static TModel GetById<TId>(TId id)
        {
            return InternalComponent.GetById<TId>(id);
        }

        public static IList<TModel> GetByNamedQuery(string queryName, params object[] parameters)
        {
            return InternalComponent.GetByNamedQuery(queryName, parameters);
        }

        public static IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            return InternalComponent.GetByNamedQuery<TReturnType>(queryName, parameters);
        }

        public static IList<TModel> GetByQuery(string queryString, params object[] parameters)
        {
            return InternalComponent.GetByQuery(queryString, parameters);
        }

        public static IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            return InternalComponent.GetByQuery<TReturnType>(queryString, parameters);
        }

        public static TModel LoadById(object id)
        {
            return InternalComponent.LoadById(id);
        }

        public static TModel LoadById<TId>(TId id)
        {
            return InternalComponent.LoadById<TId>(id);
        }

        public static TModel Save(TModel entity)
        {
            return InternalComponent.Save(entity);
        }

        public static TModel[] Save(params TModel[] entities)
        {
            Save((IEnumerable<TModel>)entities);
            return entities;
        }

        public static IEnumerable<TModel> Save(IEnumerable<TModel> entityList)
        {
            return InternalComponent.Save(entityList);
        }

        public static TModel SaveOrUpdate(TModel entity)
        {
            return InternalComponent.SaveOrUpdate(entity);
        }

        public static TModel[] SaveOrUpdate(params TModel[] entities)
        {
            SaveOrUpdate((IEnumerable<TModel>)entities);
            return entities;
        }

        public static IEnumerable<TModel> SaveOrUpdate(IEnumerable<TModel> entityList)
        {
            return InternalComponent.SaveOrUpdate(entityList);
        }

        public static TModel Update(TModel entity)
        {
            return InternalComponent.Update(entity);
        }

        public static TModel[] Update(params TModel[] entities)
        {
            Update((IEnumerable<TModel>)entities);
            return entities;
        }

        public static IEnumerable<TModel> Update(IEnumerable<TModel> entityList)
        {
            return InternalComponent.Update(entityList);
        }

        public static void Delete(TModel entity)
        {
            InternalComponent.Delete(entity);
        }

        public static void Delete(params TModel[] entities)
        {
            InternalComponent.Delete((IEnumerable<TModel>)entities);
        }

        public static void Delete(IEnumerable<TModel> entityList)
        {
            InternalComponent.Delete(entityList);
        }
    }
}
