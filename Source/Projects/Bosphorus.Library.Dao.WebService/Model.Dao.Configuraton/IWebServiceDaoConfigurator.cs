using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;

namespace Bosphorus.Library.Dao.WebService.Model.Dao.Configuration
{
    public interface IWebServiceDaoConfigurator
    {
        void Configure(SoapHttpClientProtocol webServiceClient, string webServiceAlias);
    }
}
