using System.Collections;

namespace Bosphorus.Dao.Client.ResultTransformer
{
    public abstract class AbstractResultTransformer<TResult> : IResultTransformer
    {
        public bool IsApplicable(object value)
        {
            bool result =  value is TResult;
            return result;
        }

        public IList Transform(object value)
        {
            TResult typedValue = (TResult) value;
            IList result = TransformInternal(typedValue);
            return result;
        }

        protected abstract  IList TransformInternal(TResult typedValue);
    }

    public class ModelResultTransformer : AbstractResultTransformer<object>
    {
        protected override IList TransformInternal(object typedValue)
        {
            IList result = new ArrayList();
            result.Add(typedValue);
            return result;
        }
    }
}