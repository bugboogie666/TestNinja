using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IWebClientManager> _fakeWebClient;
        private InstallerHelper _installHelper;

        [SetUp]
        public void SetUp()
        {
            //fake webclient object
            _fakeWebClient = new Mock<IWebClientManager>();

            _installHelper = new InstallerHelper(_fakeWebClient.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadSuccess_ReturnsTrue()
        {
            var result = _installHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {         
            _fakeWebClient.Setup(wc => wc.Download("http://example.com/customer/installer", null)).Throws<WebException>();

            var result = _installHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
    }
}
