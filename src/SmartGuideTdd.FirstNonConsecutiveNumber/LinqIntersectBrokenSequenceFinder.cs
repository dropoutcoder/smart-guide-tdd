using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

namespace SmartGuideTdd.FirstNonConsecutiveNumber
{
    public class LinqIntersectBrokenSequenceFinder : IBrokenSequenceFinder
    {
        public int? Find(int[] sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if(sequence.Length < 2)
            {
                throw new ArgumentException(nameof(sequence), $"Parameter {nameof(sequence)} contains less than allowed minimum items. Minimum numer of allowed items is 2.");
            }

            var range = Enumerable.Range(sequence[0], sequence.Length);

            var result = sequence
                .Intersect(range);

            return result.Count() == 0
                ? null
                : result.First();
        }
    }
}
