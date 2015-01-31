using System;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Business
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            bool isUpdated = false;
            schemaUpdate.Execute(script => { Console.WriteLine(script); isUpdated = true;}, true);

            if (!isUpdated)
            {
                return;
            }

            InsertInitialData(configuration);
        }

        private void InsertInitialData(global::NHibernate.Cfg.Configuration configuration)
        {
            ISession session = configuration.BuildSessionFactory().OpenSession();

            session.Save(BankBuilder.Default.Build());

            session.Save(CustomerTypes.Bireysel);
            session.Save(CustomerTypes.Kurumsal);

            Customer customer = CustomerBuilder.Empty.WithName("Onur Eker").WithCustomerType(CustomerTypes.Bireysel).Build();
            session.Save(customer);
            session.Flush();

            Account account1 = AccountBuilder.Empty.WithName("Varsayılan Hesap").Build();
            account1.Customer = customer;
            session.Save(account1);
            session.Flush();

            Account account2 = AccountBuilder.Empty.WithName("USD Hesap").Build();
            account2.Customer = customer;
            session.Save(account2);
            session.Flush();

            customer.Accounts.Add(account1);
            customer.Accounts.Add(account2);
            customer.PrimaryAccount = account1;
            session.SaveOrUpdate(customer);
            session.Flush();

            account1.Customer = customer;
            session.SaveOrUpdate(account1);

            account2.Customer = customer;
            session.SaveOrUpdate(account2);

            session.Flush();
        }
    }
}
