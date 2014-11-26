using System.Collections.Generic;

namespace Bosphorus.Dao.Demo.Common.Business.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerTypeName { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
