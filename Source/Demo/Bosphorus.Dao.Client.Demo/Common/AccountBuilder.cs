using System;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public class AccountBuilder : AbstractBuilder<Account, AccountBuilder>
    {
        public static AccountBuilder Default
        {
            get { return New.WithName("Maaş Hesabı"); }
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

        public AccountBuilder WithRandomName()
        {
            string name = "Random " + DateTime.Now.Second/10;
            return WithName(name);
        }

        public AccountBuilder WithCustomer(Customer customer)
        {
            model.Customer = customer;
            return this;
        }
    }
}
