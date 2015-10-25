namespace Bosphorus.Dao.Common.Mapper.Unflattener.Override
{
    public interface IUnflattenerOverride<in TSource, in TTarget>
    {
        void Map(TSource source, TTarget target);
    }
}