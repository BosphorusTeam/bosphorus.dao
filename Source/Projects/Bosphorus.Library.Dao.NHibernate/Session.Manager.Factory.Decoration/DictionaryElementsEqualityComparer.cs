using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration
{
    public class DictionaryElementsEqualityComparer : IEqualityComparer<IDictionary>
    {
        public bool Equals(IDictionary x, IDictionary y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }
                
            if (!x.Keys.Cast<object>().SequenceEqual(y.Keys.Cast<object>()))
            {
                return false;
            }

            foreach (var key in x.Keys)
            {
                object xValue = x[key];
                object yValue = y[key];

                if (xValue.Equals(yValue))
                    continue;

                return false;
            }

            return true;
        }

        public int GetHashCode(IDictionary obj)
        {
            //TODO: Temporary
            return 1;
        }
    }
}