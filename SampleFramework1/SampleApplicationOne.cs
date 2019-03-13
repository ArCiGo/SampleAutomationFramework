using NUnit.Framework;
using OpenQA.Selenium;
using System;
namespace SampleFramework1
{
    [TestFixture()]
    [Category("SampleApplicationOne")]
    public class SampleApplicationOne
    {
        private IWebDriver driver;

        [Test()]
        public void TestCase()
        {
            var sampleApplicationPage = new SampleApplicationPage(driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit("Nikolay");
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }
    }
}
