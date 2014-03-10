using System.Collections;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractExecutionItem: IExecutionItem
    {
        private readonly string name;

        protected AbstractExecutionItem(string name)
        {
            this.name = name;
        }

        public abstract IList Execute();

        public override string ToString()
        {
            return name;
        }
    }
}
