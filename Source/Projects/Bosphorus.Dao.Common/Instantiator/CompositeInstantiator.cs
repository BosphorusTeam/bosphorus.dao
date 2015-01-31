using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Instantiator
{
    public class CompositeInstantiator : IInstantiator
    {
        private readonly IList<IInstantiator> instantiatorList;

        public CompositeInstantiator(IList<IInstantiator> instantiatorList)
        {
            this.instantiatorList = instantiatorList;
        }


        public bool IsApplicable(Type type)
        {
            return true;
        }

        public object Create(Type type)
        {
            foreach (IInstantiator instantiator in instantiatorList)
            {
                if (!instantiator.IsApplicable(type))
                {
                    continue;;
                }

                object result = instantiator.Create(type);
                return result;
            }

            object instance = Activator.CreateInstance(type);
            return instance;
        }
    }
}