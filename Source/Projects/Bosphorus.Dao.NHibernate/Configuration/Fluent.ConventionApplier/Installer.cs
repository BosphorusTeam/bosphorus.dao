﻿using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IConventionApplier>()
                    .WithService
                    .FromInterface(),

                Component
                    .For<IConventionApplier>()
                    .ImplementedBy<CompositeConventionApplier>().IsDefault()
            );

        }
    }
}
