namespace SmartGuideTdd.GameOfLife
{
    public static class GameOfLife
    {
        public static int[,] Tick(ref int[,] current)
        {
            var m = current.GetLength(0);
            var n = current.GetLength(1);

            var next = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    next[i, j] = Evaluate(ref current, ref i, ref j, GetAvailableDirections(i, j, m, n));
                }
            }

            return next;
        }

        private static int Evaluate(ref int[,] current, ref int horizontalIndex, ref int verticalIndex, Directions directions)
        {
            var cell = current[horizontalIndex, verticalIndex];

            int aliveNeighbourCount = GetAliveNeighborCount(ref current, ref horizontalIndex, ref verticalIndex, ref directions);

            if (cell == 0)
            {
                return Convert.ToInt32(aliveNeighbourCount == 3);
            }
            else
            {
                return Convert.ToInt32(aliveNeighbourCount >= 2 && aliveNeighbourCount <= 3);
            }
        }

        private static int GetAliveNeighborCount(ref int[,] current, ref int horizontalIndex, ref int verticalIndex, ref Directions directions)
        {
            var aliveNeighbourCount = 0;

            if (directions.HasFlag(Directions.Left))
            {
                aliveNeighbourCount += current[horizontalIndex, verticalIndex - 1];
            }

            if (directions.HasFlag(Directions.Left) && directions.HasFlag(Directions.Top))
            {
                aliveNeighbourCount += current[horizontalIndex - 1, verticalIndex - 1];
            }

            if (directions.HasFlag(Directions.Top))
            {
                aliveNeighbourCount += current[horizontalIndex - 1, verticalIndex];
            }

            if (directions.HasFlag(Directions.Top) && directions.HasFlag(Directions.Right))
            {
                aliveNeighbourCount += current[horizontalIndex - 1, verticalIndex + 1];
            }

            if (directions.HasFlag(Directions.Right))
            {
                aliveNeighbourCount += current[horizontalIndex, verticalIndex + 1];
            }

            if (directions.HasFlag(Directions.Right) && directions.HasFlag(Directions.Bottom))
            {
                aliveNeighbourCount += current[horizontalIndex + 1, verticalIndex + 1];
            }

            if (directions.HasFlag(Directions.Bottom))
            {
                aliveNeighbourCount += current[horizontalIndex + 1, verticalIndex];
            }

            if (directions.HasFlag(Directions.Bottom) && directions.HasFlag(Directions.Left))
            {
                aliveNeighbourCount += current[horizontalIndex + 1, verticalIndex - 1];
            }

            return aliveNeighbourCount;
        }

        private static Directions GetAvailableDirections(int horizontalIndex, int verticalIndex, int horizontalMax, int verticalMax)
        {
            var directions = Directions.Left | Directions.Top | Directions.Right | Directions.Bottom;

            if (verticalIndex == 0)
            {
                directions &= ~Directions.Left;
            }

            if (horizontalIndex == 0)
            {
                directions &= ~Directions.Top;
            }

            if (verticalIndex == verticalMax - 1)
            {
                directions &= ~Directions.Right;
            }
            
            if (horizontalIndex == horizontalMax - 1)
            {
                directions &= ~Directions.Bottom;
            }

            return directions;
        }

        [Flags]
        private enum Directions
        {
            Left = 1,
            Top = 2,
            Right = 4,
            Bottom = 8
        }
    }
}
