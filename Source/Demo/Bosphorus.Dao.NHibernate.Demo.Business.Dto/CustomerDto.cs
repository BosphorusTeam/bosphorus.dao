using System.Collections.Generic;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerTypeName { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
