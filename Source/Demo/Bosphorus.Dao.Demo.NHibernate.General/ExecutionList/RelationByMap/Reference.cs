using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.RelationByMap
{
    public class Reference: AbstractMethodExecutionItemList
    {
        public Reference(IResultTransformer resultTransformer) 
            : base(resultTransformer)
        {
        }

        public Customer CreateReferenceModel_FromNull()
        {
            Customer customer = Reference<Customer>.WithId(instance => instance.Id, null);
            return customer;
        }

        public Customer CreateReferenceModel_FromValue()
        {
            Customer customer = Reference<Customer>.WithId(instance => instance.Id, 123);
            return customer;
        }

    }
}
