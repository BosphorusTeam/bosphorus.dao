/*
  Bosphorus Enterprise Framework - The Open-Source Enterprise Framework
  Copyright (C) 2006-2008 Onur EKER <onur.eker@gmail.com>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public abstract class AbstractNHibernateDao : IDao
    {
        private readonly ISessionProvider sessionProvider;

        protected AbstractNHibernateDao(ISessionProviderFactory sessionProviderFactory, string sessionAlias)
        {
            this.sessionProvider = sessionProviderFactory.Build(sessionAlias);
        }

        public ISessionProvider SessionProvider
        {
            get { return sessionProvider; }
        }

        protected global::NHibernate.ISession GetNativeSession(ISession currentSession)
        {
            return ((NHibernateSession)currentSession).InnerSession;
        }

        protected global::NHibernate.ICriteria GetNativeCriteria<TModel>(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            Type persitentType = typeof (TModel);
            ICriteria criteria = nativeSession.CreateCriteria(persitentType);
            return criteria;
        }

        public virtual IEnumerable<TModel> GetAll<TModel>(ISession currentSession)
        {
            return GetByCriteria<TModel>(currentSession);
        }

        private IList<TModel> GetByCriteria<TModel>(ISession currentSession, params object[] criterions)
        {
            ICriteria criteria = GetNativeCriteria<TModel>(currentSession);
            foreach (object criterium in criterions)
            {
                criteria.Add((ICriterion)criterium);
            }

            return criteria.List<TModel>();
        }

        public IQueryable<TModel> Query<TModel>(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.Query<TModel>();
            return queryable;
        }

        public virtual TModel GetById<TModel, TId>(ISession currentSession, TId id)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            return nativeSession.Get<TModel>(id);
        }

        public virtual IEnumerable<TModel> GetByNamedQuery<TModel>(ISession currentSession, string queryName, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            global::NHibernate.IQuery query = nativeSession.GetNamedQuery(queryName);
            return GetByQuery<TModel>(query, parameters);
        }

        public virtual IEnumerable<TModel> GetByQuery<TModel>(ISession currentSession, string queryString, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            global::NHibernate.IQuery query = nativeSession.CreateQuery(queryString);
            return GetByQuery<TModel>(query, parameters);
        }

        private IList<TReturnType> GetByQuery<TReturnType>(global::NHibernate.IQuery query, object[] parameters)
        {
            int parameterCount = 0;
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == null)
                    continue;

                query.SetParameter(parameterCount, parameters[i]);
                parameterCount++;
            }

            IList<TReturnType> result = query.List<TReturnType>();
            return result as List<TReturnType>;
        }

        public virtual TModel Insert<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.SaveOrUpdate(entity);
            return entity;
        }

        public virtual IEnumerable<TModel> Insert<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in entityList)
            {
                nativeSession.SaveOrUpdate(model);
            }
            return entityList;
        }

        public virtual TModel Update<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.SaveOrUpdate(entity);
            return entity;
        }

        public virtual IEnumerable<TModel> Update<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in entityList)
            {
                nativeSession.SaveOrUpdate(model);
            }
            return entityList;
        }

        public virtual void Delete<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(entity);
        }

        public virtual void Delete<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in entityList)
            {
                nativeSession.Delete(model);
            }
        }
    }
}
