using System;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Model
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual int No { get; set; }
        public virtual string Name { get; set; }
        public virtual Type Type { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
