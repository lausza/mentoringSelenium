using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
