namespace Bosphorus.Dao.Common.Mapper.Flattener.Override
{
    internal class NullFlattenerOverride<TSource, TTarget> : IFlattenerOverride<TSource, TTarget>
    {
        public void Map(TSource source, TTarget target)
        {
        }
    }
}