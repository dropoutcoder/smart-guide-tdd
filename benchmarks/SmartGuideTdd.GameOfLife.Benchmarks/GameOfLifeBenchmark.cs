using BenchmarkDotNet.Attributes;
using SmartGuideTdd.GameOfLife;

namespace SmartGuideTdd.FirstNonConsecutiveNumber.Benchmarks
{
    [MinColumn, MaxColumn, MemoryDiagnoser]
    public class GameOfLifeBenchmark
    {
        public IEnumerable<int[,]> Values { get; }

        private readonly GameOfLifeExecutor StandardExecution = new GameOfLifeExecutor(false);

        private readonly GameOfLifeExecutor ParallelExecution = new GameOfLifeExecutor(true);

        public GameOfLifeBenchmark()
        {
            Values = new[]
            {
                new int[,] { { 0, 1, 1, 0 }, { 1, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } },
                new int[,] { { 1, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 0, 0, 1 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }  },
            };
        }

        [ParamsSource(nameof(Values))]
        public int[,] GameState { get; set; }

        [Benchmark]
        public int[,] Normal() => StandardExecution.Tick(GameState);

        [Benchmark]
        public int[,] Parallel() => ParallelExecution.Tick(GameState);
    }
}
