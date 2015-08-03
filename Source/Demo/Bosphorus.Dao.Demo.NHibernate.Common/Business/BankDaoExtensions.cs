using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business
{
    public static class BankDaoExtensions
    {
        public static IQueryable<Bank> GetStartsWithByExtension(this IDao<Bank> extended, string startsWith)
        {
            //TODO:
            IQueryable<Bank> result = extended.Query(null).Where(bank => bank.Name.StartsWith(startsWith));
            return result;
        }
    }
}
