using System.Collections.Generic;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public class CustomerBuilder: AbstractBuilder<Customer, CustomerBuilder>
    {
        public CustomerBuilder()
        {
            model.Accounts = new List<Account>();
        }

        public static CustomerBuilder Default
        {
            get
            {
                return New
                    .WithName("Onur Eker")
                    .WithCustomerType(CustomerTypes.Bireysel)
                    .AddAccount(AccountBuilder.Default.Build());
            }
        }

        public CustomerBuilder WithId(int id)
        {
            model.Id = id;
            return this;
        }

        public CustomerBuilder WithName(string name)
        {
            model.Name = name;
            return this;
        }

        public CustomerBuilder WithCustomerType(CustomerType customerType)
        {
            model.CustomerType = customerType;
            return this;
        }

        public CustomerBuilder AddAccount(Account account)
        {
            model.Accounts.Add(account);
            return this;
        }
    }
}
