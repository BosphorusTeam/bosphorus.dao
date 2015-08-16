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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bosphorus.Dao.NHibernate.Common.Dao;
using Bosphorus.Dao.NHibernate.Stateful.Session;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Metadata;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Stateful.Dao
{
    public class NHibernateStatefulDao<TModel>: AbstractNHibernateDao<TModel>, INHibernateStatefulDao<TModel>
        where TModel : class
    {
        private global::NHibernate.ISession GetNativeSession(ISession currentSession)
        {
            NHibernateStatefulSession nHibernateStatefulSession = currentSession as NHibernateStatefulSession;
            global::NHibernate.ISession nativeSession = nHibernateStatefulSession.InnerSession;
            IClassMetadata classMetadata = nativeSession.SessionFactory.GetClassMetadata(modelType);
            if (classMetadata == null)
            {
                throw new MissingModelMappingException<TModel>(nHibernateStatefulSession);
            }

            return nativeSession;
        }

        protected ICriteria GetNativeCriteria(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            ICriteria criteria = nativeSession.CreateCriteria(modelType);
            return criteria;
        }

        public override IQueryable<TModel> GetAll(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            nativeSession.Clear();
            IQueryable<TModel> queryable = Query(currentSession);
            return queryable;
        }

        public override IQueryable<TModel> Query(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.Query<TModel>();
            return queryable;
        }


        public override IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            nativeSession.Clear();

            IClassMetadata classMetadata = nativeSession.SessionFactory.GetClassMetadata(modelType);
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

        private IQueryable<TReturnType> GetByQuery<TReturnType>(IQuery query, IDictionary parameterDictionary)
        {
            foreach (DictionaryEntry parameterEntry in parameterDictionary)
            {
                string key = (string)parameterEntry.Key;
                object value = parameterEntry.Value;
                query.SetParameter(key, value);
            }

            IList<TReturnType> result = query.List<TReturnType>();
            return result.AsQueryable();
        }

        public override IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, IDictionary parameterDictionary)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            ISQLQuery query = nativeSession.CreateSQLQuery(queryString);
            query.AddEntity(modelType);
            return GetByQuery<TModel>(query, parameterDictionary);
        }

        public override IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, IDictionary parameterDictionary)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IQuery query = nativeSession.GetNamedQuery(queryName);
            query.SetResultTransformer(resultTransformer);
            return GetByQuery<TModel>(query, parameterDictionary);
        }

        public override TModel Insert(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            nativeSession.SaveOrUpdate(model);
            nativeSession.Flush();
            return model;
        }

        public override IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.SaveOrUpdate(model);
            }
            nativeSession.Flush();
            return models;
        }

        public override TModel Update(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            nativeSession.Merge(model);
            nativeSession.Flush();
            return model;
        }

        public override IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.Merge(model);
            }
            nativeSession.Flush();
            return models;
        }

        public override void Delete(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            nativeSession.Delete(model);
            nativeSession.Flush();
        }

        public override void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession= GetNativeSession(currentSession);
            foreach (TModel model in models)
            {
                nativeSession.Delete(model);
            }
            nativeSession.Flush();
        }
    }
}
