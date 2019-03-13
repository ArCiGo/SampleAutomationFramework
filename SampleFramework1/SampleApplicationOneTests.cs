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

        [Test()]
        public void Test1()
        {
            Driver = GetChromeDriver();

            var sampleApplicationPage = new SampleApplicationPage(Driver);
            var testUser = new TestUser();

            testUser.FirstName = "Nikolay";
            testUser.LastName = "BLahzah";

            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);

            Thread.Sleep(2000);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }

        [Test()]
        public void PretendTestNumber2()
        {
            Driver = GetChromeDriver();

            var sampleApplicationPage = new SampleApplicationPage(Driver);
            var testUser = new TestUser();

            testUser.FirstName = "Nikolay";
            testUser.LastName = "BLahzah";

            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);

            Thread.Sleep(2000);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }

        [TearDown]
        public void CleanUp()
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
