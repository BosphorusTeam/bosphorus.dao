using System;
using Bosphorus.Dao.Lucene.Configuration;
using Bosphorus.Dao.Lucene.Session.Provider.Factory.Native;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Linq;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Demo.Mix.Configuration.Lucene
{
    public class LuceneDataProviderFactory : ILuceneDataProviderFactory
    {
        public LuceneDataProvider Build(string sessionAlias, Type modelType)
        {
            return LuceneDataProviderConfiguration
                .ForType(modelType)
                .Version(Version.LUCENE_30)
                .UsingDirectory(@"c:\Lucene\" + sessionAlias)
                .AnalyzeWith(version => new StandardAnalyzer(version))
                .Build();
        }
    }
}
