using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Relation: AbstractExecutionItemList
    {
        public Relation()
            : base("Relation")
        {
            Add("SetId - Null", () => Reference<Customer>.WithId(instance => instance.Id, null));
            Add("SetId - 123", () => Reference<Customer>.WithId(instance => instance.Id, 123));
        }
    }
}
