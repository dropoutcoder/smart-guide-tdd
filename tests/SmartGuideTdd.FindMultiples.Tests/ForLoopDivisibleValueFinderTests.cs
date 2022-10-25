using SmartGuideTdd.FindMultiples.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartGuideTdd.FindMultiples.Tests
{
    [TestFixture]
    internal class ForLoopDivisibleValueFinderTests
    {
        [TestCase(uint.MinValue + 1, uint.MinValue)]
        [TestCase(uint.MaxValue, uint.MaxValue - 1)]
        public void Limit_Is_Greater_Than_Base_Throws_InvalidOperationException(uint @base, uint limit)
        {
            IDivisibleValueFinder finder = new ForLoopDivisibleValueFinder();

            var func = (uint @base, uint limit) => finder.Find(@base, limit).ToList();

            Assert.Catch<InvalidOperationException>(() => func(@base, limit));
        }

        [Test]
        public void Base_Is_Zero_Throws_ArgumentOutOfRangeException()
        {
            IDivisibleValueFinder finder = new ForLoopDivisibleValueFinder();

            Assert.Throws<ArgumentOutOfRangeException>(() => finder.Find(uint.MinValue, uint.MaxValue).ToList());
        }

        [TestCase(1U, 3U, new uint[] { 1U, 2U, 3U })]
        [TestCase(3U, 7U, new uint[] { 3U, 6U })]
        [TestCase(2U, 6U, new uint[] { 2U, 4U, 6U })]
        public void Base_Is_Greated_Than_Limit_Results_Succeed(uint @base, uint limit, uint[] expected)
        {
            IDivisibleValueFinder finder = new ForLoopDivisibleValueFinder();

            var result = finder.Find(@base, limit).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
