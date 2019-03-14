using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SampleFramework1
{
    [TestFixture]
    [Category("SampleApplicationOne")]
    public class SampleApplicationOneTests
    {
        // Properties

        private IWebDriver Driver { get; set; }

        private TestUser TheTestUser { get; set; }

        private TestUser EmergencyContactUser { get; set; }

        private SampleApplicationPage SampleAppPage { get; set; }

        /*
         * SetUp
         */

        [SetUp]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            SampleAppPage = new SampleApplicationPage(Driver);

            TheTestUser = new TestUser();

            TheTestUser.FirstName = "Nikolay";
            TheTestUser.LastName = "BLahzah";
        }

        /*
         * Tests
         */

        [Test]
        [Description("Validate that user is able to fill out the form successfully using valid data")]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            Assert.IsTrue(SampleAppPage.IsVisible);

            //SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);

            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormFormAndSubmit(TheTestUser);
            Thread.Sleep(2000);
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }

        [Test]
        public void PretendTestNumber2()
        {
            SampleAppPage.GoTo();
            Assert.IsTrue(SampleAppPage.IsVisible);

            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormFormAndSubmit(TheTestUser);
            Thread.Sleep(2000);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible);
        }

        [Test]
        [Description("Validate that when selection the Other gender type, the form is submitted successfully")]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            Assert.IsTrue(SampleAppPage.IsVisible);

            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormFormAndSubmit(TheTestUser);
            Thread.Sleep(2000);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible);
        }

        /*
         * Cleanup
         */

        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        /*
         * Driver
         */

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return new ChromeDriver(outputDirectory);
        }

        /*
         * Methods
         */

        private void SetGenderTypes(Gender primaryContact, Gender energencyContact)
        {
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser = EmergencyContactUser;
        }
    }
}
