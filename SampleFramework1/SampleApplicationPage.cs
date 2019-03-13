using System;

namespace SampleFramework1
{
    public class SampleApplicationPage
    {
        private object driver;

        public SampleApplicationPage(object driver)
        {
            this.driver = driver;
        }

        public bool IsVisible { get; internal set; }

        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public UltimateQAHomePage FillOutFormAndSubmit(string v)
        {
            throw new NotImplementedException();
        }
    }
}