using System;
using Bosphorus.Container.Castle.Fluent.Composition;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Default.Alias;
using Bosphorus.Dao.Core.Session.Default.Provider;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.AddFacility<TypedFactoryFacility>();
            //IsDefault composti'lerde zaten oluyor olmalı
            //Composite lerde from interface yettmiyor, all interfaces yap bari :( ya da explicit olarak şu interface diye söyle.

            container.Register(
                Compositor
                    .Of<IDefaultSessionProvider>()
                    .In(allLoadedTypes)
                    .ImplementedBy<CompositeDefaultSessionProvider>()
                    .IsDefault(),

                Compositor
                    .Of<IDefaultSessionAliasProvider>()
                    .In(allLoadedTypes)
                    .ImplementedBy<ChainedSessionAliasProvider>()
                    .IsDefault(),

                allLoadedTypes
                    .BasedOn<ISession>()
                    .WithService
                    .Self()
                    //.LifestyleCustom<SessionLifeStyleManager>()
                    .LifestyleScoped<ScopeAccessor>()
                    .Configure (registration => registration.UsingFactoryMethod(BuildSession)),

                Component
                    .For<ISessionLifeStyleProvider>()
                    .ImplementedBy<DefaultSessionLifeStyleProvider>()
                    .IsFallback()
            );
        }

        private object BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            Func<object> func = (Func<object>)creationContext.AdditionalArguments["UsingFactoryMethod"];
            object instance = func();
            return instance;
        }
    }
}
