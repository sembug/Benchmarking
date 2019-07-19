using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarking
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class ContainsBenchmarks
    {
        private string StrToFind = "abc";
        private string Input = "xptoAbC/abc";

        ContainsRegex ContainsRegex = new ContainsRegex();

        [Benchmark(Baseline = true)]
        public void VersionWithRegex()
        {
            ContainsRegex.VersionWithRegex(StrToFind, Input);
        }

        [Benchmark]
        public void VersionWithIndex()
        {
            ContainsRegex.VersionWithIndex(StrToFind, Input);
        }

        [Benchmark]
        public void VersionWithoutRegex()
        {
            ContainsRegex.VersionWithoutRegex(StrToFind, Input);
        }
    }
}
