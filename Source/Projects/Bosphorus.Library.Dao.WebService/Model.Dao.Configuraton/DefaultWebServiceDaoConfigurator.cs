using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;

namespace Bosphorus.Library.Dao.WebService.Model.Dao.Configuration
{
    public class DefaultWebServiceDaoConfigurator: IWebServiceDaoConfigurator
    {
        private readonly string webServiceRootUrl;

        public DefaultWebServiceDaoConfigurator(string webServiceRootUrl)
        {
            this.webServiceRootUrl = webServiceRootUrl;
        }

        public virtual void Configure(SoapHttpClientProtocol webServiceClient, string webServiceAlias)
        {
            string postFix = "DaoService";
            string webServiceClientUrl = string.Format("{0}/{1}{2}.asmx", webServiceRootUrl, webServiceAlias, postFix);
            webServiceClient.Url = webServiceClientUrl;            
        }
    }
}
