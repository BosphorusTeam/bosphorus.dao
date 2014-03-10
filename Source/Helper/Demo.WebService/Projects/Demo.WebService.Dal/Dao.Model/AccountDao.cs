using System;
using System.Collections.Generic;
using System.Text;
using Demo.WebService.Core.Model.Domain;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using Bosphorus.Library.Dao.WebService.Model.Dao;
using Bosphorus.Library.Dao.WebService.Model.Dao.Configuration;
using Bosphorus.Library.Dao.WebService.Model.Common;

namespace Demo.WebService.Dal.Dao.Model
{
    public class AccountDao: GenericWebServiceProxyDao<Account>
    {
        public AccountDao(IWebServiceDaoConfigurator webServiceDaoConfigurator)
            : base(webServiceDaoConfigurator)
        {
        }

        [SoapDocumentMethodAttribute(Default.Namespace + "GetByBla", RequestNamespace = Default.Namespace, ResponseNamespace = Default.Namespace, Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public List<Account> GetByBla(int no, string name)
        {
            return Proxy.CallMethod<List<Account>>("GetByBla", no, name);
        }
    }
}
