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

using System.Linq.Expressions;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Metadata;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public abstract class AbstractNHibernateDao<TModel> : IDao<TModel> 
        where TModel : class
    {
        private readonly ISessionProvider sessionProvider;
        private readonly Type modelType = typeof(TModel);
        private readonly IClassMetadata classMetadata;
        private readonly IResultTransformer resultTransformer;

        protected AbstractNHibernateDao(ISessionProviderFactory sessionProviderFactory, string sessionAlias)
        {
            this.sessionProvider = sessionProviderFactory.Build(sessionAlias);
            modelType = typeof(TModel);
            classMetadata = sessionProvider.GetClassMetadata(modelType);
            resultTransformer = Transformers.AliasToBean<TModel>();
        }

        public ISessionProvider SessionProvider
        {
            get { return sessionProvider; }
        }

        protected global::NHibernate.ISession GetNativeSession(ISession currentSession)
        {
            return ((NHibernateSession)currentSession).InnerSession;
        }

        protected global::NHibernate.ICriteria GetNativeCriteria(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            ICriteria criteria = nativeSession.CreateCriteria(modelType);
            return criteria;
        }

        public virtual IQueryable<TModel> GetAll(ISession currentSession)
        {
            IQueryable<TModel> queryable = Query(currentSession);
            return queryable;
        }

        public IQueryable<TModel> Query(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.Query<TModel>();
            return queryable;
        }

        public virtual IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            Expression<Func<TModel, bool>> expression = BuildGetByIdExpression(classMetadata, id);
            IQueryable<TModel> queryable = Query(currentSession);
            IQueryable<TModel> result = queryable.Where(expression);
            return result;
        }

        private Expression<Func<TModel, bool>> BuildGetByIdExpression<TId>(IClassMetadata classMetadata, TId id)
        {
            ParameterExpression parameterExpression = Expression.Parameter(modelType);
            string identifierPropertyName = classMetadata.IdentifierPropertyName;
            MemberExpression memberExpression = Expression.Property(parameterExpression, identifierPropertyName);
            ConstantExpression constantExpression = Expression.Constant(id);
            BinaryExpression bodyExpression = Expression.Equal(memberExpression, constantExpression);

            Expression<Func<TModel, bool>> expression = Expression.Lambda<Func<TModel, bool>>(bodyExpression, parameterExpression);
            return expression;
        }

        public virtual IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            global::NHibernate.IQuery query = nativeSession.GetNamedQuery(queryName);
            query.SetResultTransformer(resultTransformer);
            return GetByQuery<TModel>(query, parameters);
        }

        public virtual IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            ISQLQuery query = nativeSession.CreateSQLQuery(queryString);
            query.AddEntity(modelType);
            return GetByQuery<TModel>(query, parameters);
        }

        private IQueryable<TReturnType> GetByQuery<TReturnType>(IQuery query, object[] parameters)
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

        public virtual TModel Insert(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.SaveOrUpdate(model);
            return model;
        }

        public virtual IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.SaveOrUpdate(model);
            }
            return models;
        }

        public virtual TModel Update(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Merge(model);
            return model;
        }

        public virtual IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.Merge(model);
            }
            return models;
        }

        public virtual void Delete(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(model);
        }

        public virtual void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.Delete(model);
            }
        }
    }
}
