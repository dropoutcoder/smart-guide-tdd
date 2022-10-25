using BenchmarkDotNet.Attributes;
using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

namespace SmartGuideTdd.FirstNonConsecutiveNumber.Benchmarks
{
    [MinColumn, MaxColumn, MemoryDiagnoser]
    public class BrokenSequenceFinderBenchmark
    {
        private readonly IBrokenSequenceFinder bitwise = new BitwiseBrokenSequenceFinder();
        private readonly IBrokenSequenceFinder arithmetic = new ArithmeticBrokenSequenceFinder();
        private readonly IBrokenSequenceFinder linqIntersect = new ArithmeticBrokenSequenceFinder();

        [Params(
            new[] { 0, 1, 2 },
            new[] { 10, 11, 12, 14, 15, 16 },
            new[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24 }
        )]
        public int[] Sequence { get; set; }

        [Benchmark]
        public int? Bitwise() => bitwise.Find(Sequence);

        [Benchmark]
        public int? Arithmetic() => arithmetic.Find(Sequence);

        [Benchmark]
        public int? LinqIntersect() => linqIntersect.Find(Sequence);
    }
}
