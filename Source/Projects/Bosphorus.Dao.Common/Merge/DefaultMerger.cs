using System;
using System.ComponentModel;

namespace Bosphorus.Dao.Common.Merge
{
    internal class DefaultMerger<TModel> : IMerger<TModel>
    {
        private readonly GenericMerger genericMerger;
        private readonly PropertyDescriptorCollection propertyDescriptorCollection;

        public DefaultMerger(GenericMerger genericMerger)
        {
            this.genericMerger = genericMerger;
            propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof (TModel));
        }

        public TModel Merge(TModel intoModel, TModel model)
        {
            foreach (PropertyDescriptor propertyDescriptor in propertyDescriptorCollection)
            {
                object sourcePropertyValue = propertyDescriptor.GetValue(intoModel);
                object overridePropertyValue = propertyDescriptor.GetValue(model);

                Type propertyType = propertyDescriptor.PropertyType;
                object resultPropertyValue = genericMerger.Merge(propertyType, sourcePropertyValue, overridePropertyValue);

                propertyDescriptor.SetValue(intoModel, resultPropertyValue);
            }

            return intoModel;
        }
    }
}