using System;
using Bosphorus.Dao.Demo.Builder;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Demo.Configuration.NHibernatee
{
    public class LogSchemaUpdater
    {
        public static void Process(global::NHibernate.Cfg.Configuration configuration)
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

        public static void InsertInitialData(global::NHibernate.Cfg.Configuration configuration)
        {
            ISession session = configuration.BuildSessionFactory().OpenSession();
            session.Save(LogBuilder.Default.Build());
            session.Flush();
        }
    }
}
