using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Bosphorus.Dao.NHibernate.Extension.Convention.TablePrefix
{
    public class Convention : IClassConvention
    {
        private readonly string tablePrefix;

        public Convention(string tablePrefix)
        {
            this.tablePrefix = tablePrefix;
        }

        public void Apply(IClassInstance instance)
        {
            string entityName = instance.EntityType.Name;
            string tableName = tablePrefix + entityName;
            instance.Table(tableName);
        }
    }
}
