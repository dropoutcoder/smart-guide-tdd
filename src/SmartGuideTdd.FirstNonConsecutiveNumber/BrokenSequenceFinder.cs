using SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;
using System.Xml;

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

            if(sequence.Length < 2)
            {
                throw new ArgumentException(nameof(sequence), $"Parameter {nameof(sequence)} contains less than allowed minimum items. Minimum numer of allowed items is 2.");
            }

            

            throw new NotImplementedException();
        }
    }
}
