﻿using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation;
using Bosphorus.Demo.Runner.Executable;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.RelationByMap
{
    public class Reference: AbstractMethodExecutionItemList
    {
        public Reference(IWindsorContainer container) 
            : base(container)
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
