using Castle.Windsor;

namespace Bosphorus.Dao.Common.Metadata.Class
{
    public class GenericClassMetadataProvider
    {
        private readonly IWindsorContainer container;

        public GenericClassMetadataProvider(IWindsorContainer container)
        {
            this.container = container;
        }

        public ClassMetadataProvider<TModel> Of<TModel>()
        {
            ClassMetadataProvider<TModel> result = container.Resolve<ClassMetadataProvider<TModel>>();
            return result;
        }
    }
}
