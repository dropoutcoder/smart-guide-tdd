using SmartGuideTdd.FizzBuzz.Abstraction;
using System.Globalization;

namespace SmartGuideTdd.FizzBuzz
{
    /// <inheritdoc />
    public class FizzBuzzer : IFizzBuzzer
    {
        /// <inheritdoc />
        public string FizzBuzz(int value)
        {
            if(value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter {nameof(value)} has to be greater than 0.");
            }

            if(IsDivisibleBy(value, 15))
            {
                return "fizzbuzz";
            }

            if (IsDivisibleBy(value, 5))
            {
                return "buzz";
            }

            if (IsDivisibleBy(value, 3))
            {
                return "fizz";
            }

            return value.ToString(CultureInfo.InvariantCulture);
        }

        private bool IsDivisibleBy(int value, int divider)
        {
            return value % divider == 0;
        }
    }
}
