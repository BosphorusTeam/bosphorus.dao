using Bosphorus.Dao.NHibernate.Extension.UserType;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Bosphorus.Dao.NHibernate.Extension.Convention
{
    public class UpperCaseStringTypeConvention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType == typeof(string));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<UpperCaseStringType>();
        }
    }
}
