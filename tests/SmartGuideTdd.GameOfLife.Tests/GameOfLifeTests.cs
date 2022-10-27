namespace SmartGuideTdd.GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void Test1((int[,] Currect, int[,] Next) value)
        {
            WriteFormatted(value.Currect);

            var game = new GameOfLife();
                
           var next = game.Tick(ref value.Currect);

            WriteFormatted(next);

            Assert.That(next, Is.EqualTo(value.Next));
        }

        private static IEnumerable<(int[,], int[,])> GetTestData()
        {
            yield return (
                new int[,] { { 0, 1, 1, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } }
            );
            yield return (
                new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } },
                new int[,] { { 1, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 0, 0, 1 } }
            );
            yield return (
                new int[,] { { 0, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
                new int[,] { { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }
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