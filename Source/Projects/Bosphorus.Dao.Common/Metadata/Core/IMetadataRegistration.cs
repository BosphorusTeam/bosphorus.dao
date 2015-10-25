namespace Bosphorus.Dao.Common.Metadata.Core
{
    public interface IMetadataRegistration<TOwner>
    {
        IMetadataRegistration<TOwner> Is<TMetadata>() 
            where TMetadata : IMetadata<TOwner>, new();
    }

}