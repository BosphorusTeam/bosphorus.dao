using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model.Default
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual int Number { get; set; }
        public virtual Guid Customer_id { get; set; }
        public virtual Type Type { get; set; }
    }
}
