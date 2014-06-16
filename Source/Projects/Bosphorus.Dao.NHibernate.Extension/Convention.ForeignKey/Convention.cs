using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace Bosphorus.Dao.NHibernate.Extension.Convention.ForeignKey
{
    public class Convention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            // many-to-many, one-to-many, join
            if (property == null)
            {
                return type.Name + "Id";  
            }

            // many-to-one
            return property.Name + "Id"; 
        }
    }
}
