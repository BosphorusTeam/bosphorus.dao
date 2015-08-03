using System;
using System.Collections;
using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Default
{
    public class EnumerableMapper: IMapper
    {
        private readonly Lazy<IMapper> lazyMapper;
        private readonly Type enumerableType;

        public EnumerableMapper(Lazy<IMapper> lazyMapper)
        {
            this.lazyMapper = lazyMapper;
            enumerableType = typeof (IEnumerable);
        }

        public bool IsApplicable(Type sourceType, Type targetType)
        {
            bool result = enumerableType.IsAssignableFrom(sourceType);
            return result;
        }

        public void Map(Type sourceType, object source, Type targetType, object target)
        {
            Type sourceElementType = GetElementType(sourceType);
            IEnumerable sourceEnumerable = (IEnumerable) source;
            Type targetElementType = GetElementType(targetType);
            IList targetList = (IList) target;

            foreach (object sourceElement in sourceEnumerable)
            {
                object targetElement = Activator.CreateInstance(targetElementType);
                lazyMapper.Value.Map(sourceElementType, sourceElement, targetElementType, targetElement);
                targetList.Add(targetElement);
            }
        }

        private Type GetElementType(Type sourceType)
        {
            Type[] genericArguments = sourceType.GetGenericArguments();
            return genericArguments[0];
        }
    }
}
