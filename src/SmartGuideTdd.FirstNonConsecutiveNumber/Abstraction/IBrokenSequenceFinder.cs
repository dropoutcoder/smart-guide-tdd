namespace SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction
{
    /// <summary>
    /// Provides method for finding first number that is missing in the sequence
    /// </summary>
    public interface IBrokenSequenceFinder
    {
        /// <summary>
        /// Returns first number missing in <paramref name="sequence"/> sequence
        /// </summary>
        /// <param name="sequence">Array of number representing sequence</param>
        /// <returns>Returns first number missing in the sequence, if any exists, otherwise null</returns>
        public int? Find(int[] sequence);
    }
}
