using System;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Demo.NHibernate.General.Configuration.Log
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        public SchemaUpdater()
            : base("LOG")
        {
        }

        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            bool isUpdated = false;
            schemaUpdate.Execute(script => { Console.WriteLine(script); isUpdated = true; }, true);

            if (!isUpdated)
            {
                return;
            }

            InsertInitialData(configuration);
        }

        private void InsertInitialData(global::NHibernate.Cfg.Configuration configuration)
        {
            ISession session = configuration.BuildSessionFactory().OpenSession();
            session.Save(LogBuilder.Default.Build());
            session.Flush();
        }
    }
}
