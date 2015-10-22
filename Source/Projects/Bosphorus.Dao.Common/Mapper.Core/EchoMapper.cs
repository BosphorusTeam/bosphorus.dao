namespace Bosphorus.Dao.Common.Mapper.Core
{
    public class EchoMapper<TModel> : IMapper<TModel, TModel>
    {
        public TModel Map(TModel source)
        {
            return source;
        }
    }
}
