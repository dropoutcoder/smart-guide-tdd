using NUnit.Framework.Legacy;

namespace SmartGuideTdd.GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void Test1((int[,] Currect, int[,] Next, bool RunInParallel) value)
        {
            WriteFormatted(value.Currect);

            var game = new GameOfLifeExecutor(value.RunInParallel);

            var next = game.Tick(value.Currect);

            WriteFormatted(next);

            ClassicAssert.That(next, Is.EqualTo(value.Next));
        }

        private static IEnumerable<(int[,], int[,], bool)> GetTestData()
        {
            yield return (
                new int[,] { { 0, 1, 1, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } },
                false
            );
            yield return (
                new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } },
                new int[,] { { 1, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 0, 0, 1 } },
                false
            );
            yield return (
                new int[,] { { 0, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                new int[,] { { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                false
            );
            yield return (
                new int[,] { { 0, 1, 1, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } },
                true
            );
            yield return (
                new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } },
                new int[,] { { 1, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 0, 0, 1 } },
                true
            );
            yield return (
                new int[,] { { 0, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                new int[,] { { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                true
            );
        }

        private void WriteFormatted(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}