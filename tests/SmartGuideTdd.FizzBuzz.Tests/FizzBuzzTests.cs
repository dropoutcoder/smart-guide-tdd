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
    }
}