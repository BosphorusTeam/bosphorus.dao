﻿using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Demo.DTC.Business
{
    public class PersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            return
                SQLiteConfiguration
                    .Standard
                    .ConnectionString(@"data source=.\Demo.db3")
                    .ShowSql()
                    .FormatSql();
        }
    }
}
