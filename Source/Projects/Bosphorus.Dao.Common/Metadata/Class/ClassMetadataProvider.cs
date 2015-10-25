using System;
using System.Linq;
using System.Reflection;
using Bosphorus.Dao.Common.Metadata.Core;

namespace Bosphorus.Dao.Common.Metadata.Class
{
    public class ClassMetadataProvider<TModel>
    {
        private readonly IQueryable<IMetadata<Type>> metadatas;

        public ClassMetadataProvider(IMetadataProvider<Type> metadataProvider)
        {
            this.metadatas = metadataProvider.GetMetadatas(typeof (TModel));
        }

        public TMetadata GetMetadata<TMetadata>()
            where TMetadata : IMetadata<Type>
        {
            TMetadata result = metadatas
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }

        public TMetadata GetMemberMetadata<TMetadata>()
            where TMetadata : IMetadata<MemberInfo>
        {
            TMetadata result = metadatas
                .OfType<MemberMetadata>()
                .Select(metadata => metadata.ChildMetadata)
                .OfType<TMetadata>()
                .FirstOrDefault();

            return result;
        }
    }
}
