namespace Bosphorus.Dao.Common.Instantiator
{
    internal class NewConstaintInstantiator<TModel> : IInstantiator<TModel>
        where TModel: new()
    {
        public TModel Create()
        {
            return new TModel();
        }
    }
}
