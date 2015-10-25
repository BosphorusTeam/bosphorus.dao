using System.Reflection;

namespace Bosphorus.Dao.Common.Metadata.Class.Metadata
{
    public static class IdentificatorExtensions
    {
        public static object GetValue(this Identificator extended, object model)
        {
            MemberInfo memberInfo = extended.Owner;
            PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
            object result = propertyInfo.GetValue(model);

            return result;
        }
    }
}
