using BenchmarkDotNet.Running;

namespace SmartGuideTdd.FindMultiples.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<DivisibleValueFinderBenchmarks>();
        }
    }
}