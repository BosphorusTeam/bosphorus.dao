using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model
{
    public class Deneme
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Value { get; set; }
    }
}
