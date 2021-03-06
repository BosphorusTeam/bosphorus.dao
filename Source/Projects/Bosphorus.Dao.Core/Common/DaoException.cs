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

using System.Runtime.Serialization;

namespace Bosphorus.Dao.Core.Common
{
    public class DaoException: System.Exception
    {
        public DaoException()
        {
        }

        public DaoException(string message)
            : base(message)
        {
        }

        protected DaoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DaoException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
