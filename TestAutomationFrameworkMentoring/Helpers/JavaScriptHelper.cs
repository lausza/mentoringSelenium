using OpenQA.Selenium;

namespace TestAutomationFrameworkMentoring.Helpers
{
    public static class JavaScriptHelper
    {
        public static void JavaScriptScroll(IWebDriver Driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,1000)");
        }
    }
}
