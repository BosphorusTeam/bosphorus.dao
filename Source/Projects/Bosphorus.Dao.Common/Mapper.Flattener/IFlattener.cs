using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    public interface IFlattener<in TSource, out TTarget> : IMapper<TSource, TTarget>
    {
    }
}