using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SampleFramework1
{
    public class SampleApplicationPage : BaseSampleApplicationPage
    {
        /*
         * Properties
         * */

        public bool IsVisible => Driver.Title.Contains("Sample Application Lifecycle - Sprint 4 - Ultimate QA");

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        public IWebElement FemaleGenderRadioButtonForEmergencyContact => Driver.FindElement(By.Id("radio2-f"));

        public IWebElement FirstNameFieldForEmergencyContact => Driver.FindElement(By.Id("f2"));

        public IWebElement LastNameFieldForEmergencyContact => Driver.FindElement(By.Id("l2"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.Id("radio1-0"));

        public IWebElement OtherGenderButtonForEmergencyContact => Driver.FindElement(By.Id("radio2-0"));

        private Actions WebDriverActions => new Actions(Driver);

        /*
         * Constructor
         * */

        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        /*
         * Methods
         * */

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
        }

        public UltimateQAHomePage FillOutPrimaryContactFormFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();

            return new UltimateQAHomePage(Driver);
        }

        public void FillOutEmergencyContactForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyContactUser.FirstName);
            LastNameFieldForEmergencyContact.SendKeys(emergencyContactUser.LastName);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    WebDriverActions.MoveToElement(FemaleGenderRadioButton).Click();
                    //FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    WebDriverActions.MoveToElement(OtherGenderRadioButton).Click();
                    //OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Other:
                    OtherGenderButtonForEmergencyContact.Click();
                    break;
                default:
                    break;
            }
        }
    }
}