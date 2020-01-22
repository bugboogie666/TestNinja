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
    class DemeritPointsCalculatorTests
    {
        public delegate int Points(int value);

        [Test]
        [TestCase(64)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedIsLessOrEqualToSpeedLimit65_Returns0Points(int speedValue)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speedValue);

            Assert.That(result, Is.EqualTo(0));            

        }
        [Test]
        [TestCase(297)]
        [TestCase(298)]
        public void CalculateDemeritPoints_SpeedIs297and298_ReturnsIntValueRoundedDown(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(46));

        }

        [Test]
        public void CalculateDemeritPoints_SpeedIs298_ReturnsDecimalValueMathematicallyRounded()
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(298);

            Assert.That(result, Is.EqualTo(46));

        }

        [Test]
        [TestCase(-1)]
        [TestCase(305)]
        public void CalculateDemeritPoints_SpeedLessThen0orGreatherThenMaxSpeed_ReturnsArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            //public delegate int Points(int value);

            //Points getPoints = calculator.CalculateDemeritPoints;
                        
            //Assert.That(getPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(()=>calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }
    }
}
