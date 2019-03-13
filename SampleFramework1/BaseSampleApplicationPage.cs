using OpenQA.Selenium;

namespace SampleFramework1
{
    public class BaseSampleApplicationPage
    {
        public IWebDriver Driver { get; set; }

        public BaseSampleApplicationPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}