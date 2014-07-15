using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.RelationByMap
{
    public class Reference: AbstractExecutionItemList
    {
        public Reference()
            : base("RelationByMap - Reference")
        {
            Add("Create Parent From Null", () => Reference<Customer>.WithId(instance => instance.Id, null));
            Add("Create Parent From Value", () => Reference<Customer>.WithId(instance => instance.Id, 123));
        }
    }
}
