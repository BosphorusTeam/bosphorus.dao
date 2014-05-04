using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model.Log
{
    public class LogModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Message { get; set; }
    }
}