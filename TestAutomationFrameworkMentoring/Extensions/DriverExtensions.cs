namespace TestAutomationFrameworkMentoring.Extensions
{
    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Extensions;
    using Objectivity.Test.Automation.Common.Types;
    using OpenQA.Selenium;
    using System;
    using OpenQA.Selenium.Support.UI;
    using System.Globalization;
    using Objectivity.Test.Automation.Common.WebElements;

    public static class DriverExtensions
    {

        public static void WaitForElementToBeDisplayed(this IWebDriver driver, ElementLocator locator, double timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
            {
                Message = $"Element not displayed ({locator.Value})"
            };

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(locator.ToBy()));
            }

            catch (WebDriverTimeoutException)
            {
            }

            catch (StaleElementReferenceException)
            {
            }
        }

        public static void WaitForElementToBeDisplayed(this IWebDriver driver, ElementLocator locator)
        {
            WaitForElementToBeDisplayed(driver, locator, BaseConfiguration.LongTimeout);
        }

        public static void SendKeys(this IWebDriver driver, ElementLocator locator, object text, bool deleteContent = true)
        {
            if (text != null && text.ToString().Equals(string.Empty))
            {
                driver.WaitForElementToBeDisplayed(locator, BaseConfiguration.LongTimeout);
                driver.GetElement(locator).Clear();
            }
            else if (!(text is int) && (string)text == Keys.Enter)
            {
                driver.WaitForElementToBeDisplayed(locator, BaseConfiguration.LongTimeout);
                driver.GetElement(locator).SendKeys(text?.ToString());
            }
            else if (text != null && deleteContent)
            {
                driver.WaitForElementToBeDisplayed(locator, BaseConfiguration.LongTimeout);
                driver.GetElement(locator).Clear();
                driver.GetElement(locator).SendKeys(text.ToString());
            }
            else if (text != null)
            {
                driver.WaitForElementToBeDisplayed(locator, BaseConfiguration.LongTimeout);
                driver.GetElement(locator).SendKeys(text.ToString());
            }
        }

        public static bool IsElementPresent(this IWebDriver driver, ElementLocator locator)
        {
            return driver.IsElementPresent(locator, BaseConfiguration.LongTimeout);
        }

        public static void Click(this IWebDriver driver, ElementLocator locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseConfiguration.LongTimeout))
            {
                Message = $"Element not clickable ({locator.Value})"
            };

            wait.Until(ExpectedConditions.ElementToBeClickable(locator.ToBy())).Click();
        }

        public static void TickCheckbox(this IWebDriver driver, ElementLocator locator)
        {
            driver.ScrollElementIntoMiddle(locator);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseConfiguration.LongTimeout))
            {
                Message = $"Element not clickable ({locator.Value})"
            };

            wait.Until(ExpectedConditions.ElementToBeClickable(locator.ToBy()));

            driver.GetElement<Checkbox>(locator).TickCheckbox();
        }

        public static void UnTickCheckbox(this IWebDriver driver, ElementLocator locator)
        {
            driver.ScrollElementIntoMiddle(locator);
            driver.GetElement<Checkbox>(locator).UntickCheckbox();
        }

        public static void ScrollElementIntoMiddle(this IWebDriver webDriver, ElementLocator locator)
        {
            IWebElement element = webDriver.ToDriver().GetElement(locator, e => e.Enabled);
            Scroll(webDriver, element);
        }

        private static void Scroll(IWebDriver webDriver, IWebElement webElement)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)webDriver;
            if (webDriver == null)
                return;

            int height = webDriver.Manage().Window.Size.Height;
            int y = ((ILocatable)webElement).LocationOnScreenOnceScrolledIntoView.Y;
            javaScriptExecutor.ExecuteScript(string.Format(CultureInfo.InvariantCulture, "javascript:window.scrollBy(0,{0})", new[]
            {
                (object) (y - height / 2)
            }));
        }

    }
}
