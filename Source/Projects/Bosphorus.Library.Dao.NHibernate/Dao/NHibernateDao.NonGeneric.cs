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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Common;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public class NHibernateDao: IDao
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly ISessionManager sessionManager;

        public NHibernateDao(ISessionManagerFactory sessionManagerFactory, IServiceRegistry serviceRegistry)
            : this(sessionManagerFactory, SessionAlias.Default, serviceRegistry)
        {
        }

        public NHibernateDao(ISessionManagerFactory sessionManagerFactory, string sessionAlias, IServiceRegistry serviceRegistry)
        {
            this.sessionManager = sessionManagerFactory.Build(sessionAlias);
            this.serviceRegistry = serviceRegistry;
        }

        public ISessionManager SessionManager
        {
            get { return sessionManager; }
        }

        public IQueryable<TModel> GetAll<TModel>(ISession currentSession)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IQueryable<TModel> result = genericDao.GetAll(currentSession);
            return result;
        }

        public IQueryable<TModel> Query<TModel>(ISession currentSession)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IQueryable<TModel> result = genericDao.Query(currentSession);
            return result;
        }

        public IQueryable<TModel> GetById<TModel, TId>(ISession currentSession, TId id)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IQueryable<TModel> result = genericDao.GetById(currentSession, id);
            return result;
        }

        public IQueryable<TModel> GetByQuery<TModel>(ISession currentSession, string queryString, IDictionary parameterDictionary)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IQueryable<TModel> result = genericDao.GetByQuery(currentSession, queryString, parameterDictionary);
            return result;
        }

        public IQueryable<TModel> GetByNamedQuery<TModel>(ISession currentSession, string queryName, IDictionary parameterDictionary)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IQueryable<TModel> result = genericDao.GetByNamedQuery(currentSession, queryName, parameterDictionary);
            return result;
        }

        public TModel Insert<TModel>(ISession currentSession, TModel entity)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            TModel result = genericDao.Insert(currentSession, entity);
            return result;
        }

        public IEnumerable<TModel> Insert<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IEnumerable<TModel> result = genericDao.Insert(currentSession, entityList);
            return result;
        }

        public TModel Update<TModel>(ISession currentSession, TModel entity)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            TModel result = genericDao.Update(currentSession, entity);
            return result;
        }

        public IEnumerable<TModel> Update<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            IEnumerable<TModel> result = genericDao.Update(currentSession, entityList);
            return result;
        }

        public void Delete<TModel>(ISession currentSession, TModel entity)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            genericDao.Delete(currentSession, entity);
        }

        public void Delete<TModel>(ISession currentSession, IEnumerable<TModel> entityList)
        {
            IDao<TModel> genericDao = serviceRegistry.Get<IDao<TModel>>();
            genericDao.Delete(currentSession, entityList);
        }
    }
}
