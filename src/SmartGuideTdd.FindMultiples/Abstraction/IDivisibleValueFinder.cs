namespace SmartGuideTdd.FindMultiples.Abstraction
{
    /// <summary>
    /// Provides method for finding a range of numbers divisible by base number, but not greater than limiting value
    /// </summary>
    public interface IDivisibleValueFinder
    {
        /// <summary>
        /// Returns sequence of numbers divisible by <paramref name="base"/>, but not greater than <paramref name="limit"/>
        /// </summary>
        /// <param name="base">A number that is greater than System.UInt32.MinValue, but less than or equal to System.UInt32.MaxValue.</param>
        /// <param name="limit">A number that is greater than <paramref name="base"/>, but less than or equal to System.UInt32.MaxValue.</param>
        /// <returns>A range of <see cref="UInt32"/> numbers divisible by <paramref name="base"/>, but not greater than <paramref name="limit"/></returns>
        public IEnumerable<uint> Find(uint @base, uint limit);
    }
}