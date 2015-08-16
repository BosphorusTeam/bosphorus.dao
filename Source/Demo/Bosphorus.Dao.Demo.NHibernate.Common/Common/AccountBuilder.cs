using System;
using System.Linq;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Bosphorus.Dao.Demo.Common.Business;
using NHibernate.Linq;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Common
{
    public class AccountBuilder : AbstractBuilder<Account, AccountBuilder>
    {
        public static AccountBuilder Default
        {
            get { return Empty.WithName("Maaş Hesabı"); }
        }

        public static AccountBuilder FromDatabaseWithChildren()
        {
            Console.WriteLine("Reading object from database to session ----------");
            Account model = dao.Value.Query().Fetch(x => x.Customer).ThenFetch(x => x.CustomerType).First();
            Console.WriteLine("Reading object from database to session ----------");

            AccountBuilder builder = new AccountBuilder();
            builder.model = model;
            return builder;
        }

        public AccountBuilder WithId(int id)
        {
            model.Id = id;
            return this;
        }

        public AccountBuilder WithName(string name)
        {
            model.Name = name;
            return this;
        }

        public AccountBuilder WithCustomer(Customer customer)
        {
            model.Customer = customer;
            return this;
        }
    }
}
