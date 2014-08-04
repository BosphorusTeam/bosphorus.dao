using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Common.Mapper.Core;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dto;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using NHibernate.Linq;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Extension
{
    public class AutoMap : MethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<Account> accountDao;
        private readonly IDao<Customer> customerDao;
        private readonly IMapper mapper;

        public AutoMap(IResultTransformer resultTransformer, IDao<Bank> bankDao, IDao<Account> accountDao, IDao<Customer> customerDao, IMapper mapper) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
            this.accountDao = accountDao;
            this.customerDao = customerDao;
            this.mapper = mapper;
        }

        public IQueryable<BankDto> ToDto_Basic_Simple()
        {
            IQueryable<BankDto> result = 
                from bank in bankDao.Query() 
                select mapper.Map<BankDto>(bank);

            return result;
        }

        public IQueryable<AccountDto> ToDto_Basic_Lookup()
        {
            IQueryable<AccountDto> result =
                from account in accountDao.Query().Fetch(x => x.Customer).ThenFetch(x => x.CustomerType)
                select mapper.Map<AccountDto>(account);

            return result;
        }

        public IQueryable<CustomerDto> ToDto_Basic_LookupAndChildren()
        {
            IQueryable<CustomerDto> result =
                from customer in customerDao.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType)
                select mapper.Map<CustomerDto>(customer);

            return result;
        }

        public IQueryable<CustomerComplexDto> ToDto_Complex()
        {
            IQueryable<CustomerComplexDto> result =
                from customer in customerDao.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType)
                select mapper.Map<CustomerComplexDto>(customer);

            return result;
        }

        public IQueryable<Bank> FromDto_Basic_Simple()
        {
            Bank model = BankBuilder.FromDatabase().Evict().Build();
            BankDto sampleDto = mapper.Map<BankDto>(model);
            IQueryable<BankDto> dtoList = new List<BankDto> { sampleDto }.AsQueryable();

            IQueryable<Bank> result = 
                from dto in dtoList
                select mapper.Map<Bank>(dto);

            return result;
        }

        //TODO: DtoBuilder'ları yap.
        public IQueryable<Account> FromDto_Basic_Lookup()
        {
            Account model = AccountBuilder.FromDatabaseWithChildren().Evict().Build();
            AccountDto sampleDto = mapper.Map<AccountDto>(model);
            IQueryable<AccountDto> dtoList = new List<AccountDto> { sampleDto }.AsQueryable();

            IQueryable<Account> result =
                from dto in dtoList
                select mapper.Map<Account>(dto);

            return result;
        }

        public IQueryable<Customer> FromDto_Complex()
        {
            Customer model = CustomerBuilder.FromDatabaseWithChildren().Evict().Build();
            CustomerComplexDto sampleDto = mapper.Map<CustomerComplexDto>(model);
            IQueryable<CustomerComplexDto> dtoList = new List<CustomerComplexDto> { sampleDto }.AsQueryable();


            IQueryable<Customer> result =
                from dto in dtoList
                select mapper.Map<Customer>(dto);

            return result;
        }

       
    }
}
