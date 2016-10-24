using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo
{
    public static class BankDaoExtensions
    {
        public static IQueryable<Bank> GetStartsWithByExtension(this IDao<Bank> extended, string startsWith)
        {
            IQueryable<Bank> result = extended.Query().Where(bank => bank.Name.StartsWith(startsWith));
            return result;
        }
    }
}
