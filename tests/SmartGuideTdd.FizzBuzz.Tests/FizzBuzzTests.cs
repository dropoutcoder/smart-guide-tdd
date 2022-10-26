namespace SmartGuideTdd.FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(0)]
        [TestCase(Int32.MinValue)]
        public void Value_Is_Less_Than_Zero_Throws_ArgumentOutOfRangeException(int value)
        {
            var buzzer = new FizzBuzzer();

            var action = () => buzzer.FizzBuzz(value);

            Assert.Throws<ArgumentOutOfRangeException>(() => action());
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(150)]
        [TestCase(1500)]
        [TestCase(9000)]
        public void Value_Is_Divisible_By_15_Returns_fizzbuzz_String(int value)
        {
            var buzzer = new FizzBuzzer();

            var actual = buzzer.FizzBuzz(value);

            Assert.That(actual, Is.EqualTo("fizzbuzz"));
        }
    }
}