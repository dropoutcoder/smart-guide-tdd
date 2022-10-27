using SmartGuideTdd.FindMultiples.Abstraction;

namespace SmartGuideTdd.FindMultiples
{
    /// <inheritdoc />
    public class LinqAggregateDivisibleValueFinder : IDivisibleValueFinder
    {
        /// <inheritdoc />
        public IEnumerable<uint> Find(uint @base, uint limit)
        {
            if (@base == UInt32.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Parameter {nameof(@base)} is out of range. Parameter {nameof(@base)} must be between {uint.MinValue + 1} and {uint.MaxValue}.");
            }

            if (@base > limit)
            {
                throw new InvalidOperationException($"Parameter {nameof(limit)} must be greaten than parameter {nameof(@base)}");
            }

            var range = GenerateRange(@base, limit);

            var result = range.Aggregate(new List<uint>(), (acc, current) =>
            {
                if (current % @base == 0)
                {
                    acc.Add(current);
                }

                return acc;
            });

            return result;
        }

        /// <summary>
        /// Generates range of numbers between <paramref name="start"/> and <paramref name="limit"/>
        /// </summary>
        /// <param name="start">Inclusive initial range value</param>
        /// <param name="limit">Inclusive limit range value</param>
        /// <returns></returns>
        private IEnumerable<uint> GenerateRange(uint start, uint limit)
        {
            for (uint i = start; i <= limit; i++)
            {
                yield return i;
            }
        }
    }
}
