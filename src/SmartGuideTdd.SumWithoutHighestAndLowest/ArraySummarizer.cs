using SmartGuideTdd.SumWithoutHighestAndLowest.Abstraction;

namespace SmartGuideTdd.SumWithoutHighestAndLowest
{
    /// <inheritdoc />
    public class ArraySummarizer : IArraySummarizer
    {
        /// <inheritdoc />
        public int Sum(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var min = new Occurence();
            var max = new Occurence();
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                TryUpdate(array[i], (o, v) => v < o.Value, ref min);
                TryUpdate(array[i], (o, v) => v > o.Value, ref max);

                checked
                {
                    sum += array[i];
                }
            }

            return sum - min - max;
        }

        /// <summary>
        /// Attempting to update existing value
        /// </summary>
        /// <param name="value">A value for occurence</param>
        /// <param name="createNew">Function evaluating if new instance of <see cref="Occurence"/> should be created.</param>
        /// <param name="occurence">Current occurence instance</param>
        /// <returns>True if <paramref name="min"/> is updated, false if <paramref name="occurence"/> is replaced by new instance, otherwise false.</returns>
        private static bool TryUpdate(int value, Func<Occurence, int, bool> createNew, ref Occurence occurence)
        {
            if (occurence.Value == value)
            {
                occurence++;
                return true;
            }

            if (createNew(occurence, value))
            {
                occurence = new Occurence(value, 1);
                return false;
            }

            return false;
        }

        /// <summary>
        /// Represents number of occurence for particular number
        /// </summary>
        private struct Occurence
        {
            /// <summary>
            /// Initializes instance of Occurence
            /// </summary>
            /// <param name="value">Value for capturing occurences</param>
            /// <param name="count">Number of initial occurences</param>
            public Occurence(int value, int count)
            {
                Value = value;
                Count = count;
            }

            public int Value { get; } = 0;
            public int Count { get; private set; } = 0;

            /// <summary>
            /// Returns total value
            /// </summary>
            /// <returns>Total of value multiplied by count.</returns>
            public int GetTotal()
            {
                var total = 0;

                for (int i = 0; i < Count; i++)
                {
                    total += Value;
                }

                return total;
            }

            public static int operator +(int value, Occurence occurence)
            {
                return value + occurence.GetTotal();
            }

            public static int operator -(int value, Occurence occurence)
            {
                return value - occurence.GetTotal();
            }

            public static Occurence operator ++(Occurence value)
            {
                value.Count += 1;

                return value;
            }

            public static Occurence operator --(Occurence value)
            {
                value.Count -= 1;

                return value;
            }
        }
    }
}
