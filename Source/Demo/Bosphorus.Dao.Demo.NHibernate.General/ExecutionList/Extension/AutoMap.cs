using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bosphorus.Dao.Common.Mapper.Core;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Business.Dto;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Demo.Runner.Executable;
using Castle.Windsor;
using NHibernate.Linq;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Extension
{
    public class AutoMap : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<Account> accountDao;
        private readonly IDao<Customer> customerDao;
        private readonly GenericMapper genericMapper;

        public AutoMap(IWindsorContainer container, IDao<Bank> bankDao, IDao<Account> accountDao, IDao<Customer> customerDao, GenericMapper genericMapper)
            : base(container)
        {
            this.bankDao = bankDao;
            this.accountDao = accountDao;
            this.customerDao = customerDao;
            this.genericMapper = genericMapper;
        }

        public IQueryable<BankDto> ToDto_Basic_Simple()
        {
            IQueryable<BankDto> result = 
                from bank in bankDao.Query() 
                select genericMapper.Flatten<Bank, BankDto>(bank);

            return result;
        }

        public IQueryable<AccountDto> ToDto_Basic_Lookup()
        {
            IQueryable<AccountDto> result =
                from account in accountDao.Query().Fetch(x => x.Customer).ThenFetch(x => x.CustomerType)
                select genericMapper.Flatten<Account, AccountDto>(account);

            return result;
        }

        public IQueryable<CustomerDto> ToDto_Basic_LookupAndChildren()
        {
            IQueryable<CustomerDto> result =
                from customer in customerDao.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType)
                select genericMapper.Flatten<Customer, CustomerDto>(customer);

            return result;
        }

        public IQueryable<CustomerDto> ToDto_Basic_NullCheck()
        {
            IQueryable<Customer> result =
                from customer in customerDao.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType)
                select customer;

            List<Customer> resultList = result.ToList();
            resultList.ForEach(customer => customer.Accounts = null);

            IQueryable<CustomerDto> customerDtos = resultList.AsQueryable().Select(customer => genericMapper.Flatten<Customer, CustomerDto>(customer));
            return customerDtos;
        }

        public IQueryable<CustomerComplexDto> ToDto_Complex()
        {
            IQueryable<CustomerComplexDto> result =
                from customer in customerDao.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType)
                select genericMapper.Flatten<Customer, CustomerComplexDto>(customer);

            return result;
        }

        public IQueryable<Bank> FromDto_Basic_Simple()
        {
            Bank model = BankBuilder.FromDatabase().Evict().Build();
            BankDto sampleDto = genericMapper.Flatten<Bank, BankDto>(model);
            IQueryable<BankDto> dtoList = new List<BankDto> { sampleDto }.AsQueryable();

            IQueryable<Bank> result = 
                from dto in dtoList
                select genericMapper.Unflatten<BankDto, Bank>(dto);

            return result;
        }

        //TODO: DtoBuilder'ları yap.
        public IQueryable<Account> FromDto_Basic_Lookup()
        {
            Account model = AccountBuilder.FromDatabaseWithChildren().Evict().Build();
            AccountDto sampleDto = genericMapper.Flatten<Account, AccountDto>(model);
            IQueryable<AccountDto> dtoList = new List<AccountDto> { sampleDto }.AsQueryable();

            IQueryable<Account> result =
                from dto in dtoList
                select genericMapper.Unflatten<AccountDto, Account>(dto);

            return result;
        }

        public IQueryable<Customer> FromDto_Complex()
        {
            Customer model = CustomerBuilder.FromDatabaseWithChildren().Evict().Build();
            CustomerComplexDto sampleDto = genericMapper.Flatten<Customer, CustomerComplexDto>(model);
            IQueryable<CustomerComplexDto> dtoList = new List<CustomerComplexDto> { sampleDto }.AsQueryable();


            IQueryable<Customer> result =
                from dto in dtoList
                select genericMapper.Unflatten<CustomerComplexDto, Customer>(dto);

            return result;
        }
    }
}
