using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Dao.Client.ResultTransformer
{
    public class QueryableResultTransformer : AbstractResultTransformer<IQueryable<object>>
    {
        protected override IList TransformInternal(IQueryable<object> typedValue)
        {
            List<object> result = typedValue.ToList();
            return result;
        }
    }
}