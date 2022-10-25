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

        [TestCase(new[] { Int32.MinValue })]
        [TestCase(new[] { 0 })]
        [TestCase(new[] { Int32.MaxValue })]
        public void Array_Has_One_Item_Throws_ArgumentException(int[] sequence)
        {
            var finder = new BrokenSequenceFinder();

            var action = () => finder.Find(sequence);

            Assert.Throws<ArgumentException>(() => action());
        }
    }
}