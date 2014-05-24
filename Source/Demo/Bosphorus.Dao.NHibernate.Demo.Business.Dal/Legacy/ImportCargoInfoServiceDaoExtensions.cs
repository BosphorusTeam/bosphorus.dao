using System.Collections.Generic;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy
{
    public static class ImportCargoInfoServiceDaoExtensions
    {
        public static IList<IMPORTCARGOINFOSERVICE> GetCustomQuery1(this IDao<IMPORTCARGOINFOSERVICE> extended)
        {
            using (ISession session = extended.SessionProvider.OpenSession())
            {
                NHibernateSession nHibernateSession = (NHibernateSession)session;
                global::NHibernate.ISession innerSession = nHibernateSession.InnerSession;
                IList<IMPORTCARGOINFOSERVICE> result = innerSession.GetNamedQuery("CustomQuery1").List<IMPORTCARGOINFOSERVICE>();
                return result;
            }
        }
    }
}
