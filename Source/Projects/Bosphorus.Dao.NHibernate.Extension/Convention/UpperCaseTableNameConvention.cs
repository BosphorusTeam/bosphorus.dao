    using System.Globalization;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Bosphorus.Dao.NHibernate.Extension.Convention
{
    public class UpperCaseTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            string entityTypeName = instance.EntityType.Name;
            string tableName = entityTypeName.ToUpperInvariant();
            instance.Table(tableName);
        }
    }
}
