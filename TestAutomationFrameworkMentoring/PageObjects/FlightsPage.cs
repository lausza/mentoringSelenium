using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class FlightsPage
    {
        private readonly DriverContext driverContext;

        private readonly ElementLocator
            fromField = new ElementLocator(Locator.Id, "s2id_location_from"),
            cityFromName = new ElementLocator(Locator.CssSelector, "div#select2-drop input"),
            firstFromCity = new ElementLocator(Locator.XPath, "//li[@class=\"select2-results-dept-0 select2-result select2-result-selectable select2-highlighted\"]");


        public FlightsPage(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        private readonly ElementLocator
            flightsBtn = new ElementLocator(Locator.XPath, "//a[@title=\"Flights\"]");

        public void ClickOnFlightsBtn()
        {
            this.driverContext.Driver.GetElement(flightsBtn).Click();
        }

        public void SetFromCity(string fromCity)
        {
            this.driverContext.Driver.GetElement(fromField).Click();
            this.driverContext.Driver.GetElement(cityFromName).SendKeys(fromCity);
            this.driverContext.Driver.GetElement(firstFromCity).Click();
        }
    }
}
