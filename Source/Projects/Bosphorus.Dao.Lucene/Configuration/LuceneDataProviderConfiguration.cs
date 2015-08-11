using System;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Linq;
using Lucene.Net.Store;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Configuration
{
    public class LuceneDataProviderConfiguration
    {
        private readonly Version currentVersion;
        private FSDirectory directory;
        private Analyzer currentAnalyzer;
        private IndexWriter currentIndexWriter;

        public static LuceneDataProviderConfiguration Version(Version version)
        {
            return new LuceneDataProviderConfiguration(version);
        }

        private LuceneDataProviderConfiguration(Version version)
        {
            this.currentVersion = version;
        }

        public LuceneDataProviderConfiguration UsingDirectory(string directory)
        {
            string typeDirectory = directory;
            this.directory = FSDirectory.Open(typeDirectory);
            return this;
        }

        public LuceneDataProviderConfiguration AnalyzeWith(Func<Version, Analyzer> buildAnalyzer)
        {
            this.currentAnalyzer = buildAnalyzer(currentVersion);
            return this;
        }
        public LuceneDataProviderConfiguration UsingWriter(Func<Directory, Analyzer, IndexWriter> buildIndexer)
        {
            this.currentIndexWriter = buildIndexer(directory, currentAnalyzer);
            return this;
        }

        public LuceneDataProvider Build()
        {
            Version version = currentVersion != default(Version) ? currentVersion : global::Lucene.Net.Util.Version.LUCENE_30;
            Analyzer analyzer = currentAnalyzer ?? new StandardAnalyzer(version);
            IndexWriter indexWriter = currentIndexWriter ?? new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

            LuceneDataProvider provider = new LuceneDataProvider(directory, analyzer, version, indexWriter);
            provider.Settings.EnableMultipleEntities = false;
            return provider;
        }
    }
}
