using System.Collections;
using System.Linq;

namespace Bosphorus.Dao.Client.ResultTransformer
{
    public class QueryableResultTransformer : AbstractResultTransformer<IQueryable<object>>
    {
        protected override IList TransformInternal(IQueryable<object> typedValue)
        {
            var result = typedValue.ToList();
            return result;
        }
    }
}