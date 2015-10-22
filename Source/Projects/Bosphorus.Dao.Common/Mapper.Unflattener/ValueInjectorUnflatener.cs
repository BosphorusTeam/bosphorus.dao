using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Dao.Common.Instantiator;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Flat;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    internal class ValueInjectorUnflatener<TSource, TTarget> : IUnflattener<TSource, TTarget>
    {
        private readonly GenericUnflattener genericUnflattener;
        private readonly IInstantiator<TTarget> targetInstantiator;

        public ValueInjectorUnflatener(GenericUnflattener genericUnflattener, IInstantiator<TTarget> targetInstantiator)
        {
            this.genericUnflattener = genericUnflattener;
            this.targetInstantiator = targetInstantiator;
        }

        public TTarget Map(TSource source)
        {
            TTarget target = targetInstantiator.Create();

            foreach (PropertyInfo propertyDescriptor in source.GetProps())
            {
                IEnumerable<PropertyWithComponent> sourceProperties = UberFlatter.Unflat(propertyDescriptor.Name, target);
                if (!sourceProperties.Any())
                {
                    continue;
                }

                object sourcePropertyValue = propertyDescriptor.GetValue(source);
                foreach (PropertyWithComponent propertyWithComponent in sourceProperties)
                {
                    object targetValue = GetTargetValue(propertyDescriptor.PropertyType, sourcePropertyValue, propertyWithComponent.Property.PropertyType);
                    propertyWithComponent.Property.SetValue(propertyWithComponent.Component, targetValue);
                }
            }

            return target;
        }

        private object GetTargetValue(Type sourceType, object sourceValue, Type targetType)
        {
            if (sourceValue == null)
            {
                return null;
            }

            object targetValue = genericUnflattener.Map(sourceType, targetType, sourceValue);
            return targetValue;
        }
    }
}