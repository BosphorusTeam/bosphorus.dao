using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene
{
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof (ILuceneDao<>))
                    .ImplementedBy(typeof (LuceneDao<>))
                    .NamedFull(),

                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn(typeof (ILuceneMap<>))
                    .WithService
                    .AllInterfaces()

                /*
                //TODO: Cache decoartor of LuceneSessionProviderFactory<> must be...
                Decorator
                    .Of<ILuceneDataProviderFactory>()
                    .Is<CacheDecorator>()
                    */
                );
        }
    }
}
