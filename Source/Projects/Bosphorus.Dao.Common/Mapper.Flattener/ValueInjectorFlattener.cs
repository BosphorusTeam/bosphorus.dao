using System;
using System.ComponentModel;
using System.Linq;
using Bosphorus.Dao.Common.Instantiator;
using Omu.ValueInjecter.Flat;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    internal class ValueInjectorFlattener<TSource, TTarget> : IFlattener<TSource, TTarget>
    {
        private readonly GenericFlattener genericFlattener;
        private readonly IInstantiator<TTarget> targetInstantiator;
        private readonly PropertyDescriptorCollection targetPropertyDescriptorCollection;

        public ValueInjectorFlattener(GenericFlattener genericFlattener, IInstantiator<TTarget> targetInstantiator)
        {
            this.genericFlattener = genericFlattener;
            this.targetInstantiator = targetInstantiator;
            this.targetPropertyDescriptorCollection = TypeDescriptor.GetProperties(typeof (TTarget));
        }

        public TTarget Map(TSource source)
        {
            TTarget target = targetInstantiator.Create();
            foreach (PropertyDescriptor targetPropertyDescriptor in targetPropertyDescriptorCollection)
            {
                PropertyWithComponent propertyWithComponent = UberFlatter.Flat(targetPropertyDescriptor.Name, source).FirstOrDefault();
                if (propertyWithComponent == null)
                {
                    continue;
                }

                object sourcePropertyValue = propertyWithComponent.Property.GetValue(propertyWithComponent.Component);
                object targetValue = GetTargetValue(propertyWithComponent.Property.PropertyType, sourcePropertyValue, targetPropertyDescriptor.PropertyType);
                targetPropertyDescriptor.SetValue(target, targetValue);
            }

            return target;
        }

        private object GetTargetValue(Type sourceType, object sourceValue, Type targetType)
        {
            if (sourceValue == null)
            {
                return null;
            }

            object targetValue = genericFlattener.Map(sourceType, targetType, sourceValue);
            return targetValue;
        }
    }
}