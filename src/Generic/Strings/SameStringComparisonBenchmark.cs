using System.Text;
using BenchmarkDotNet.Attributes;

namespace Generic.Strings
{
    public class SameStringComparisonBenchmark
    {
        private const string A = "a";

        private readonly string[] _stringsA;
        private readonly string[] _stringsB;

        public SameStringComparisonBenchmark()
        {
            _stringsA = GenerateAllStrings();
            _stringsB = GenerateAllStrings();
        }

        [Params(1, 2, 4, 8, 16, 32)]
        public int NumberOfChars { get; set; }

        [Benchmark]
        public bool SameString()
        {
            var a = GetStringA(NumberOfChars);
            return CompareStrings(a, a);
        }

        [Benchmark]
        public bool EqualString()
        {
            var a = GetStringA(NumberOfChars);
            var b = GetStringB(NumberOfChars);
            return CompareStrings(a, b);
        }

        private string GetStringA(int n)
        {
            return _stringsA[n - 1];
        }

        private string GetStringB(int n)
        {
            return _stringsB[n - 1];
        }

        private static bool CompareStrings(string a, string b)
        {
            return string.Equals(a, b);
        }

        private static string[] GenerateAllStrings()
        {
            var sizes = new[] { 1, 2, 4, 8, 16, 32 };
            var strings = new string[32];

            foreach (var size in sizes)
            {
                strings[size - 1] = CreateString(size);
            }

            return strings;
        }

        private static string CreateString(int n)
        {
            var sb = new StringBuilder(n);

            for (var i = 0; i < n; i++)
            {
                sb.Append(A);
            }

            return sb.ToString();
        }
    }
}