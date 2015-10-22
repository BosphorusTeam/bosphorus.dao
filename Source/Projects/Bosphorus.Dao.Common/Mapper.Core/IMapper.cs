namespace Bosphorus.Dao.Common.Mapper.Core
{
    public interface IMapper<in TSource, out TTarget>
    {
        TTarget Map(TSource source);
    }
}
