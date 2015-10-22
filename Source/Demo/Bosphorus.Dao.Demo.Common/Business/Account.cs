namespace Bosphorus.Dao.Demo.Common.Business
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
