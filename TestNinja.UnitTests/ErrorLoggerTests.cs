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
    class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            string errorMsg = "This is error!";
            var errorLogger = new ErrorLogger();

            errorLogger.Log(errorMsg);

            Assert.That(errorLogger.LastError, Is.EqualTo(errorMsg));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_WhenCalledWithNoArgument_ReturnsException(string error)
        {
            var errorLogger = new ErrorLogger();

            //errorLogger.Log(error);
            Assert.That(()=>errorLogger.Log(error),Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));

        }
    }
}
