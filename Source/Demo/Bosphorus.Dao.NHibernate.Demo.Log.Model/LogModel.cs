using System;

namespace Bosphorus.Dao.NHibernate.Demo.Log.Model
{
    public class LogModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Message { get; set; }
    }
}