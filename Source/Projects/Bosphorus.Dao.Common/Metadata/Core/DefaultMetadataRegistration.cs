using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Metadata.Core
{
    public class DefaultMetadataRegistration<TOwner> : IMetadataRegistration<TOwner>
    {
        private readonly TOwner owner;
        private readonly IList<IMetadata<TOwner>> metadatas;

        public DefaultMetadataRegistration(TOwner owner, IList<IMetadata<TOwner>> metadatas)
        {
            this.owner = owner;
            this.metadatas = metadatas;
        }

        public IMetadataRegistration<TOwner> Is<TMetadata>() 
            where TMetadata : IMetadata<TOwner>, new()
        {
            TMetadata metadata = new TMetadata();
            metadata.Owner = owner;
            metadatas.Add(metadata);
            return this;
        }
    }
}