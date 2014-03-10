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
using Bosphorus.Library.Facade;
using Bosphorus.Library.Facades;
using Demo.WebService.Service.Dal.Model.Dao;
using System.Collections.Generic;
using Bosphorus.Library.Dao.WebService.Model.Common;

namespace Demo.WebService.Service
{
    /// <summary>
    /// Summary description for AccountDaoService
    /// </summary>
    [WebService(Namespace = "http://Bosphorus.Library.Dao/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class AccountDaoService : GenericDaoService<Account>
    {
        static AccountDaoService()
        {
            Repository.Domain.Live.Loader.Load("Demo.WebService.Service.Dal.DaoFactory.xml", Assembly.Load("Demo.WebService.Service.Dal"));
        }

        [WebMethod]
        public Account[] GetByBla(int no, string name)
        {
            IList<Account> list = Repository.Domain.Live<Account>.As<AccountDao>().GetByBla(no, name);
            return ServiceConvertor.ToArray<Account>(list);
        }
    }
}
