using System;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Dao;
using NHibernate;
using NHibernate.Metadata;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public static class SessionProviderExtensions
    {
        public static IClassMetadata GetClassMetadata(this ISessionProvider sessionProvider, Type modelType)
        {
            NHibernateSessionProvider nHibernateSessionProvider = (NHibernateSessionProvider)sessionProvider;
            ISessionFactory nativeSessionProvider = nHibernateSessionProvider.NativeSessionProvider;
            IClassMetadata classMetadata = nativeSessionProvider.GetClassMetadata(modelType);
            if (classMetadata == null)
            {
                throw new ModelMappingNotRegisteredException(sessionProvider, modelType);
            }

            return classMetadata;
        }
    }
}
