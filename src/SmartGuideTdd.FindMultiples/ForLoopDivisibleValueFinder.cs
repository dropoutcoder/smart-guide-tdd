using SmartGuideTdd.FindMultiples.Abstraction;

namespace SmartGuideTdd.FindMultiples
{
    /// <inheritdoc />
    public class ForLoopDivisibleValueFinder : IDivisibleValueFinder
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

            for (uint i = @base; i <= limit; i += @base)
            {
                yield return i;
            }
        }
    }
}
