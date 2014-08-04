using System.Collections;

namespace Bosphorus.Dao.Client.ResultTransformer
{
    public interface IResultTransformer
    {
        bool IsApplicable(object value);

        IList Transform(object value);
    }
}
