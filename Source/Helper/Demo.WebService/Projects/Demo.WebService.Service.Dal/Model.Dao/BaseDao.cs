using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Dao;

namespace Demo.WebService.Service.Dal.Model.Dao
{
    public class BaseDao<TModel>: NullDao<TModel>
    {
        private readonly IDictionary<object, TModel> indexBackingStore;
        private readonly IList<TModel> dataBackingStore;

        public BaseDao()
        {
            dataBackingStore = new List<TModel>();
            indexBackingStore = new Dictionary<object, TModel>();
        }

        public override IList<TModel> GetAll()
        {
            return dataBackingStore;
        }

        protected virtual object GetIndex(TModel entity)
        {
            return entity;
        }

        public override TModel Save(TModel entity)
        {
            object index = GetIndex(entity);
            dataBackingStore.Add(entity);
            indexBackingStore.Add(index, entity);

            return entity;
        }

        public override IEnumerable<TModel> Save(IEnumerable<TModel> entities)
        {
            foreach (TModel model in entities)
            {
                Save(model);
            }
            return entities;
        }

        public override void Delete(TModel entity)
        {
            object index = GetIndex(entity);
            dataBackingStore.Remove(entity);
            indexBackingStore.Remove(index);
        }

        public override void Delete(IEnumerable<TModel> entities)
        {
            foreach (TModel model in entities)
            {
                Delete(model);
            }
        }

    }
}
