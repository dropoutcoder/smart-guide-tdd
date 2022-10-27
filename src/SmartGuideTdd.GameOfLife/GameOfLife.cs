namespace SmartGuideTdd.GameOfLife
{
    /// <summary>
    /// Provides method executing life evolution simulation
    /// </summary>
    public class GameOfLife
    {
        /// <summary>
        /// Calculates next life evolution state
        /// </summary>
        /// <param name="current">Current life evolution state</param>
        /// <returns>Calculated next life state based on current state</returns>
        public int[,] Tick(ref int[,] current)
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

        /// <summary>
        /// Evaluates next cell life evolution state based one current neighbor state
        /// </summary>
        /// <param name="current">Current life evolution state</param>
        /// <param name="horizontalIndex">Current horizontal dimension index</param>
        /// <param name="verticalIndex">Current vertical dimension index</param>
        /// <param name="directions">Allowed direction for neighbor search</param>
        /// <returns>Evaluated state for next life evolution iteration</returns>
        private int Evaluate(ref int[,] current, ref int horizontalIndex, ref int verticalIndex, Directions directions)
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

        /// <summary>
        /// Collects neighbor cell life evolution state
        /// </summary>
        /// <param name="current">Current life evolution state</param>
        /// <param name="horizontalIndex">Current horizontal dimension index</param>
        /// <param name="verticalIndex">Current vertical dimension index</param>
        /// <param name="directions">Allowed direction for neighbor search</param>
        /// <returns>Count of live neighbor cells</returns>
        private int GetAliveNeighborCount(ref int[,] current, ref int horizontalIndex, ref int verticalIndex, ref Directions directions)
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

        /// <summary>
        /// Returns available direction to neightbor cells 
        /// </summary>
        /// <param name="horizontalIndex">Current horizontal dimension index</param>
        /// <param name="verticalIndex">Current vertical dimension index</param>
        /// <param name="horizontalMax">Maximum horizontal dimension index</param>
        /// <param name="verticalMax">Maximum vertical dimension index</param>
        /// <returns>Flagged <see cref="Directions"/> with available direction neighbor cell are located</returns>
        private Directions GetAvailableDirections(int horizontalIndex, int verticalIndex, int horizontalMax, int verticalMax)
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
