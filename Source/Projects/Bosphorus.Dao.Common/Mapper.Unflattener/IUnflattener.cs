using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    public interface IUnflattener<in TSource, out TTarget> : IMapper<TSource, TTarget>
    {
    }
}