using System;
using Bosphorus.Common.Api.Enum;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Bosphorus.Dao.NHibernate.Extension.Convention.Eumeration
{
    public class Convention: IIdConventionAcceptance, IIdConvention
    {
        private readonly Type enumerationType;

        public Convention()
        {
            enumerationType = typeof (EnumerationBase);
        }

        public void Accept(IAcceptanceCriteria<IIdentityInspector> criteria)
        {
            criteria.Expect(x => IsEnumerationType(x.EntityType));
        }

        private bool IsEnumerationType(Type entityType)
        {
            if (entityType == null)
            {
                return false;
            }

            if (entityType == enumerationType)
            {
                return true;
            }

            Type baseType = entityType.BaseType;
            bool result = IsEnumerationType(baseType);
            return result;
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
        }
    }
}
