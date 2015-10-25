namespace Bosphorus.Dao.Common.Metadata.Core
{
    public interface IMetadataRegisterer<TOwner>
    {
        void Register(IMetadataRegistration<TOwner> registration);
    }
}
