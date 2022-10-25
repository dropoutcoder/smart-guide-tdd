using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

namespace SmartGuideTdd.FirstNonConsecutiveNumber
{
    public class BrokenSequenceFinder : IBrokenSequenceFinder
    {
        public int Find(int[] sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            throw new NotImplementedException();
        }
    }
}
