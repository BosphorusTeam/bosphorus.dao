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
using System.Web.Services;
using Bosphorus.Library.Facades;
using Bosphorus.Library.Dao.WebService.Model.Common;
using System.Collections;

namespace Bosphorus.Library.Dao.WebService.Model.WebService
{
    public class GenericDaoService<TModel>
    {
        [WebMethod]
        public virtual TModel[] GetAll()
        {
            IList<TModel> list = Repository.Domain.Live<TModel>.GetAll();
            return ServiceConvertor.ToArray<TModel>(list);
        }

        [WebMethod]
        public virtual TModel[] GetByCriteria(params object[] criterions)
        {
            IList<TModel> list = Repository.Domain.Live<TModel>.GetByCriteria(criterions);
            return ServiceConvertor.ToArray<TModel>(list);
        }

        [WebMethod]
        public virtual TModel GetById(object id)
        {
            TModel model = Repository.Domain.Live<TModel>.LoadById(id);
            return model;
        }

        [WebMethod]
        public virtual object[] GetByNamedQuery(string queryName, params object[] parameters)
        {
            IList<TModel> list = Repository.Domain.Live<TModel>.GetByNamedQuery(queryName, parameters);
            return ServiceConvertor.ToArray((IEnumerable)list);
        }

        [WebMethod]
        public virtual object[] GetByQuery(string queryString, params object[] parameters)
        {
            IList<TModel> list = Repository.Domain.Live<TModel>.GetByQuery(queryString, parameters);
            return ServiceConvertor.ToArray((IEnumerable)list);
        }

        [WebMethod]
        public virtual TModel LoadById(object id)
        {
            TModel model = Repository.Domain.Live<TModel>.LoadById(id);
            return model;
        }

        [WebMethod]
        public virtual TModel Save(TModel entity)
        {
            TModel model = Repository.Domain.Live<TModel>.Save(entity);
            return model;
        }

        [WebMethod]
        public virtual TModel[] SaveArray(TModel[] entities)
        {
            return Repository.Domain.Live<TModel>.Save(entities);
        }

        [WebMethod]
        public virtual TModel SaveOrUpdate(TModel entity)
        {
            TModel model = Repository.Domain.Live<TModel>.SaveOrUpdate(entity);
            return model;
        }

        [WebMethod]
        public virtual TModel[] SaveOrUpdateArray(TModel[] entities)
        {
            return Repository.Domain.Live<TModel>.SaveOrUpdate(entities);
        }

        [WebMethod]
        public virtual TModel Update(TModel entity)
        {
            TModel model = Repository.Domain.Live<TModel>.Update(entity);
            return model;
        }

        [WebMethod]
        public virtual TModel[] UpdateArray(TModel[] entities)
        {
            return Repository.Domain.Live<TModel>.Update(entities);
        }

        [WebMethod]
        public virtual void Delete(TModel entity)
        {
            Repository.Domain.Live<TModel>.Delete(entity);
        }

        [WebMethod]
        public virtual void DeleteArray(TModel[] entities)
        {
            Repository.Domain.Live<TModel>.Delete(entities);
        }
    }
}
