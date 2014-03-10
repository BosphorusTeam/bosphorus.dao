using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Demo.WebService.Core.Model.Domain;
using System.Reflection;
using Bosphorus.Library.Dao.WebService.Model.WebService;
using Bosphorus.Library.Dao.Facade;

namespace Demo.WebService.Service
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://Bosphorus.Library.Dao/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class CustomerDaoService : GenericDaoService<Customer>
    {
        static CustomerDaoService()
        {
            //Repository.Domain.Live.Loader.Load(Assembly.Load("Demo.WebService.Service.Dal"), "DaoFactory.xml");
        }
    }
}
