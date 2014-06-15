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
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao
{
    public interface IDao
    {
        ISessionProvider SessionProvider { get; }

        IEnumerable<TModel> GetAll<TModel>(ISession currentSession);

        IQueryable<TModel> Query<TModel>(ISession currentSession);

        TModel GetById<TModel, TId>(ISession currentSession, TId id);

        IEnumerable<TModel> GetByNamedQuery<TModel>(ISession currentSession, string queryName, params object[] parameters);

        IEnumerable<TModel> GetByQuery<TModel>(ISession currentSession, string queryString, params object[] parameters);

        TModel Insert<TModel>(ISession currentSession, TModel entity);

        IEnumerable<TModel> Insert<TModel>(ISession currentSession, IEnumerable<TModel> entities);

        TModel Update<TModel>(ISession currentSession, TModel entity);

        IEnumerable<TModel> Update<TModel>(ISession currentSession, IEnumerable<TModel> entities);

        void Delete<TModel>(ISession currentSession, TModel entity);

        void Delete<TModel>(ISession currentSession, IEnumerable<TModel> entities);
    }
}
