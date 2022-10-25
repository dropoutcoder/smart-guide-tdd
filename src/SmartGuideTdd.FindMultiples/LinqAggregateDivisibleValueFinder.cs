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

            var range = Enumerable.Range((int)@base, (int)limit - (int)@base + 1);

            var result = range.Aggregate(new List<int>(), (acc, current) =>
            {
                if(current % @base == 0)
                {
                    acc.Add(current);
                }

                return acc;
            });

            return result.Select(x => (uint)x);
        }
    }
}
