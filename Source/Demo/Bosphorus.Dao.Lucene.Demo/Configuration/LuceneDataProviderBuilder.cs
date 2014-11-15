using System;
using Bosphorus.Dao.Lucene.Configuration;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Linq;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Demo.Configuration
{
    public class LuceneDataProviderBuilder : ILuceneDataProviderBuilder
    {
        public LuceneDataProvider Build(Type modelType)
        {
            return LuceneDataProviderConfiguration
                .ForType(modelType)
                .Version(Version.LUCENE_30)
                .UsingDirectory(@"c:\Temp")
                .AnalyzeWith(version => new StandardAnalyzer(version))
                .Build();
        }
    }
}
