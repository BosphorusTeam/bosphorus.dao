using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model
{
    public class CargoOrder
    {
        public virtual Guid Id { get; set; }
        public virtual int Desi { get; set; }
        public virtual int Sayi { get; set; }
        public virtual Customer OnurCustomer { get; set; }
    }
}
