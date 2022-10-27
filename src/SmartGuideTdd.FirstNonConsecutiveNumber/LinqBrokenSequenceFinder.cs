using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

namespace SmartGuideTdd.FirstNonConsecutiveNumber
{
    /// <inheritdoc />
    public class LinqBrokenSequenceFinder : IBrokenSequenceFinder
    {
        /// <inheritdoc />
        public int? Find(int[] sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (sequence.Length < 2)
            {
                throw new ArgumentException(nameof(sequence), $"Parameter {nameof(sequence)} contains less than allowed minimum items. Minimum numer of allowed items is 2.");
            }

            var range = Enumerable.Range(sequence[0], sequence.Length);

            var result = range
                .GroupJoin(sequence, r => r, s => s, (r, s) => new { R = r, S = s })
                .SkipWhile(x => x.S.Count() > 0)
                .TakeWhile(x => x.S.Count() == 0)
                .LastOrDefault();

            return result is null
                ? null
                : result.R + 1;
        }
    }
}
