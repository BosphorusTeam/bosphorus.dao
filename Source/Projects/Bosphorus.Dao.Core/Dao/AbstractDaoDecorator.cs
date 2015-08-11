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

namespace Bosphorus.Dao.Core.Dao.Decoration
{
    public abstract class AbstractDaoDecorator<TModel> : IDao<TModel> 
    {
        private readonly IDao<TModel> decorated;

        protected AbstractDaoDecorator(IDao<TModel> decorated)
        {
            this.decorated = decorated;
        }

        public virtual IQueryable<TModel> GetAll(ISession currenISession)
        {
            return decorated.GetAll(currenISession);
        }

        public virtual IQueryable<TModel> Query(ISession currenISession)
        {
            return decorated.Query(currenISession);
        }

        public virtual IQueryable<TModel> GetById<TId>(ISession currenISession, TId id)
        {
            return decorated.GetById(currenISession, id);
        }

        public IQueryable<TModel> GetByNamedQuery(ISession currenISession, string queryName, IDictionary parameterDictionary)
        {
            return decorated.GetByNamedQuery(currenISession, queryName, parameterDictionary);
        }

        public virtual IQueryable<TModel> GetByQuery(ISession currenISession, string queryString, IDictionary parameterDictionary)
        {
            return decorated.GetByQuery(currenISession, queryString, parameterDictionary);
        }

        public virtual TModel Insert(ISession currenISession, TModel model)
        {
            return decorated.Insert(currenISession, model);
        }

        public virtual IEnumerable<TModel> Insert(ISession currenISession, IEnumerable<TModel> models)
        {
            return decorated.Insert(currenISession, models);
        }

        public virtual TModel Update(ISession currenISession, TModel model)
        {
            return decorated.Update(currenISession, model);
        }

        public virtual IEnumerable<TModel> Update(ISession currenISession, IEnumerable<TModel> models)
        {
            return decorated.Update(currenISession, models);
        }

        public virtual void Delete(ISession currenISession, TModel model)
        {
            decorated.Delete(currenISession, model);
        }

        public virtual void Delete(ISession currenISession, IEnumerable<TModel> models)
        {
            decorated.Delete(currenISession, models);
        }
    }
}
