namespace Bosphorus.Dao.Common.Metadata.Core
{
    public interface IMetadata<TOwner>
    {
        TOwner Owner { get; set; }
    }
}
