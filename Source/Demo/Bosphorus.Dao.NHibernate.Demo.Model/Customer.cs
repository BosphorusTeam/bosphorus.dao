using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model
{
    public class Customer
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}