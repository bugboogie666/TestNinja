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
    class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_InputParamReturnedEnclosedWithStrongElement()
        {
            var htmlFormatter = new HtmlFormatter();
            var expected = "<strong>hello world</strong>";

            var result = htmlFormatter.FormatAsBold("hello world");
            
            //Specific
            Assert.That(result,Is.EqualTo(expected));

            //More general assertion
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("hello world"));

        }

    }
}
