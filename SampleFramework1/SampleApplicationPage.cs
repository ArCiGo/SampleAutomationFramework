using System;
using OpenQA.Selenium;

namespace SampleFramework1
{
    public class SampleApplicationPage : BaseSampleApplicationPage
    {
        // Properties

        public bool IsVisible => Driver.Title.Contains("Sample Application Lifecycle - Sprint 1 - Ultimate QA");

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        // Constructor

        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        // Methods

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-1/");
        }

        public UltimateQAHomePage FillOutFormAndSubmit(string firstName)
        {
            FirstNameField.SendKeys(firstName);
            SubmitButton.Submit();

            return new UltimateQAHomePage(Driver);
        }
    }
}