using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    class DefaultMapper: IMapper
    {
        private readonly IList<IMapper> items;

        public DefaultMapper(IList<IMapper> items)
        {
            this.items = items;
        }

        public bool IsApplicable(Type sourceType, Type targetType)
        {
            foreach (var item in items)
            {
                bool isApplicable = item.IsApplicable(sourceType, targetType);
                if (isApplicable)
                {
                    return true;
                }
            }

            return false;
        }

        public void Map(Type sourceType, object source, Type targetType, object target)
        {
            foreach (var item in items)
            {
                bool isApplicable = item.IsApplicable(sourceType, targetType);
                if (!isApplicable)
                {
                    continue;
                }

                item.Map(sourceType, source, targetType, target);
                return;;
            }

            //TODO: Throw exception
        }
    }
}
