namespace Bosphorus.Dao.Common.Merge
{
    internal class PrimitiveMerger<TModel> : IMerger<TModel>
    {
        public TModel Merge(TModel intoModel, TModel model)
        {
            return model;
        }
    }
}
