using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Bosphorus.Dao.Common.Instantiator;
using Bosphorus.Dao.Common.Mapper.Core;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Flat;

namespace Bosphorus.Dao.Common.Mapper.Default
{
    public class ValueInjectorUnFlattenMapper : IMapper
    {
        private readonly Lazy<IMapper> lazyMapper;
        private readonly IInstantiator instantiator;

        public ValueInjectorUnFlattenMapper(Lazy<IMapper> mapper, IInstantiator instantiator)
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
            foreach (PropertyInfo propertyDescriptor in source.GetProps())
            {
                PropertyInfo prop = propertyDescriptor;
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
            lazyMapper.Value.Map(sourceType, sourceValue, targetType, targetValue);
            return targetValue;
        }
    }
}