using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    public class CompositeMapper: IMapper
    {
        private readonly IList<IMapper> items;

        public CompositeMapper(IList<IMapper> items)
        {
            this.items = items;
        }

        public bool IsApplicable(Type sourceType, Type targetType)
        {
            foreach (IMapper item in items)
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
            foreach (IMapper item in items)
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
