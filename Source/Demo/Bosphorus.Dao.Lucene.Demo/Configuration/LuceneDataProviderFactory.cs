﻿using System;
using Bosphorus.Dao.Lucene.Configuration;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Linq;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Demo.Configuration
{
    public class LuceneDataProviderFactory : ILuceneDataProviderFactory
    {
        public LuceneDataProvider Build(string sessionAlias)
        {
            return LuceneDataProviderConfiguration
                .Version(Version.LUCENE_30)
                .UsingDirectory(@"c:\Lucene\" + sessionAlias)
                .AnalyzeWith(version => new StandardAnalyzer(version))
                .Build();
        }
    }
}
