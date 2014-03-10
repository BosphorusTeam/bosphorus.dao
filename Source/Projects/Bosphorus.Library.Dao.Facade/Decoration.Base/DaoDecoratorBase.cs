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
using System.Text;
using Bosphorus.Library.Dao.Core.Dao;
using Bosphorus.Library.Dao.Core.Session;

namespace Bosphorus.Library.Dao.Facade.Decoration.Base
{
    public class DaoDecoratorBase<TModel> : XaoDecoratorBase<TModel>, IDaoDecorator<TModel>
    {
        public new IDao<TModel> Decorated
        {
            get { return (IDao<TModel>)base.Decorated; }
            set { base.Decorated = value; }
        }

        public virtual ISession Session
        {
            get { return Decorated.Session; }
            set { Decorated.Session = value; }
        }

        public virtual TModel GetById<TId>(TId id)
        {
            return Decorated.GetById<TId>(id);
        }

        public virtual IList<TModel> GetByNamedQuery(string queryName, params object[] parameters)
        {
            return Decorated.GetByNamedQuery(queryName, parameters);
        }

        public virtual IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            return Decorated.GetByNamedQuery<TReturnType>(queryName, parameters);
        }

        public virtual IList<TModel> GetByQuery(string queryString, params object[] parameters)
        {
            return Decorated.GetByQuery(queryString, parameters);
        }

        public virtual IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            return Decorated.GetByQuery<TReturnType>(queryString, parameters);
        }

        public virtual TModel LoadById<TId>(TId id)
        {
            return Decorated.LoadById<TId>(id);
        }

        public virtual TModel LoadById(object id)
        {
            return Decorated.LoadById(id);
        }

        public virtual TModel Save(TModel entity)
        {
            return Decorated.Save(entity);
        }

        public virtual IEnumerable<TModel> Save(IEnumerable<TModel> entityList)
        {
            return Decorated.Save(entityList);
        }

        public virtual TModel SaveOrUpdate(TModel entity)
        {
            return Decorated.SaveOrUpdate(entity);
        }

        public virtual IEnumerable<TModel> SaveOrUpdate(IEnumerable<TModel> entityList)
        {
            return Decorated.SaveOrUpdate(entityList);
        }

        public virtual TModel Update(TModel entity)
        {
            return Decorated.Update(entity);
        }

        public virtual IEnumerable<TModel> Update(IEnumerable<TModel> entityList)
        {
            return Decorated.Update(entityList);
        }

        public virtual void Delete(TModel entity)
        {
            Decorated.Delete(entity);
        }

        public virtual void Delete(IEnumerable<TModel> entityList)
        {
            Decorated.Delete(entityList);
        }
    }
}
