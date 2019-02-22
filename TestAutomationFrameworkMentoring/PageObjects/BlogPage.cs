using System;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using TestAutomationFrameworkMentoring.Extensions;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    class BlogPage : ProjectPageBase
    {
        private readonly ElementLocator
            blogBtn = new ElementLocator(Locator.XPath, "//a[@href=\"https://www.phptravels.net/blog\"]"),
            searchField = new ElementLocator(Locator.XPath, "//input[@name=\"s\"]"),
            searchBtn = new ElementLocator(Locator.CssSelector, "div#body-section button[type=\"submit\"]"),
            headerText = new ElementLocator(Locator.CssSelector, "div#body-section h4");

        public BlogPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickOnBlogLink()
        {
            this.Driver.GetElement(blogBtn).Click();
        }
        
        public void SearchForElement(string searchValue)
        {
            var element = this.Driver.GetElement(searchField);
            element.Click();
            element.SendText(searchValue);
        }

        public void ClickOnSearchBtn()
        {
            this.Driver.GetElement(searchBtn).Click();
        }

        public void CheckResultsOnPage()
        {
            var element = this.Driver.GetElement(headerText);
            element.IsDisplay();
            var textElement = element.Text;
            Console.WriteLine(textElement);
            Assert.IsNotEmpty(textElement);
        }
    }
}
