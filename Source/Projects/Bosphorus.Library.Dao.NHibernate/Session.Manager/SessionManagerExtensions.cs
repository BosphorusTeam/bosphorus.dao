﻿using System;
using Bosphorus.Dao.Core.Session.Provider;
using NHibernate;
using NHibernate.Metadata;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public static class SessionManagerExtensions
    {
        public static IClassMetadata GetClassMetadata(this ISessionManager sessionManager, Type modelType)
        {
            NHibernateSessionManager nHibernateSessionManager = (NHibernateSessionManager)sessionManager;
            ISessionFactory nativeSessionProvider = nHibernateSessionManager.NativeSessionProvider;
            IClassMetadata classMetadata = nativeSessionProvider.GetClassMetadata(modelType);
            if (classMetadata == null)
            {
                throw new ModelMappingNotRegisteredException(sessionManager, modelType);
            }

            return classMetadata;
        }
    }
}
