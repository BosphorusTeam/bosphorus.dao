using Bosphorus.Common.Clr.Enum;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo
{
    public class Statuses: IEnumerationRegistration<Status>
    {
        public static readonly Status Active = new Status { Id = 1, Name = "Active" };
        public static readonly Status Inactive = new Status { Id = 2, Name = "Inactive" };
    }
}
