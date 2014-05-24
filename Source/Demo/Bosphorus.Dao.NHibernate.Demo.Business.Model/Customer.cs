using System;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Model
{
    public class Customer
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual AdressType AdressType { get; set; }
    }
}