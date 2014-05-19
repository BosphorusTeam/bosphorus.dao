using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.NHibernate.Extension.UserType;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using Headspring;

namespace Bosphorus.Dao.NHibernate.Extension.Convention
{
    public class EnumerationTypeConvention : IUserTypeConvention
    {
        private static readonly Type openType = typeof(EnumerationType<>);

        public void Apply(IPropertyInstance instance)
        {
            var closedType = openType.MakeGenericType(instance.Property.PropertyType);

            instance.CustomType(closedType);
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => IsEnumerationType(x.Property.PropertyType));
        }

        private bool IsEnumerationType(Type type)
        {
            return GetTypeHierarchy(type)
                .Where(t => t.IsGenericType)
                .Select(t => t.GetGenericTypeDefinition())
                .Any(t => t == typeof(Enumeration<>));
        }

        private IEnumerable<Type> GetTypeHierarchy(Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
}
