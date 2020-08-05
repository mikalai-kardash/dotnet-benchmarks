using BenchmarkDotNet.Attributes;

namespace Main.Benchmarks
{
    public class StringComparisons
    {
        private const string A = "a";

        [Benchmark]
        public bool SameString() => string.Equals(A, A);

        [Benchmark]
        public bool EqualString() => string.Equals("a", "a");
    }
}