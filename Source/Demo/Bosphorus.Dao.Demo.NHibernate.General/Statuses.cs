using Bosphorus.Common.Clr.Enum;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    public class Statuses: IEnumerationRegistration<Status>
    {
        public static readonly Status Active = new Status { Id = 1, Name = "Active" };
        public static readonly Status Inactive = new Status { Id = 2, Name = "Inactive" };
    }
}
