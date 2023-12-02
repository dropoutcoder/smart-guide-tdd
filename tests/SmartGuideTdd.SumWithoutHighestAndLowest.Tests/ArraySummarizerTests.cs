using NUnit.Framework.Legacy;

namespace SmartGuideTdd.SumWithoutHighestAndLowest.Tests
{
    [TestFixture]
    public class ArraySummarizerTests
    {
        [Test]
        public void Array_Is_Null_Throws_ArgumentNullException()
        {
            var summarizer = new ArraySummarizer();

            var action = () => summarizer.Sum(null!);

            ClassicAssert.Throws<ArgumentNullException>(() => action());
        }

        [Test]
        public void Array_Sum_Overflows_Throws_OverflowException()
        {
            var summarizer = new ArraySummarizer();

            var action = () => summarizer.Sum(new int[] { Int32.MaxValue, Int32.MaxValue - 1, Int32.MaxValue - 2, Int32.MaxValue - 3, Int32.MaxValue - 4 });

            ClassicAssert.Throws<OverflowException>(() => action());
        }

        [TestCase(new int[] { -10, 0, -10, 10, 9, 10 }, 9)]
        [TestCase(new int[] { -23, 5, 5, -1, 11, 9, 10 }, 28)]
        [TestCase(new int[] { 121, -9, 122, 81, 15 }, 217)]
        [TestCase(new int[] { 0, 1, -1, -10, 10 }, 0)]
        public void Array_Is_Null_Throws_ArgumentNullException(int[] value, int expected)
        {
            var summarizer = new ArraySummarizer();

            var actual = summarizer.Sum(value);

            ClassicAssert.That(actual, Is.EqualTo(expected));
        }
    }
}