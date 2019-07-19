using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        private const string FullName = "Steve J Gordon";
        private static readonly NameParser Parser = new NameParser();

        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            Parser.GetLastName(FullName);
        }

        [Benchmark]
        public void GetLastNameUsingSubstring()
        {
            Parser.GetLastNameUsingSubstring(FullName);
        }

        [Benchmark]
        public void GetLastNameWithSpan()
        {
            Parser.GetLastNameWithSpan(FullName);
        }
    }
}
