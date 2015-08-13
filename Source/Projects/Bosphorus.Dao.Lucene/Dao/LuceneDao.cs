using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Lucene.Net.Linq;
using Bosphorus.Dao.Lucene.Session;
using Lucene.Net.Linq.Mapping;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Dao
{
    public class LuceneDao<TModel> : ILuceneDao<TModel>
        where TModel : new()
    {
        private readonly IDocumentMapper<TModel> documentMapper;

        public LuceneDao(ILuceneMap<TModel> luceneMap)
        {
            documentMapper = luceneMap.ToDocumentMapper(Version.LUCENE_30);
        }

        private LuceneDataProvider GetNativeSession(ISession currentSession)
        {
            LuceneSession luceneSession = (LuceneSession) currentSession;
            LuceneDataProvider luceneDataProvider = luceneSession.InnerSession;
            return luceneDataProvider;
        }

        public IQueryable<TModel> GetAll(ISession currentSession)
        {
            IQueryable<TModel> result = Query(currentSession);
            return result;
        }

        public IQueryable<TModel> Query(ISession currentSession)
        {
            LuceneDataProvider nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.AsQueryable(documentMapper);
            return queryable;
        }

        public IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, IDictionary parameterDictionary)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, IDictionary parameterDictionary)
        {
            throw new NotImplementedException();
        }

        public TModel Insert(ISession currentSession, TModel model)
        {
            LuceneDataProvider nativeSession = GetNativeSession(currentSession);
            using (ISession<TModel> luceneSession = nativeSession.OpenSession(documentMapper))
            {
                luceneSession.Add(model);
                luceneSession.Commit();
            }
            return model;
        }

        public IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            LuceneDataProvider nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> modelList = models as IList<TModel> ?? models.ToList();

            using (ISession<TModel> luceneSession = nativeSession.OpenSession(documentMapper))
            {
                foreach (TModel model in modelList)
                {
                    luceneSession.Add(model);
                }
                luceneSession.Commit();
            }
            return modelList;
        }

        public TModel Update(ISession currentSession, TModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISession currentSession, TModel model)
        {
            LuceneDataProvider nativeSession = GetNativeSession(currentSession);
            using (ISession<TModel> luceneSession = nativeSession.OpenSession(documentMapper))
            {
                luceneSession.Delete(model);
                luceneSession.Commit();
            }
        }

        public void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            LuceneDataProvider nativeSession = GetNativeSession(currentSession);
            IEnumerable<TModel> modelList = models as IList<TModel> ?? models.ToList();
            using (ISession<TModel> luceneSession = nativeSession.OpenSession(documentMapper))
            {
                foreach (TModel model in modelList)
                {
                    luceneSession.Delete(model);
                }
                luceneSession.Commit();
            }
        }
    }
}