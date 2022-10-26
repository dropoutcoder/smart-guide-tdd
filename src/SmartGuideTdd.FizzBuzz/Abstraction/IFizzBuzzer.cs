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
        /// <returns>String representation of <paramref name="value"/>. If divisible by 3 then "fizz", if 5 then "buzz", if 15 then "fizzbuzz", otherwise <paramref name="value"/> as string</returns>
        public string FizzBuzz(int value);
    }
}
