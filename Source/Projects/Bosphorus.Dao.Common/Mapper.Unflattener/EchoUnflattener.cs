using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    internal class EchoUnflattener<TModel> : EchoMapper<TModel>, IUnflattener<TModel, TModel>
    {
    }
}
