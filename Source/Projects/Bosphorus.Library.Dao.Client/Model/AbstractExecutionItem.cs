using System.Collections;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractExecutionItem<TModel>: IExecutionItem
    {
        private readonly string name;

        protected AbstractExecutionItem(string functionName)
        {
            string modelName = typeof(TModel).Name;
            name = string.Format("{0} - {1}", modelName, functionName);
        }

        public abstract IList Execute();

        public override string ToString()
        {
            return name;
        }
    }
}
