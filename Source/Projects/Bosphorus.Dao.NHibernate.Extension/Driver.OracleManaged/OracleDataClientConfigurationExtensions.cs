using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Extension.Driver.OracleManaged
{
    public static class OracleDataClientConfigurationExtensions
    {
        public static OracleDataClientConfiguration Managed(this OracleDataClientConfiguration extended)
        {
            return extended.Driver<OracleManagedDataClientDriver>();
        }
    }
}
