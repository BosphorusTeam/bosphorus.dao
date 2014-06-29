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
using System.Linq.Expressions;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate.Linq;
using NHibernate.Linq.ReWriters;
using NHibernate.Metadata;
using NHibernate.Transform;
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

        public virtual IQueryable<TModel> GetAll<TModel>(ISession currentSession)
        {
            IQueryable<TModel> queryable = Query<TModel>(currentSession);
            return queryable;
        }

        public IQueryable<TModel> Query<TModel>(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.Query<TModel>();
            return queryable;
        }

        public virtual IQueryable<TModel> GetById<TModel, TId>(ISession currentSession, TId id)
        {
            Type modelType = typeof (TModel);
            IClassMetadata classMetadata = sessionProvider.GetClassMetadata(modelType);
            string identifierPropertyName = classMetadata.IdentifierPropertyName;

            ParameterExpression parameterExpression = Expression.Parameter(modelType);
            MemberExpression memberExpression = Expression.Property(parameterExpression, identifierPropertyName);
            ConstantExpression constantExpression = Expression.Constant(id);
            BinaryExpression bodyExpression = Expression.Equal(memberExpression, constantExpression);

            Expression<Func<TModel, bool>> expression = Expression.Lambda<Func<TModel, bool>>(bodyExpression, parameterExpression);
            IQueryable<TModel> queryable = Query<TModel>(currentSession);
            IQueryable<TModel> result = queryable.Where(expression);
            return result;
        }

        public virtual IQueryable<TModel> GetByNamedQuery<TModel>(ISession currentSession, string queryName, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            global::NHibernate.IQuery query = nativeSession.GetNamedQuery(queryName);
            IResultTransformer resultTransformer = Transformers.AliasToBean<TModel>();
            query.SetResultTransformer(resultTransformer);
            return GetByQuery<TModel>(query, parameters);
        }

        public virtual IQueryable<TModel> GetByQuery<TModel>(ISession currentSession, string queryString, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            global::NHibernate.ISQLQuery query = nativeSession.CreateSQLQuery(queryString);
            query.AddEntity(typeof(TModel));
            return GetByQuery<TModel>(query, parameters);
        }

        private IQueryable<TReturnType> GetByQuery<TReturnType>(global::NHibernate.IQuery query, object[] parameters)
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
            return result.AsQueryable();
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
