using SmartGuideTdd.SumWithoutHighestAndLowest.Abstraction;

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

            Assert.Throws<ArgumentNullException>(() => action());
        }
    }
}