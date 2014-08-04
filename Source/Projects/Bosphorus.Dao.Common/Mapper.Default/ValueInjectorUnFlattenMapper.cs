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
    public class ValueInjectorUnFlattenMapper : IMapper
    {
        private readonly LazyService<IMapper> lazyMapper;
        private readonly IInstantiator instantiator;

        public ValueInjectorUnFlattenMapper(LazyService<IMapper> mapper, IInstantiator instantiator)
        {
            this.lazyMapper = mapper;
            this.instantiator = instantiator;
        }

        public bool IsApplicable(Type sourceType, Type targetType)
        {
            bool result = sourceType.Name.EndsWith("Dto");
            return result;
        }

        public void Map(Type sourceType, object source, Type targetType, object target)
        {
            foreach (PropertyDescriptor propertyDescriptor in source.GetProps())
            {
                PropertyDescriptor prop = propertyDescriptor;
                IEnumerable<PropertyWithComponent> source1 = UberFlatter.Unflat(propertyDescriptor.Name, target);
                if (source1.Count() != 0)
                {
                    object sourcePropertyValue = propertyDescriptor.GetValue(source);
                    foreach (PropertyWithComponent propertyWithComponent in source1)
                    {
                        object targetValue = GetTargetValue(propertyDescriptor.PropertyType, sourcePropertyValue, propertyWithComponent.Property.PropertyType);
                        propertyWithComponent.Property.SetValue(propertyWithComponent.Component, targetValue);
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