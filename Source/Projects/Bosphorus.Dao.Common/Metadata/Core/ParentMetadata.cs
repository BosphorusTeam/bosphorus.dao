namespace Bosphorus.Dao.Common.Metadata.Core
{
    public class ParentMetadata<TOwner, TChild> : IMetadata<TOwner>
    {
        public TOwner Owner { get; set; }

        public IMetadata<TChild> ChildMetadata { get; set; }
    }
}