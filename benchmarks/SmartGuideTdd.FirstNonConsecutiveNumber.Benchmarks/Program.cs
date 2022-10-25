using BenchmarkDotNet.Running;

namespace SmartGuideTdd.FirstNonConsecutiveNumber.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<BrokenSequenceFinderBenchmark>();
        }
    }
}