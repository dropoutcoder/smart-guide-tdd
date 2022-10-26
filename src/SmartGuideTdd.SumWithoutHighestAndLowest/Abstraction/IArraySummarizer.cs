namespace SmartGuideTdd.SumWithoutHighestAndLowest.Abstraction
{
    /// <summary>
    /// Provides method to sum number of an array
    /// </summary>
    public interface IArraySummarizer
    {
        /// <summary>
        /// Sums values in <paramref name="array"/> excluding lowest and highest numbers, including duplicate entries
        /// </summary>
        /// <param name="array">A non-empty array of integers</param>
        /// <returns>Sum of numbers excluding lowest and highest numbers</returns>
        public int Sum(int[] array);
    }
}
