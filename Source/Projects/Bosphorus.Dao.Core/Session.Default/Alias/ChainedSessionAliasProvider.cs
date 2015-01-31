using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Provider.Factory;

namespace Bosphorus.Dao.Core.Session.Default.Alias
{
    internal class ChainedSessionAliasProvider : IDefaultSessionAliasProvider
    {
        private readonly IList<IDefaultSessionAliasProvider> items;

        public ChainedSessionAliasProvider(IList<IDefaultSessionAliasProvider> items)
        {
            this.items = items;
        }

        public string GetDefaultAlias<TModel>()
        {
            foreach (IDefaultSessionAliasProvider item in items)
            {
                string currentAlias = item.GetDefaultAlias<TModel>();
                if (currentAlias == null)
                {
                    continue;
                }

                return currentAlias;
            }

            return SessionAlias.Default;
        }
    }
}