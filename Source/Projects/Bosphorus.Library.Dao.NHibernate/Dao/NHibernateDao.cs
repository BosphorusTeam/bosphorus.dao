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
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public class NHibernateDao<TModel>: AbstractNHibernateDao<TModel> 
        where TModel : class
    {
        public override IQueryable<TModel> GetAll(ISession currentSession)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetAll(currentSession);
        }

        public override IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            nativeSession.Clear();
            return base.GetById<TId>(currentSession, id);
        }

        public override TModel Insert(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            TModel result = base.Insert(currentSession, model);
            nativeSession.Flush();
            return result;
        }

        public override IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> result = base.Insert(currentSession, models);
            nativeSession.Flush();
            return result;
        }

        public override TModel Update(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            TModel result = base.Update(currentSession, model);
            nativeSession.Flush();
            return result;
        }

        public override IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> result = base.Update(currentSession, models);
            nativeSession.Flush();
            return result;
        }

        public override void Delete(ISession currentSession, TModel model)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, model);
            nativeSession.Flush();
        }

        public override void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            global::NHibernate.ISession nativeSession = GetNativeSession(currentSession);
            base.Delete(currentSession, models);
            nativeSession.Flush();
        }
    }
}