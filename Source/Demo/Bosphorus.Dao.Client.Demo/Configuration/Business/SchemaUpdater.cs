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
            //schemaUpdate.Execute(script => UpdateAction(script, configuration), true);
            schemaUpdate.Execute(true, true);

            //InsertInitialData(configuration);
        }

        private void UpdateAction(string script, global::NHibernate.Cfg.Configuration configuration)
        {
            if (script == string.Empty)
            {
                return;
            }

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

            Account account = AccountBuilder.Empty.WithName("Varsayılan Hesap").Build();
            account.Customer = customer;
            session.Save(account);
            session.Flush();

            customer.Accounts.Add(account);
            session.SaveOrUpdate(customer);
            session.Flush();

            account.Customer = customer;
            session.SaveOrUpdate(account);
            session.Flush();
        }
    }
}
