using System;
using OpenQA.Selenium;

namespace TestAutomationFrameworkMentoring.Extensions
{
    public static class Element_extensions
    {
        public static void SendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            Console.WriteLine(text + "is entered in the field.");
        }

        public static bool IsDisplay(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine("Element {0} is displayed.", element);
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine("Element {0} is not displayed. Exception handling message: {1} ", element, e);
                throw;
            }
            return result;
        }

    }
}
