using BenchmarkDotNet.Running;
using SmartGuideTdd.FirstNonConsecutiveNumber.Benchmarks;

namespace SmartGuideTdd.GameOfLife.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<GameOfLifeBenchmark>();
        }
    }
}