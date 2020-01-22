using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        [TestCase(10)]
        [TestCase(-10)]
        public void GetOutput_WhenCalledWithByFiveDivisibleNumber_ReturnsStringBuzz(int inputNumber)
        {            
            var result = FizzBuzz.GetOutput(inputNumber);
            var expected = "Buzz";

            Assert.That(result, Is.EqualTo(expected));
            
        }

        [Test]
        [TestCase(6)]
        [TestCase(-6)]
        public void GetOutput_WhenCalledWithByThreeDivisibleNumber_ReturnsStringFizz(int inputNumber)
        {
            var result = FizzBuzz.GetOutput(inputNumber);
            var expected = "Fizz";

            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(15)]
        [TestCase(-15)]
        [TestCase(0)]
        public void GetOutput_WhenCalledWithByThreeAndFiveDivisibleNumber_ReturnsStringFizzBuzz(int inputNumber)
        {
            var result = FizzBuzz.GetOutput(inputNumber);
            var expected = "FizzBuzz";

            Assert.That(result, Is.EqualTo(expected));

        }
        [Test]
        public void GetOutput_WhenCalledWithByThreeAndFiveOrByThreeOrFiveNotDivisibleNumber_ReturnsSameAsInput()
        {
            var result = FizzBuzz.GetOutput(2);
            var expected = "2";

            Assert.That(result, Is.EqualTo(expected));
        }


    }
}
