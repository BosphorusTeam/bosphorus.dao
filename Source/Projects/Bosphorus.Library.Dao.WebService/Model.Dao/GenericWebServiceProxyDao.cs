using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Web.Services.Description;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Bosphorus.Library.Dao.WebService.Model.Dao.Configuration;
using Bosphorus.Library.Dao.Core.Model.Session;
using Bosphorus.Library.Dao.WebService.Model.Session;
using Bosphorus.Library.Dao.WebService.Model.Common;


namespace Bosphorus.Library.Dao.WebService.Model.Dao
{
    public class GenericWebServiceProxyDao<TModel> : IDao<TModel>
    {
        private ISession session;
        private GenericWebServiceProxy<TModel> genericWebServiceProxy;

        public GenericWebServiceProxyDao()
        {
            session = new HttpSessionAdapter();
            genericWebServiceProxy = new GenericWebServiceProxy<TModel>();
        }

        public GenericWebServiceProxyDao(string webServiceUrl)
            : this()
        {
            genericWebServiceProxy.Url = webServiceUrl;
        }

        public GenericWebServiceProxyDao(IWebServiceDaoConfigurator webServiceDaoConfigurator)
            : this()
        {
            string webServiceAlias = typeof(TModel).Name;
            webServiceDaoConfigurator.Configure(genericWebServiceProxy, webServiceAlias);
        }

        protected GenericWebServiceProxy<TModel> Proxy
        {
            get { return genericWebServiceProxy; }
        }

        public Bosphorus.Library.Dao.Core.Model.Session.ISession Session
        {
            get { return session; }
            set { session = value; }
        }

        public IList<TModel> GetAll()
        {
            return genericWebServiceProxy.GetAll();
        }

        public IList<TModel> GetByCriteria(params object[] criterions)
        {
            return genericWebServiceProxy.GetByCriteria(criterions);
        }

        public TModel GetById<TId>(TId id)
        {
            return genericWebServiceProxy.GetById((object)id);
        }

        public TModel GetById(object id)
        {
            return genericWebServiceProxy.GetById(id);
        }

        public IList<TModel> GetByNamedQuery(string queryName, params object[] parameters)
        {
            object[] modelArray = genericWebServiceProxy.GetByNamedQuery(queryName, parameters);
            return ServiceConvertor.ToList<TModel>(modelArray);
        }

        public IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            object[] modelArray = genericWebServiceProxy.GetByNamedQuery(queryName, parameters);
            return ServiceConvertor.ToList<TReturnType>(modelArray);
        }

        public IList<TModel> GetByQuery(string queryString, params object[] parameters)
        {
            object[] modelArray = genericWebServiceProxy.GetByQuery(queryString, parameters);
            return ServiceConvertor.ToList<TModel>(modelArray);
        }

        public IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            object[] modelArray = genericWebServiceProxy.GetByQuery(queryString, parameters);
            return ServiceConvertor.ToList<TReturnType>(modelArray);
        }

        public TModel LoadById(object id)
        {
            return genericWebServiceProxy.LoadById(id);
        }

        public TModel LoadById<TId>(TId id)
        {
            return genericWebServiceProxy.LoadById((object)id);
        }

        public TModel Save(TModel entity)
        {
            return genericWebServiceProxy.Save(entity);
        }

        public IEnumerable<TModel> Save(IEnumerable<TModel> entities)
        {
            List<TModel> entityList = ServiceConvertor.ToList<TModel>(entities);
            return genericWebServiceProxy.SaveArray(entityList);
        }

        public TModel SaveOrUpdate(TModel entity)
        {
            return genericWebServiceProxy.SaveOrUpdate(entity);
        }

        public IEnumerable<TModel> SaveOrUpdate(IEnumerable<TModel> entities)
        {
            List<TModel> entityList = ServiceConvertor.ToList<TModel>(entities);
            return genericWebServiceProxy.SaveOrUpdateArray(entityList);
        }

        public TModel Update(TModel entity)
        {
            return genericWebServiceProxy.Update(entity);
        }

        public IEnumerable<TModel> Update(IEnumerable<TModel> entities)
        {
            List<TModel> entityList = ServiceConvertor.ToList<TModel>(entities);
            return genericWebServiceProxy.UpdateArray(entityList);
        }

        public void Delete(TModel entity)
        {
            genericWebServiceProxy.Delete(entity);
        }

        public void Delete(IEnumerable<TModel> entities)
        {
            List<TModel> entityList = ServiceConvertor.ToList<TModel>(entities);
            genericWebServiceProxy.DeleteArray(entityList);
        }
    }
}
