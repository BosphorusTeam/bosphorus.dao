using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Bosphorus.Container.Castle.Lazy;
using Bosphorus.Dao.Common.Instantiator;
using Bosphorus.Dao.Common.Mapper.Core;
using Omu.ValueInjecter;

namespace Bosphorus.Dao.Common.Mapper.Default
{
    public class ValueInjectorFlattenMapper : IMapper
    {
        private readonly LazyService<IMapper> lazyMapper;
        private readonly IInstantiator instantiator;

        public ValueInjectorFlattenMapper(LazyService<IMapper> mapper, IInstantiator instantiator)
        {
            this.lazyMapper = mapper;
            this.instantiator = instantiator;
        }

        public bool IsApplicable(Type sourceType, Type targetType)
        {
            bool result = targetType.Name.EndsWith("Dto");
            return result;
        }

        public void Map(Type sourceType, object source, Type targetType, object target)
        {
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(target))
            {
                PropertyDescriptor t1 = propertyDescriptor;
                IEnumerable<PropertyWithComponent> source1 = UberFlatter.Flat(propertyDescriptor.Name, source);
                if (source1.Count() != 0)
                {
                    PropertyWithComponent propertyWithComponent = source1.First();
                    if (propertyWithComponent != null)
                    {
                        object sourcePropertyValue = propertyWithComponent.Property.GetValue(propertyWithComponent.Component);
                        object targetValue = GetTargetValue(propertyWithComponent.Property.PropertyType, sourcePropertyValue, propertyDescriptor.PropertyType);
                        propertyDescriptor.SetValue(target, targetValue);
                    }
                }
            }
        }

        private object GetTargetValue(Type sourceType, object sourceValue, Type targetType)
        {
            if (sourceType.IsValueType || sourceType == typeof(string))
                return sourceValue;

            object targetValue = instantiator.Create(targetType);
            lazyMapper.Service.Map(sourceType, sourceValue, targetType, targetValue);
            return targetValue;
        }
    }
}