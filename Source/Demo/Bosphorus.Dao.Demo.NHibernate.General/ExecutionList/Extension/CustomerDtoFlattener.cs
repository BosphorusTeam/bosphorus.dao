using Bosphorus.Dao.Common.Mapper.Flattener;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Business.Dto;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Extension
{
    public class CustomerDtoFlattener: IFlattener<Customer, CustomerDto>
    {
        public CustomerDto Map(Customer source)
        {
            return new CustomerDto();
        }
    }
}
