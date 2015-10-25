using System.Linq;

namespace Bosphorus.Dao.Common.Metadata.Core
{
    public interface IMetadataProvider<TOwner>
    {
        IQueryable<IMetadata<TOwner>> GetMetadatas(TOwner owner);

    }
}
