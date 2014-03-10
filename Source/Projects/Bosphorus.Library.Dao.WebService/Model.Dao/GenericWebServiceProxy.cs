using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using Bosphorus.Library.Dao.WebService.Model.Common;

namespace Bosphorus.Library.Dao.WebService.Model.Dao
{
    [WebServiceBindingAttribute(Name = "GenericDaoService", Namespace = Default.Namespace)]
    public class GenericWebServiceProxy<TModel> : SoapHttpClientProtocol
    {
        public object CallMethod(string methodName, params object[] parameters)
        {
            object[] results = Invoke(methodName, parameters ?? new object[0]);
            return (results[0]);
        }

        public TReturnType CallMethod<TReturnType>(string methodName, params object[] parameters)
        {
            return (TReturnType)CallMethod(methodName, parameters);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetAll", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<TModel> GetAll()
        {
            return CallMethod<List<TModel>>("GetAll");
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetByCriteria", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<TModel> GetByCriteria(params object[] criterions)
        {
            return CallMethod<List<TModel>>("GetByCriteria", criterions);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetById", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public TModel GetById(object id)
        {
            return CallMethod<TModel>("GetById", id);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetByNamedQuery", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public object[] GetByNamedQuery(string queryName, params object[] parameters)
        {
            return CallMethod<object[]>("GetByNamedQuery", queryName, parameters);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetByQuery", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public object[] GetByQuery(string queryString, params object[] parameters)
        {
            return CallMethod<object[]>("GetByQuery", queryString, parameters);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "LoadById", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public TModel LoadById(object id)
        {
            return CallMethod<TModel>("LoadById", id);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "Save", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public TModel Save(TModel entity)
        {
            return CallMethod<TModel>("Save", entity);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "SaveArray", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<TModel> SaveArray(List<TModel> entities)
        {
            return CallMethod<List<TModel>>("SaveArray", entities);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "SaveOrUpdate", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public TModel SaveOrUpdate(TModel entity)
        {
            return CallMethod<TModel>("SaveOrUpdate", entity);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "SaveOrUpdateArray", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<TModel> SaveOrUpdateArray(List<TModel> entities)
        {
            return CallMethod<List<TModel>>("SaveOrUpdateArray", entities);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "Update", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public TModel Update(TModel entity)
        {
            return CallMethod<TModel>("Update", entity);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "UpdateArray", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<TModel> UpdateArray(List<TModel> entities)
        {
            return CallMethod<List<TModel>>("UpdateArray", entities);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "Delete", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public void Delete(TModel entity)
        {
            CallMethod("Delete", entity);
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "DeleteArray", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteArray(List<TModel> entities)
        {
            CallMethod<List<TModel>>("DeleteArray", entities);
        }
    }
}
