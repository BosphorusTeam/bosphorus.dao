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

using System.Collections.Generic;
using Bosphorus.Dao.NHibernate.Common;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public class NHibernateDao: AbstractNHibernateDao
    {
        public NHibernateDao(ISessionProviderFactory sessionProviderFactory)
            : this(sessionProviderFactory, SessionAlias.Default)
        {
        }

        public NHibernateDao(ISessionProviderFactory sessionProviderFactory, string sessionAlias)
            : base(sessionProviderFactory, sessionAlias)
        {
        }

        public override IEnumerable<TModel> GetAll<TModel>(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetAll<TModel>(currentSession);
        }

        public override TModel GetById<TModel, TId>(ISession currentSession, TId id)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetById<TModel, TId>(currentSession, id);
        }

        public override IEnumerable<TModel> GetByQuery<TModel>(ISession currentSession, string queryString, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetByQuery<TModel>(currentSession, queryString, parameters);
        }

        public override IEnumerable<TModel> GetByNamedQuery<TModel>(ISession currentSession, string queryName, params object[] parameters)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetByNamedQuery<TModel>(currentSession, queryName, parameters);
        }

        public override TModel Insert<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            TModel model = base.Insert(currentSession, entity);
            nativeSession.Flush();
            return model;
        }

        public override IEnumerable<TModel> Insert<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> result = base.Insert(currentSession, entityList);
            nativeSession.Flush();
            return result;
        }

        public override TModel Update<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            TModel model = base.Update(currentSession, entity);
            nativeSession.Flush();
            return model;
        }

        public override IEnumerable<TModel> Update<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> result = base.Update(currentSession, entityList);
            nativeSession.Flush();
            return result;
        }

        public override void Delete<TModel>(ISession currentSession, TModel entity)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, entity);
            nativeSession.Flush();
        }

        public override void Delete<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, entityList);
            nativeSession.Flush();
        }
    }
}
