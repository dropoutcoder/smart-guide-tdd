namespace SmartGuideTdd.FirstNonConsecutiveNumber.Tests
{
    [TestFixture]
    public class BitwiseBrokenSequenceFinderTests
    {
        [Test]
        public void Array_Is_Null_Throws_ArgumentNullException()
        {
            var finder = new BitwiseBrokenSequenceFinder();

            var action = () => finder.Find(null);

            Assert.Throws<ArgumentNullException>(() => action());
        }

        [TestCase(new int[0])]
        [TestCase(new[] { Int32.MinValue })]
        [TestCase(new[] { 0 })]
        [TestCase(new[] { Int32.MaxValue })]
        public void Array_Has_Less_Than_Two_Items_Throws_ArgumentException(int[] sequence)
        {
            var finder = new BitwiseBrokenSequenceFinder();

            var action = () => finder.Find(sequence);

            Assert.Throws<ArgumentException>(() => action());
        }

        //[TestCase(new[] { Int32.MaxValue, Int32.MinValue })]
        //[TestCase(new[] { 0, Int32.MinValue })]
        //[TestCase(new[] { Int32.MaxValue, 0 })]
        //public void Array_Has_Unordered_Items_Throws_InvalidOperationException(int[] sequence)
        //{
        //    var finder = new BrokenSequenceFinder();

        //    var action = () => finder.Find(sequence);

        //    Assert.Throws<InvalidOperationException>(() => action());
        //}

        //[TestCase(new[] { Int32.MinValue, Int32.MinValue, 0, Int32.MaxValue })]
        //[TestCase(new[] { Int32.MinValue, 0, 0, Int32.MaxValue })]
        //[TestCase(new[] { Int32.MinValue, 0, Int32.MaxValue, Int32.MaxValue })]
        //public void Array_Has_Duplicate_Items_Throws_InvalidOperationException(int[] sequence)
        //{
        //    var finder = new BrokenSequenceFinder();

        //    var action = () => finder.Find(sequence);

        //    Assert.Throws<InvalidOperationException>(() => action());
        //}

        [TestCase(new[] { 0, 1, 2 }, null)]
        [TestCase(new[] { -2, -1, 0 }, null)]
        [TestCase(new[] { -1, 0, 1 }, null)]
        [TestCase(new[] { Int32.MinValue, Int32.MinValue + 1, Int32.MinValue + 2 }, null)]
        [TestCase(new[] { Int32.MaxValue - 2, Int32.MaxValue - 1, Int32.MaxValue}, null)]
        [TestCase(new[] { Int32.MinValue, Int32.MinValue + 2, Int32.MinValue + 3 }, Int32.MinValue + 2)]
        [TestCase(new[] { Int32.MinValue, 0, 1 }, 0)]
        [TestCase(new[] { 0, 1, Int32.MaxValue }, Int32.MaxValue)]
        public void Array_Contains_Valid_Items_Returns_Null_Or_Number(int[] sequence, int? expected)
        {
            var finder = new BitwiseBrokenSequenceFinder();

            var actual = finder.Find(sequence);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}