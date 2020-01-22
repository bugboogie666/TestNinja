using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Fundamentals.Math testMath;
        //SetUp
        //TearDown
        [SetUp]
        public void SetUp()
        {
            testMath = new Fundamentals.Math();
        }

        [Test]
        [Ignore("Not necessary to test")]
        public void Add_WhenCalled_ReturnsTheSumOfArgs()
        {
            //Arrange
            var int1 = 4;
            var int2 = 12;            
            //Act
            var result = testMath.Add(int1, int2);
            //Assert
            Assert.That(result == 16);
        }

        [Test]
        [TestCase(6, 6, 6)]
        [TestCase(6, 4, 6)]
        [TestCase(4, 6, 6)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {
            
            var result = testMath.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThenZero_OddNumbersUpToLimit()
        {
            var expected = new[] { 1, 3, 5 };
            var result = testMath.GetOddNumbers(5);
            
            Assert.That(result, Is.EquivalentTo(expected));

            //Other usefull methods
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

        }

        [Test]
        public void GetOddNumbers_LimitIsEqualToZero_EmptyArray()
        {
            //var expected;
            var result = testMath.GetOddNumbers(0);

            Assert.That(result, Is.Empty);

            //Other usefull methods
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

        }

    }
}
