using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using NHibernate.Linq;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
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
                return Empty
                    .WithName("Onur Eker")
                    .WithCustomerType(CustomerTypes.Bireysel);
            }
        }

        public static CustomerBuilder FromDatabaseWithChildren()
        {
            Console.WriteLine("Reading object from database to session ----------");
            Customer model = dao.Value.Query().Fetch(x => x.Accounts).Fetch(x => x.CustomerType).First();
            Console.WriteLine("Reading object from database to session ----------");

            CustomerBuilder builder = new CustomerBuilder();
            builder.model = model;
            return builder;
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
