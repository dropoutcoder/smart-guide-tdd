using NUnit.Framework.Legacy;
using SmartGuideTdd.FindMultiples.Abstraction;

namespace SmartGuideTdd.FindMultiples.Tests
{
    [TestFixture]
    public class LinqAggregateDivisibleValueFinderTests
    {
        [TestCase(uint.MinValue + 1, uint.MinValue)]
        [TestCase(uint.MaxValue, uint.MaxValue - 1)]
        public void Limit_Is_Greater_Than_Base_Throws_InvalidOperationException(uint @base, uint limit)
        {
            IDivisibleValueFinder finder = new LinqAggregateDivisibleValueFinder();

            var func = (uint @base, uint limit) => finder.Find(@base, limit).ToList();

            ClassicAssert.Catch<InvalidOperationException>(() => func(@base, limit));
        }

        [Test]
        public void Base_Is_Zero_Throws_ArgumentOutOfRangeException()
        {
            IDivisibleValueFinder finder = new LinqAggregateDivisibleValueFinder();

            ClassicAssert.Throws<ArgumentOutOfRangeException>(() => finder.Find(uint.MinValue, uint.MaxValue).ToList());
        }

        [TestCase(1U, 3U, new uint[] { 1U, 2U, 3U })]
        [TestCase(3U, 7U, new uint[] { 3U, 6U })]
        [TestCase(2U, 6U, new uint[] { 2U, 4U, 6U })]
        public void Base_Is_Greated_Than_Limit_Results_Succeed(uint @base, uint limit, uint[] expected)
        {
            IDivisibleValueFinder finder = new LinqAggregateDivisibleValueFinder();

            var result = finder.Find(@base, limit).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
