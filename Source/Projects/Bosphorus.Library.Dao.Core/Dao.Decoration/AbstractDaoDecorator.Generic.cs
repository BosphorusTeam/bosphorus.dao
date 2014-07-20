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
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao.Decoration
{
    public abstract class AbstractDaoDecorator<TModel> : IDao<TModel>
    {
        private readonly IDao<TModel> decorated;

        protected AbstractDaoDecorator(IDao<TModel> decorated)
        {
            this.decorated = decorated;
        }

        public virtual ISessionManager SessionManager
        {
            get { return decorated.SessionManager; }
        }

        public virtual IQueryable<TModel> GetAll(ISession currentSession)
        {
            return decorated.GetAll(currentSession);
        }

        public virtual IQueryable<TModel> Query(ISession currentSession)
        {
            return decorated.Query(currentSession);
        }

        public virtual IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            return decorated.GetById(currentSession, id);
        }

        public IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, IDictionary parameterDictionary)
        {
            return decorated.GetByNamedQuery(currentSession, queryName, parameterDictionary);
        }

        public virtual IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, IDictionary parameterDictionary)
        {
            return decorated.GetByQuery(currentSession, queryString, parameterDictionary);
        }

        public virtual TModel Insert(ISession currentSession, TModel model)
        {
            return decorated.Insert(currentSession, model);
        }

        public virtual IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            return decorated.Insert(currentSession, models);
        }

        public virtual TModel Update(ISession currentSession, TModel model)
        {
            return decorated.Update(currentSession, model);
        }

        public virtual IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            return decorated.Update(currentSession, models);
        }

        public virtual void Delete(ISession currentSession, TModel model)
        {
            decorated.Delete(currentSession, model);
        }

        public virtual void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            decorated.Delete(currentSession, models);
        }
    }
}
