namespace Bosphorus.Dao.Core.Session.Default.Alias
{
    public interface IDefaultSessionAliasProvider
    {
        string GetDefaultAlias<TModel>();
    }
}
