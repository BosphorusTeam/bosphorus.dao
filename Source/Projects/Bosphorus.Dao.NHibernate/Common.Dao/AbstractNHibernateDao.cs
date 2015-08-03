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
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public abstract class AbstractNHibernateDao<TModel>
        where TModel : class
    {
        protected readonly IResultTransformer resultTransformer;
        protected readonly static Type modelType;
        static AbstractNHibernateDao()
        {
            modelType = typeof(TModel);
        }

        protected AbstractNHibernateDao()
        {
            resultTransformer = Transformers.AliasToBean<TModel>();
        }

        public abstract IQueryable<TModel> GetAll(ISession currentSession);
        public abstract IQueryable<TModel> Query(ISession currentSession);
        public abstract IQueryable<TModel> GetById<TId>(ISession currentSession, TId id);
        public abstract IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, IDictionary parameterDictionary);
        public abstract IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, IDictionary parameterDictionary);
        public abstract TModel Insert(ISession currentSession, TModel model);
        public abstract IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models);
        public abstract TModel Update(ISession currentSession, TModel model);
        public abstract IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models);
        public abstract void Delete(ISession currentSession, TModel model);
        public abstract void Delete(ISession currentSession, IEnumerable<TModel> models);
    }
}
