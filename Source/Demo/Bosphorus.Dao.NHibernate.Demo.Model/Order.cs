using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model
{
    public class Order
    {
        public virtual Guid Id { get; set; }
        public virtual int Desi { get; set; }
        public virtual int Sayi { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
