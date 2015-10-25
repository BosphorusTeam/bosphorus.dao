using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Metadata.Core
{
    public interface IMetadataBuilder<TOwner>
    {
        IEnumerable<IMetadata<TOwner>> Build(TOwner owner);

    }
}