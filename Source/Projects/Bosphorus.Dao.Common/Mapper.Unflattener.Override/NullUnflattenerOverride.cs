namespace Bosphorus.Dao.Common.Mapper.Unflattener.Override
{
    internal class NullUnflattenerOverride<TSource, TTarget> : IUnflattenerOverride<TSource, TTarget>
    {
        public void Map(TSource source, TTarget target)
        {
        }
    }
}