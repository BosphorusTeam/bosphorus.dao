using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Flattener.Override
{
    public interface IFlattenerOverride<in TSource, in TTarget>
    {
        void Map(TSource source, TTarget target);
    }
}