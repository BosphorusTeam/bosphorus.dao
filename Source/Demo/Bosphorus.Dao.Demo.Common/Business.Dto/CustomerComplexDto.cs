using System.Collections.Generic;

namespace Bosphorus.Dao.Demo.Common.Business.Dto
{
    public class CustomerComplexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerTypeName { get; set; }
        public IList<AccountDto> Accounts { get; set; }
    }
}
