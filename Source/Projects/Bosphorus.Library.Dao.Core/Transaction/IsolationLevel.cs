namespace Bosphorus.Dao.Core.Transaction
{
    public enum IsolationLevel
    {
        Unspecified,
        Chaos,
        ReadUncommitted,
        ReadCommitted,
        RepeatableRead,
        Serializable,
        Snapshot
    }
}
