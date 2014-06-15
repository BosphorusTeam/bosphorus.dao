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
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao
{
    public abstract class AbstractDao<TModel> : IDao<TModel>
    {
        public virtual ISessionProvider SessionProvider
        {
            get { throw new NotImplementedException(); }
        }

        public virtual IEnumerable<TModel> GetAll(ISession currentSession)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TModel> Query(ISession currentSession)
        {
            throw new NotImplementedException();
        }

        public virtual TModel GetById<TId>(ISession currentSession, TId id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> GetByNamedQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> GetByQuery(ISession currentSession, string queryString, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Insert(ISession currentSession, TModel entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Update(ISession currentSession, TModel entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(ISession currentSession, TModel entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(ISession currentSession, IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
