using System.Collections.Generic;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Basic
{
    public class Generic : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<CustomerType> customerTypeDao;

        public Generic(IWindsorContainer container, IDao<Bank> bankDao, IDao<CustomerType> customerTypeDao) 
            : base(container)
        {
            this.bankDao = bankDao;
            this.customerTypeDao = customerTypeDao;
        }

        public Bank Insert_Bank()
        {
            Bank bank = new Bank();
            bank.Id = 1;
            bank.No = "1";
            bank.Name = "Citibank";

            Bank result = bankDao.Insert(bank);
            return result;
        }

        public IEnumerable<Bank> Insert_10_000_Bank()
        {
            int count = 10000;
            IList<Bank> bankList = new List<Bank>(count);
            for (int i = 0; i < count; i++)
            {
                Bank bank = new Bank();
                bank.Id = i;
                bank.No = i.ToString();
                bank.Name = "Citibank " + i;

                bankList.Add(bank);
            }

            IEnumerable<Bank> result = bankDao.Insert(bankList);
            return result;
        }

        public CustomerType Insert_CustomerType()
        {
            CustomerType customerType = new CustomerType();
            customerType.Id = 1;
            customerType.Name = "Bireysel";

            customerTypeDao.Insert(customerType);
            return customerType;
        }

    }

}
