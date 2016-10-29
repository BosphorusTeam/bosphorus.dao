using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseString
{
    public class UserType : AbstractStringType
    {
        public UserType() 
            : base(new StringSqlType())
        {
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            string upperCaseValue = value.ToString().ToUpperInvariant();
            IDbDataParameter dbDataParameter = (IDbDataParameter)cmd.Parameters[index];
            dbDataParameter.Value = upperCaseValue;
            if (dbDataParameter.Size > 0 && ((string)value).Length > dbDataParameter.Size)
                throw new HibernateException("The length of the string value exceeds the length configured in the mapping/parameter.");
        }

        public override object Get(IDataReader rs, int index)
        {
            object value = rs[index];
            string upperCaseString = Convert.ToString(value).ToUpperInvariant();
            return upperCaseString;
        }

        public override object Get(IDataReader rs, string name)
        {
            object value = rs[name];
            string upperCaseString = Convert.ToString(value).ToUpperInvariant();
            return upperCaseString;
        }

        public override string ToString(object val)
        {
            string upperCaseString = ((string) val).ToUpperInvariant();
            return upperCaseString;
        }

        public override object FromStringValue(string xml)
        {
            return xml;
        }

        //public object StringToObject(string xml)
        //{
        //    return xml;
        //}

        //public string ObjectToSQLString(object value, global::NHibernate.Dialect.Dialect dialect)
        //{
        //    string upperCaseString = ((string)value).ToUpperInvariant();
        //    return "'" + upperCaseString + "'";
        //}

        public override string Name => "UpperCase String";
    }
}
