using System.Reflection;
using Bosphorus.Dao.Common.Metadata.Core;

namespace Bosphorus.Dao.Common.Metadata.Class.Metadata
{
    public class Unique: IMetadata<MemberInfo>
    {
        public MemberInfo Owner { get; set; }
    }
}