using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseColumnName
{
    public class Convention : IPropertyConvention, IIdConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            string columnName = GetColumnName(instance.Property.Name);
            instance.Column(columnName);
        }

        public void Apply(IIdentityInstance instance)
        {
            string columnName = GetColumnName(instance.Name);
            instance.Column(columnName);
        }

        private string GetColumnName(string propertyName)
        {
            string columnName = propertyName.ToUpperInvariant();
            return columnName;
        }
    }
}
