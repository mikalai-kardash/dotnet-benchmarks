using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Generic;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssemblies(new[] { typeof(GenericInfo).Assembly })
                .Run(args, GetGlobalConfig());
        }

        private static IConfig GetGlobalConfig()
            => DefaultConfig.Instance.WithOptions(ConfigOptions.StopOnFirstError);
    }
}