using SmartGuideTdd.SumWithoutHighestAndLowest.Abstraction;

namespace SmartGuideTdd.SumWithoutHighestAndLowest
{
    public class ArraySummarizer : IArraySummarizer
    {
        public int Sum(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            throw new NotImplementedException();
        }
    }
}
