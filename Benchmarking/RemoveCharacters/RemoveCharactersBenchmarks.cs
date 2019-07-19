using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class RemoveCharactersBenchmarks
    {
        private string cnpj = "00.816.794/0001-66";
        private char[] charsToRemove = new char[] { '.', '/', '-' };
        private string[] strsToRemove = new string[] { ".", "/", "-" };

        RemoveCharacter Remover = new RemoveCharacter();

        [Benchmark(Baseline = true)]
        public void RemoverCaracteresWithSpan()
        {
            Remover.RemoverCaracteresWithSpan(cnpj, charsToRemove);
        }

        [Benchmark]
        public void RemoverCaracteresSimples()
        {
            Remover.RemoverCaracteresSimples(cnpj, strsToRemove);
        }

        [Benchmark]
        public void RemoverCaracteresStringBuilder()
        {
            Remover.RemoverCaracteresStringBuilder(cnpj, strsToRemove);
        }

        [Benchmark]
        public void RemoverCaracteresStringBuilderChars()
        {
            Remover.RemoverCaracteresStringBuilderChars(cnpj, charsToRemove);
        }
    }
}
