using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Client.Demo.Configuration.Business
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);

            //InsertInitialData(configuration);
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
