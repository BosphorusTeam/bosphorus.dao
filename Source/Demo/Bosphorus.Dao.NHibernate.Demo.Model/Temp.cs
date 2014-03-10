using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model
{
    public class Temp
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
