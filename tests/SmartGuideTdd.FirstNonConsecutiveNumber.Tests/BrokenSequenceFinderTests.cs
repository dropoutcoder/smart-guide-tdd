namespace SmartGuideTdd.FirstNonConsecutiveNumber.Tests
{
    [TestFixture]
    public class BrokenSequenceFinderTests
    {
        [Test]
        public void Array_Is_Null_Throws_ArgumentNullException()
        {
            var finder = new BrokenSequenceFinder();

            var action = () => finder.Find(null);

            Assert.Throws<ArgumentNullException>(() => action());
        }
    }
}