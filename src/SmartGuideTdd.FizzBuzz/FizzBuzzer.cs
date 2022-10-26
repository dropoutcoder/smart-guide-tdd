using SmartGuideTdd.FizzBuzz.Abstraction;

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

            throw new NotImplementedException();
        }
    }
}
