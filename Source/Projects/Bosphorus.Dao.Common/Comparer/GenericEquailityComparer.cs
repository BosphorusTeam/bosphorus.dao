using System.Collections.Generic;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Comparer
{
    public class GenericEquailityComparer
    {
        private readonly IWindsorContainer container;

        public GenericEquailityComparer(IWindsorContainer container)
        {
            this.container = container;
        }

        public bool Equals<TModel>(TModel fromModel, TModel toModel)
        {
            IEqualityComparer<TModel> equalityComparer = container.Resolve<IEqualityComparer<TModel>>();
            bool result = equalityComparer.Equals(fromModel, toModel);
            return result;
        }

        public int GetHashCode<TModel>(TModel model)
        {
            IEqualityComparer<TModel> equalityComparer = container.Resolve<IEqualityComparer<TModel>>();
            int result = equalityComparer.GetHashCode(model);
            return result;
        }
    }
}
