using System;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    public interface IMapper
    {
        bool IsApplicable(Type sourceType, Type targetType);

        void Map(Type sourceType, object source, Type targetType, object target);
    }
}