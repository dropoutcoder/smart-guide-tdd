namespace SmartGuideTdd.FizzBuzz.Abstraction
{
    /// <summary>
    /// Provides method evaluating if number is divisible by fizzbuzz numbers
    /// </summary>
    public interface IFizzBuzzer
    {
        /// <summary>
        /// Evaluates if <paramref name="value"/> is dividible by 3, 5, or 15
        /// </summary>
        /// <param name="value">A positive number to evaluate</param>
        /// <returns>Returns "fizz" for <paramref name="value"/> divisible by 3, "buzz" for number divisible by 5, "fizzbuzz" for number divisible by 15, otherwise returns <paramref name="value"/> as string</returns>
        public string FizzBuzz(int value);
    }
}
