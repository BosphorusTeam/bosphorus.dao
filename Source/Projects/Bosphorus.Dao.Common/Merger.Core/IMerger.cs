namespace Bosphorus.Dao.Common.Merge
{
    public interface IMerger<TModel>
    {
        TModel Merge(TModel intoModel, TModel model);
    }
}
