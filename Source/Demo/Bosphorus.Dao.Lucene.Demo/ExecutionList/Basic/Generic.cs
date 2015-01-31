using System.Collections.Generic;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Basic
{
    public class Generic : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<CustomerType> customerTypeDao;

        public Generic(IResultTransformer resultTransformer, IDao<Bank> bankDao, IDao<CustomerType> customerTypeDao) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
            this.customerTypeDao = customerTypeDao;
        }

        public Bank Insert_Bank()
        {
            Bank bank = new Bank();
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
