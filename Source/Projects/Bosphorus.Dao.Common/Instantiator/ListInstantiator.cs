using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Instantiator
{
    public class ListInstantiator : IInstantiator
    {
        public bool IsApplicable(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            Type genericTypeDefinition = type.GetGenericTypeDefinition();
            bool result = genericTypeDefinition == typeof (IList<>);
            return result;
        }

        public object Create(Type type)
        {
            Type elementType = type.GetGenericArguments()[0];
            Type imlementationListType = typeof (List<>).MakeGenericType(elementType);
            object result = Activator.CreateInstance(imlementationListType);

            return result;
        }
    }
}