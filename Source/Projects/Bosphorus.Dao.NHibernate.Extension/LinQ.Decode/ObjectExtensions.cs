using System.Collections.Generic;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Decode
{
    public static class ObjectExtensions
    {
        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1) where T : class
        {
            TReturn result = Decode(extended, value1, return1, default(TReturn));
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1, TReturn fallback) where T : class
        {
            IList<KeyValuePair<T, TReturn>> keyValueList = new List<KeyValuePair<T, TReturn>>();
            keyValueList.Add(new KeyValuePair<T, TReturn>(value1, return1));

            TReturn result = Decode(extended, keyValueList, fallback);
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1, T value2, TReturn return2) where T : class
        {
            TReturn result = Decode(extended, value1, return1, value2, return2, default(TReturn));
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1, T value2, TReturn return2, TReturn fallback) where T : class
        {
            IList<KeyValuePair<T, TReturn>> keyValueList = new List<KeyValuePair<T, TReturn>>();
            keyValueList.Add(new KeyValuePair<T, TReturn>(value1, return1));
            keyValueList.Add(new KeyValuePair<T, TReturn>(value2, return2));

            TReturn result = Decode(extended, keyValueList, fallback);
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1, T value2, TReturn return2, T value3, TReturn return3) where T : class
        {
            TReturn result = Decode(extended, value1, return1, value2, return2, value3, return3, default(TReturn));
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, T value1, TReturn return1, T value2, TReturn return2, T value3, TReturn return3, TReturn fallback) where T : class
        {
            IList<KeyValuePair<T, TReturn>> keyValueList = new List<KeyValuePair<T, TReturn>>();
            keyValueList.Add(new KeyValuePair<T, TReturn>(value1, return1));
            keyValueList.Add(new KeyValuePair<T, TReturn>(value2, return2));
            keyValueList.Add(new KeyValuePair<T, TReturn>(value3, return3));

            TReturn result = Decode(extended, keyValueList, fallback);
            return result;
        }

        public static TReturn Decode<T, TReturn>(this T extended, IEnumerable<KeyValuePair<T, TReturn>> keyValueList, TReturn fallback) where T : class
        {
            foreach (var keyBaluePair in keyValueList)
            {
                if (extended == keyBaluePair.Key)
                {
                    return keyBaluePair.Value;
                }
            }

            return fallback;
        }
    }
}
