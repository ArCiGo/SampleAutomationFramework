using OpenQA.Selenium;

namespace SampleFramework1
{
    public class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => ViewAllCoursesHere.Displayed;

        public IWebElement ViewAllCoursesHere => Driver.FindElement(By.CssSelector("#et-boc > div > div.et_pb_section.et_pb_section_1.et_pb_with_background.et_section_regular > div > div.et_pb_column.et_pb_column_1_2.et_pb_column_0.et_pb_css_mix_blend_mode_passthrough > div.et_pb_button_module_wrapper.et_pb_button_0_wrapper.et_pb_button_alignment_.et_pb_module > a"));
    }
}