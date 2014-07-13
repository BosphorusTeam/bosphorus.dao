using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    class MyFlatLoopValueInjection : LoopValueInjectionBase
    {
        protected override void Inject(object source, object target)
        {
            foreach (PropertyDescriptor propertyDescriptor in PropertyInfosStorage.GetProps(target))
            {
                PropertyDescriptor t1 = propertyDescriptor;
                IEnumerable<PropertyWithComponent> source1 = UberFlatter.Flat(propertyDescriptor.Name, source, (Func<Type, bool>)(type => this.TypesMatch(type, t1.PropertyType)));
                if (Enumerable.Count<PropertyWithComponent>(source1) != 0)
                {
                    PropertyWithComponent propertyWithComponent = Enumerable.First<PropertyWithComponent>(source1);
                    if (propertyWithComponent != null)
                    {
                        object sourcePropertyValue = propertyWithComponent.Property.GetValue(propertyWithComponent.Component);
                        if (this.AllowSetValue(sourcePropertyValue))
                            propertyDescriptor.SetValue(target, this.SetValue(sourcePropertyValue));
                    }
                }
            }
        }

        protected virtual bool TypesMatch(Type sourceType, Type targetType)
        {
            return targetType == sourceType;
        }

        protected virtual object SetValue(object sourcePropertyValue)
        {
            return sourcePropertyValue;
        }
    }
}
