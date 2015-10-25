using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Dao.Common.Metadata.Core;

namespace Bosphorus.Dao.Common.Metadata.Class
{
    public class ClassMetadataRegistration<TModel>: DefaultMetadataRegistration<Type>
    {
        private readonly IList<IMetadata<MemberInfo>> memberMetadatas;

        public ClassMetadataRegistration(Type owner, IList<IMetadata<Type>> typeMetadatas, IList<IMetadata<MemberInfo>> memberMetadatas)
            : base(owner, typeMetadatas)
        {
            this.memberMetadatas = memberMetadatas;
        }

        public IMetadataRegistration<MemberInfo> Property(Expression<Func<TModel, object>> propertyExpression)
        {
            MemberExpression memberExpression = GetMemberExpression(propertyExpression);
            MemberInfo memberInfo = memberExpression.Member;
            IMetadataRegistration<MemberInfo> memberMetadataRegistration = new DefaultMetadataRegistration<MemberInfo>(memberInfo, memberMetadatas);
            return memberMetadataRegistration;
        }

        private MemberExpression GetMemberExpression(Expression<Func<TModel, object>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body;
        }

   }

}