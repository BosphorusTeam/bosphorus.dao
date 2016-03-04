using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Dao.Core.Common;
using Castle.Core.Internal;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider
{
    public abstract class AbstractAutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        private readonly string sessionAlias;
        private readonly AutoPersistenceModel nullAutoMap;

        protected AbstractAutoPersistenceModelProvider()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractAutoPersistenceModelProvider(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
            this.nullAutoMap = AutoMap.Source(NullTypeSource.Instance);
        }

        public AutoPersistenceModel GetAutoPersistenceModel(ITypeProvider typeProvider, string sessionAlias)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return nullAutoMap;
            }

            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(typeProvider.LoadedTypes, SessionAlias.Default);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedTypes, string sessionAlias)
        {
            ITypeSource typeSource = new TypeSource(allLoadedTypes);
            return AutoMap.Source(typeSource);
        }

    }
}
