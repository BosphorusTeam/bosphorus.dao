using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Metadata;
using NHibernate.Persister.Entity;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Repository
{
    public class DefaultSessionManagerRepository : ISessionManagerRepository
    {
        private readonly IDictionary<Type, INHibernateSessionManager> typeSessionManagers;

        public DefaultSessionManagerRepository()
        {
            typeSessionManagers = new Dictionary<Type, INHibernateSessionManager>();
        }

        internal void Register(INHibernateSessionManager sessionManager)
        {
            ISessionFactory sessionFactory = sessionManager.NativeSessionManager;
            IDictionary<string, IClassMetadata> allClassMetadata = sessionFactory.GetAllClassMetadata();
            foreach (var classMetadataPair in allClassMetadata)
            {
                IClassMetadata classMetadata = classMetadataPair.Value;
                Type mappedClass = classMetadata.GetMappedClass(EntityMode.Poco);
                typeSessionManagers.Add(mappedClass, sessionManager);
                if (!classMetadata.HasSubclasses)
                {
                    continue;
                }

                foreach (string entityName in ((IEntityPersister)classMetadata).EntityMetamodel.SubclassEntityNames)
                {
                    var metadata = sessionFactory.GetClassMetadata(entityName);
                    Type subClass = metadata.GetMappedClass(EntityMode.Poco);
                    typeSessionManagers.Add(subClass, sessionManager);
                }
            }
        }

        public INHibernateSessionManager Get(Type modelType)
        {
            return typeSessionManagers[modelType];
        }
    }
}