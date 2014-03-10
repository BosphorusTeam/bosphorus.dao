using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Bosphorus.Library.Dao.WebService.Model.Common
{
    public static class ServiceConvertor
    {
        public static List<TModel> ToList<TModel>(IEnumerable enumerable)
        {
            List<TModel> list = new List<TModel>();
            foreach (object model in enumerable)
            {
                list.Add((TModel)model);
            }

            return list;
        }

        public static List<TModel> ToList<TModel>(IEnumerable<TModel> enumerable)
        {
            return ToList<TModel>((IEnumerable)enumerable);
        }

        public static TModel[] ToArray<TModel>(IEnumerable<TModel> enumerable)
        {
            List<TModel> list = ToList<TModel>(enumerable);
            TModel[] array = list.ToArray();
            return array;
        }

        public static object[] ToArray(IEnumerable enumerable)
        {
            List<object> list =  ToList<object>(enumerable);
            object[] array = ToArray<object>(list);
            return array;
        }
    }
}
