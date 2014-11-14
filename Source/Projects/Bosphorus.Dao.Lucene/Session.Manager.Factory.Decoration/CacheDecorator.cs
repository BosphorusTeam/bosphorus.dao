namespace Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration
{
    public class CacheDecorator: Bosphorus.Dao.Core.Session.Manager.Factory.Decoration.CacheDecorator, ILuceneSessionManagerFactory
    {
        public CacheDecorator(ILuceneSessionManagerFactory decorated) 
            : base(decorated)
        {
        }
    }
}
