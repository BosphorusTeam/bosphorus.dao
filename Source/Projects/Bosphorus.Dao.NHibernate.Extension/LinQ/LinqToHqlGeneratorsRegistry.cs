using NHibernate.Linq.Functions;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ
{
    public class LinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public LinqToHqlGeneratorsRegistry()
        {
            this.Merge(new In.HqlGenerator());
            //this.RegisterGenerator(new StandardLinqExtensionMethodGenerator());
            this.Merge(new Coalesce.HqlGenerator());
            this.Merge(new CastAs.HqlGenerator());
            //this.Merge(new Equals.HqlGenerator());
        }
    }
}
