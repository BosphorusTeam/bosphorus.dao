using NHibernate.Linq.Functions;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ
{
    public class LinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public LinqToHqlGeneratorsRegistry()
        {
            //this.RegisterGenerator(new StandardLinqExtensionMethodGenerator());
            this.Merge(new CastAs.HqlGenerator());
            //this.Merge(new Equals.HqlGenerator());
        }
    }
}
