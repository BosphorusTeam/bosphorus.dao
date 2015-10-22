using Bosphorus.Dao.Common.Mapper.Core;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    internal class EchoFlattener<TModel>: EchoMapper<TModel>, IFlattener<TModel, TModel>
    {
    }
}
