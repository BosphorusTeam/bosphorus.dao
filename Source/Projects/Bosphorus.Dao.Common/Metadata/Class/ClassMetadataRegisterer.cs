using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Dao.Common.Metadata.Core;

namespace Bosphorus.Dao.Common.Metadata.Class
{
    public abstract class ClassMetadataRegisterer<TModel> : IMetadataBuilder<Type>, IMetadataBuilder<MemberInfo>
    {
        private readonly List<IMetadata<Type>> typeMetadatas;
        private readonly List<IMetadata<MemberInfo>> memberMetadatas;

        protected ClassMetadataRegisterer()
        {
            this.typeMetadatas = new List<IMetadata<Type>>();
            this.memberMetadatas = new List<IMetadata<MemberInfo>>();

            ClassMetadataRegistration<TModel> registration = new ClassMetadataRegistration<TModel>(typeof(TModel), typeMetadatas, memberMetadatas);
            Register(registration);

            this.typeMetadatas.AddRange(memberMetadatas.Select(metadata => new MemberMetadata() {ChildMetadata = metadata, Owner = typeof(TModel)} ));
        }

        protected abstract void Register(ClassMetadataRegistration<TModel> registration);

        public IEnumerable<IMetadata<Type>> Build(Type owner)
        {
            if (owner != typeof (TModel))
            {
                return Enumerable.Empty<IMetadata<Type>>();
            }


            return typeMetadatas;
        }
        public IEnumerable<IMetadata<MemberInfo>> Build(MemberInfo owner)
        {
            if (owner.ReflectedType != typeof (TModel))
            {
                return Enumerable.Empty<IMetadata<MemberInfo>>();
            }

            return memberMetadatas;
        }

    }
}