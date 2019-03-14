using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SampleFramework1
{
    [TestFixture()]
    [Category("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        private IWebDriver Driver { get; set; }

        private TestUser TheTestUser { get; set; }

        [SetUp]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();

            TheTestUser = new TestUser();

            TheTestUser.FirstName = "Nikolay";
            TheTestUser.LastName = "BLahzah";
        }

        [Test()]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Thread.Sleep(2000);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }

        [Test()]
        public void PretendTestNumber2()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Thread.Sleep(2000);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible);
        }

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return new ChromeDriver(outputDirectory);
        }
    }
}
