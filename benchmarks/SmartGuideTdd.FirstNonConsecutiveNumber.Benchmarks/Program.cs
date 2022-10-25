using BenchmarkDotNet.Running;
using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

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