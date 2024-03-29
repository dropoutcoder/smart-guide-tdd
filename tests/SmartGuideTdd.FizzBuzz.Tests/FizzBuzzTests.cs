using NUnit.Framework.Legacy;

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

            ClassicAssert.Throws<ArgumentOutOfRangeException>(() => action());
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

            ClassicAssert.That(actual, Is.EqualTo("fizzbuzz"));
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(2000)]
        [TestCase(3545)]
        public void Value_Is_Divisible_By_5_Returns_buzz_String(int value)
        {
            var buzzer = new FizzBuzzer();

            var actual = buzzer.FizzBuzz(value);

            ClassicAssert.That(actual, Is.EqualTo("buzz"));
        }

        [TestCase(3)]
        [TestCase(9)]
        [TestCase(27)]
        [TestCase(999)]
        [TestCase(3333)]
        public void Value_Is_Divisible_By_3_Returns_fizz_String(int value)
        {
            var buzzer = new FizzBuzzer();

            var actual = buzzer.FizzBuzz(value);

            ClassicAssert.That(actual, Is.EqualTo("fizz"));
        }

        [TestCase(4)]
        [TestCase(29)]
        [TestCase(28)]
        [TestCase(331)]
        [TestCase(7777)]
        public void Value_Is_Not_Divisible_By_3_5_Or_15_Returns_Input_Value_As_String(int value)
        {
            var buzzer = new FizzBuzzer();

            var actual = buzzer.FizzBuzz(value);

            ClassicAssert.That(actual, Is.EqualTo($"{value}"));
        }
    }
}