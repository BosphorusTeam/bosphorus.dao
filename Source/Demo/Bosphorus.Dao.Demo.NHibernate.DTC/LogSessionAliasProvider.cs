using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session.Default.Alias;
using Bosphorus.Dao.Demo.Common.Log;

namespace Bosphorus.Dao.Demo.NHibernate.DTC
{
    public class LogSessionAliasProvider: IDefaultSessionAliasProvider
    {
        private readonly IEnumerable<Type> avaliableModels;

        public LogSessionAliasProvider()
        {
            avaliableModels = new[] {typeof(LogModel)};
        }

        public string GetDefaultAlias<TModel>()
        {
            Type modelType = typeof (TModel);
            bool contains = avaliableModels.Contains(modelType);
            if (!contains)
            {
                return null;
            }

            return "LOG";
        }
    }
}
