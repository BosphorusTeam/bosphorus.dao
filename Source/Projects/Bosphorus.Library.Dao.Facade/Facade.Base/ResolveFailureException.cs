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
using Bosphorus.Library.Dao.Facade.Base.Exception;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public class ResolveFailureException : DaoFacadeException
    {
        private const string EXCEPTION_MESSAGE = "Resolve of compomenent is failed";

        public ResolveFailureException(Type componentType, Exception innerException)
            : base(string.Format("{0}: [Component Type: {1}]", EXCEPTION_MESSAGE, componentType), innerException)
        {
        }
    }
}
